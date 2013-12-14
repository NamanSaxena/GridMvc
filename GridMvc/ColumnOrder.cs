using System;

namespace GridMvc
{
    /// <summary>
    /// Represents a column order direction.
    /// </summary>
    public class ColumnOrder
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
        /// Order column name.
        /// </summary>
        public string ColumnName
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnOrder"/> class.
        /// </summary>
        /// <param name="columnName">Column name.</param>
        /// <param name="direction">Order direction.</param>
        public ColumnOrder(string columnName, OrderDirection direction = OrderDirection.Asceding)
        {
            if (columnName == null)
            {
                throw new ArgumentNullException(columnName);
            }

            ColumnName = columnName;
            Direction = direction;
        }
    }
    
}
