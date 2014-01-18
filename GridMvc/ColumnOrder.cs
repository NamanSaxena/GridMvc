using GridMvc.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace GridMvc
{
    /// <summary>
    /// Represents a column order direction.
    /// </summary>
    public class ColumnOrder<T>
    {
        /// <summary>
        /// Order direction.
        /// </summary>
        public OrderDirection Direction
        {
            get;
            private set;
        }

        /// <summary>
        /// Order member name.
        /// </summary>
        public string MemberName
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="columnSelector"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static ColumnOrder<T> NewColumnOrder<TKey>(Expression<Func<T, TKey>> columnSelector, 
            OrderDirection direction = OrderDirection.Asceding)
        {
            if (columnSelector == null)
            {
                throw new ArgumentNullException("columnSelector");
            }

            MemberExpression body = columnSelector.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException(Strings.ExpressionBodyShouldBeMemberExpression);
            }

            List<string> list = new List<string>();

            Expression expr = body;

            do
            {
                MemberExpression memberExpression = (MemberExpression)expr;
                list.Insert(0,memberExpression.Member.Name);
                expr = memberExpression.Expression;
            } while (expr is MemberExpression);

            return new ColumnOrder<T>(string.Join(".", list.ToArray()), direction);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnOrder"/> class.
        /// </summary>
        /// <param name="memberName">Member name.</param>
        /// <param name="direction">Order direction.</param>
        public ColumnOrder(string memberName, OrderDirection direction = OrderDirection.Asceding)
        {
            if (memberName == null)
            {
                throw new ArgumentNullException("memberName");
            }

            MemberName = memberName;
            Direction = direction;
        }
    }
}
