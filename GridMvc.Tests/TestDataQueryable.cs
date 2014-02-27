using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace GridMvc.Tests
{
    class TestDataQueryable<T> : IDataQueryable<T>
    {
        private IList<T> list;

        public TestDataQueryable(IEnumerable<T> enumeration)
        {
            if (enumeration == null)
            {
                throw new ArgumentNullException("enumeration");
            }

            list = enumeration.ToList();
            OrderList = new List<ColumnOrder<T>>();
        }

        public int FetchCount()
        {
            return list.Count;
        }

        public IEnumerable<T> Fetch()
        {
            return ToOrderedList(list);
        }

        public IEnumerable<T> Fetch(int skip, int take)
        {
            return ToOrderedList(list).Skip(skip).Take(take);
        }

        public IList<ColumnOrder<T>> OrderList
        {
            get;
            private set;
        }

        private IEnumerable<T> ToOrderedList(IEnumerable<T> enumeration)
        {
            if (OrderList.Count <= 0)
            {
                return enumeration;
            }

            IOrderedQueryable<T> orderedEnumeration;

            if (OrderList[0].Direction == OrderDirection.Asceding)
            {
                orderedEnumeration = enumeration.AsQueryable().OrderBy(ConvertToLambda(OrderList[0].MemberName));
            }
            else
            {
                orderedEnumeration = enumeration.AsQueryable().OrderByDescending(ConvertToLambda(OrderList[0].MemberName));
            }

            for (int i = 1; i < OrderList.Count; i++)
            {
                if (OrderList[i].Direction == OrderDirection.Asceding)
                {
                    orderedEnumeration = orderedEnumeration.ThenBy(ConvertToLambda(OrderList[i].MemberName));
                }
                else
                {
                    orderedEnumeration = orderedEnumeration.ThenByDescending(ConvertToLambda(OrderList[i].MemberName));
                }
            }

            return orderedEnumeration;
        }

        private Expression<Func<T, object>> ConvertToLambda(string memberName)
        {
            Type t = typeof(T);

            ParameterExpression arg = Expression.Parameter(t);

            Expression previousExpression = arg;
            Type previousType = t;

            foreach (string member in memberName.Split('.'))
            {
                FieldInfo fieldInfo = previousType.GetField(member);
                Type argType;

                if (fieldInfo == null)
                {
                    PropertyInfo propertyInfo = previousType.GetProperty(member);

                    argType = propertyInfo.PropertyType;
                }
                else
                {
                    argType = fieldInfo.FieldType;
                }

                previousExpression = Expression.PropertyOrField(previousExpression, member);
                previousType = argType;
            }

            UnaryExpression body = Expression.Convert(previousExpression, typeof(object));

            return Expression.Lambda<Func<T, object>>(body, arg);
        }
    }
}
