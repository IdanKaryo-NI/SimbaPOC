// ==========================================================================================================================
//  @file ULPersonTable.cs
// 
//  Implementation of the class ULPersonTable.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Simba.DotNetDSI;
using Simba.DotNetDSI.DataEngine;

namespace OPlusDriver.DataEngine
{
    /// <summary>
    /// UltraLight DSII implementation of IResultSet.
    /// </summary>
    class ULPersonTable : DSISimpleResultSet
    {
        /// <summary>
        /// A struct to hold data for each row.
        /// </summary>
        sealed private class RowData
        {
            public string m_Column1;
            public int m_Column2;
            public Decimal m_Column3;
        }

        #region Fields

        /// <summary>
        /// The table columns.
        /// </summary>
        private readonly IList<IColumn> m_Columns = new List<IColumn>();

        /// <summary>
        /// The table data.
        /// </summary>
        private readonly IList<RowData> m_Data = new List<RowData>();

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="log">The logger to use for logging.</param>
        public ULPersonTable(ILogger log) : base(log)
        {
            // TODO(ODBC) #10: Implement your DSISimpleResultSet.
            // TODO(ADO)  #12: Implement your DSISimpleResultSet.
            LogUtilities.LogFunctionEntrance(Log, log);

            // Your implementation of DSISimpleResultSet will simply maintain a handle to the 
            // cursor created on your SQL-enabled data source. This class will delegate 
            // MoveToNextRow() calls to your data source and will retrieve the next row of data at 
            // that time.  In this example the data is hard coded to return 7 rows of data, thus 
            // InitializeData() is placed here.
            InitializeColumns();
            InitializeData();
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Retrieve the columns that represent the data provided in the result set. Even if there 
        /// are no rows in the result set, the columns should still be accurate. 
        /// 
        /// The position in the returned list should match the position in the result set. 
        /// The first column should be found at position 0, the second at 1, etc...
        /// </summary>
        public override IList<IColumn> SelectColumns
        {
            get { return m_Columns; }
        }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Fills in out_data with the data for a given column in the current row.
        /// </summary>
        /// <param name="column">The column to retrieve data from, 0 based.</param>
        /// <param name="offset">The number of bytes in the data to skip before copying.</param>
        /// <param name="maxSize">The maximum number of bytes of data to return.</param>
        /// <param name="out_data">The data to be returned.</param>
        /// <returns>True if there is more data in the column; false otherwise.</returns>
        public override bool GetData(
            int column,
            long offset,
            long maxSize,
            out object out_data)
        {
            LogUtilities.LogFunctionEntrance(Log, column, offset, maxSize, "out_data");

            switch (column)
            {
                case 0:
                {
                    out_data = m_Data[(int)CurrentRow].m_Column1;
                    return false;
                }

                case 1:
                {
                    out_data = m_Data[(int)CurrentRow].m_Column2;
                    return false;
                }

                case 2:
                {
                    out_data = m_Data[(int)CurrentRow].m_Column3;
                    return false;
                }

                default:
                {
                    Debug.Assert(false);
                    out_data = null;
                    return false;
                }
            }
        }

        /// <summary>
        /// Closes the result set's internal cursor. After a call to this method, no
        /// more calls will be made to MoveToNextRow() and GetData().
        /// </summary>
        protected override void DoCloseCursor()
        {
            LogUtilities.LogFunctionEntrance(Log);
        }

        /// <summary>
        /// Indicates that the cursor should be moved to the next row.
        /// </summary>
        /// <returns>True if there are more rows; false otherwise.</returns>
        protected override bool MoveToNextRow()
        {
            LogUtilities.LogFunctionEntrance(Log);

            return (CurrentRow < RowCount);
        }

        /// <summary>
        /// Initialize the column metadata for the result set.
        /// </summary>
        private void InitializeColumns()
        {
            LogUtilities.LogFunctionEntrance(Log);
            
            // Set up column metadata and type info and add new column (#1)
            DSIColumn column = new DSIColumn(TypeMetadataFactory.CreateTypeMetadata(SqlType.WVarChar));
            column.IsNullable = Nullability.Nullable;
            column.Catalog = UltraLight.UL_CATALOG;
            column.Schema = UltraLight.UL_SCHEMA;
            column.TableName = UltraLight.UL_TABLE;
            column.Name = "Name";
            column.Label = column.Name;
            column.TypeMetadata.Length = 100;
            m_Columns.Add(column);

            // Set up column metadata and type info and add new column (#2)
            column = new DSIColumn(TypeMetadataFactory.CreateTypeMetadata(SqlType.Integer));
            column.IsNullable = Nullability.Nullable;
            column.Catalog = UltraLight.UL_CATALOG;
            column.Schema = UltraLight.UL_SCHEMA;
            column.TableName = UltraLight.UL_TABLE;
            column.Name = "Integer";
            column.Label = column.Name;
            column.IsSearchable = Searchable.PredicateBasic;
            m_Columns.Add(column);

            // Set up column metadata and type info and add new column (#3)
            column = new DSIColumn(TypeMetadataFactory.CreateTypeMetadata(SqlType.Numeric));
            column.TypeMetadata.Precision = 4;
            column.TypeMetadata.Scale = 1;
            column.IsNullable = Nullability.Nullable;
            column.Catalog = UltraLight.UL_CATALOG;
            column.Schema = UltraLight.UL_SCHEMA;
            column.TableName = UltraLight.UL_TABLE;
            column.Name = "Numeric";
            column.Label = column.Name;
            column.IsSearchable = Searchable.PredicateBasic;
            m_Columns.Add(column);
        }

        /// <summary>
        /// Initialize the row data for the result set.
        /// </summary>
        private void InitializeData()
        {
            LogUtilities.LogFunctionEntrance(Log);

            RowCount = 7;

            // Initialize the numeric columns.
            for (int i = 0; i < RowCount; ++i)
            {
                m_Data.Add(new RowData());

                // Set the integer column.
                m_Data[i].m_Column2 = i;

                // Set the numeric column.
                m_Data[i].m_Column3 = new Decimal(100.1 + i);
            }

            // Initialize the string data.
            m_Data[0].m_Column1 = "Amyn";
            m_Data[1].m_Column1 = "Hesam";
            m_Data[2].m_Column1 = "Jerry";
            m_Data[3].m_Column1 = "Kyle";
            m_Data[4].m_Column1 = "Marie";
            m_Data[5].m_Column1 = "Sylvia";
            m_Data[6].m_Column1 = "Trevor";
        }

        #endregion // Methods
    }
}
