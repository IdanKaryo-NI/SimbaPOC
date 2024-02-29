// ==========================================================================================================================
//  @file ULCustomMetadataResult.cs
// 
//  Implementation of the class ULCustomMetadataResult.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Simba.DotNetDSI;
using Simba.DotNetDSI.DataEngine;

namespace Simba.UltraLight.DataEngine
{
    /// <summary>
    /// UltraLight DSII implementation of a custom metadata result.
    /// </summary>
    class ULCustomMetadataResult : DSISimpleResultSet
    {
        /// <summary>
        /// A struct to hold data for each row.
        /// </summary>
        private sealed class RowData
        {
            public string m_Column1;
            public int m_Column2;
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
        public ULCustomMetadataResult(ILogger log) : base(log)
        {
            LogUtilities.LogFunctionEntrance(Log, log);

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
            column.TableName = UltraLight.UL_CUSTOMMETADATARESULT;
            column.Name = "Column1";
            column.Label = column.Name;
            column.TypeMetadata.Length = 100;
            m_Columns.Add(column);

            // Set up column metadata and type info and add new column (#2)
            column = new DSIColumn(TypeMetadataFactory.CreateTypeMetadata(SqlType.Integer));
            column.IsNullable = Nullability.Nullable;
            column.Catalog = UltraLight.UL_CATALOG;
            column.Schema = UltraLight.UL_SCHEMA;
            column.TableName = UltraLight.UL_CUSTOMMETADATARESULT;
            column.Name = "Column2";
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

            RowCount = 3;

            // Initialize the numeric columns.
            for (int i = 0; i < RowCount; ++i)
            {
                m_Data.Add(new RowData());

                // Set the string column.
                m_Data[i].m_Column1 = "Sample information for row " + i;

                // Set the integer column.
                m_Data[i].m_Column2 = i;
            }
        }

        #endregion // Methods
    }
}
