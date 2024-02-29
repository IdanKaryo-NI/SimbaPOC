// ==========================================================================================================================
//  @file ULColumnsMetadataSource.cs
// 
//  Implementation of the class ULColumnsMetadataSource.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Simba.DotNetDSI;
using Simba.DotNetDSI.DataEngine;

namespace OPlusDriver.DataEngine
{
    /// <summary>
    /// Class describing a single table column.
    /// </summary>
    class ColumnInfo
    {
        public string m_TableCatalog;
        public string m_TableSchema;
        public string m_TableName;
        public string m_ColumnName;
        public SqlType m_DataType;
        public int m_ColumnSize;
        public int m_BufferLength;
        public short m_DecimalDigits;
        public Nullability m_Nullable;
        public string m_Remarks;
        public string m_ColumnDef;
        public int m_CharOctetLength;
        public int m_OrdinalPosition;
    };

    /// <summary>
    /// UltraLight sample metadata table for types supported by the DSI implementation.
    ///
    /// This source contains the following output columns as defined by SimbaEngine:
    ///     CATALOG_NAME
    ///     SCHEMA_NAME
    ///     TABLE_NAME
    ///     COLUMN_NAME
    ///     DATA_TYPE
    ///     DATA_TYPE_NAME
    ///     COLUMN_SIZE
    ///     BUFFER_LENGTH
    ///     DECIMAL_DIGITS
    ///     NUM_PREC_RADIX
    ///     NULLABLE
    ///     REMARKS
    ///     COLUMN_DEF
    ///     SQL_DATA_TYPE
    ///     SQL_DATETIME_SUB
    ///     CHAR_OCTET_LENGTH
    ///     ORDINAL_POSITION
    ///     IS_NULLABLE
    ///     USER_DATA_TYPE
    /// </summary>
    class ULColumnsMetadataSource : IMetadataSource
    {
        #region Fields

        /// <summary>
        /// Supported data types.
        /// </summary>
        private readonly List<ColumnInfo> m_Columns = new List<ColumnInfo>();

        /// <summary>
        /// Is fetching underway.
        /// </summary>
        private bool m_IsFetching = false;

        /// <summary>
        /// The current row in this source.
        /// </summary>
        private int m_Current = 0;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="log">The logger to use for this metadata source.</param>
        public ULColumnsMetadataSource(ILogger log)
        {
            LogUtilities.LogFunctionEntrance(log, log);

            Log = log;

            InitializeData();
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// The logger to use for this metadata source.
        /// </summary>
        private ILogger Log
        {
            get;
            set;
        }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Close the metadata source's internal cursor. After this method is called, GetMetadata()
        /// and MoveToNextRow() will not be called again.
        /// </summary>
        public void CloseCursor()
        {
            LogUtilities.LogFunctionEntrance(Log);
            m_IsFetching = false;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting 
        /// unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            CloseCursor();
        }

        /// <summary>
        /// Fills in out_data with the data for a given column in the current row.
        /// </summary>
        /// <param name="columnTag">The column to retrieve data from.</param>
        /// <param name="offset">The number of bytes in the data to skip before copying.</param>
        /// <param name="maxSize">The maximum number of bytes of data to return.</param>
        /// <param name="out_data">The data to be returned.</param>
        /// <returns>True if there is more data in the column; false otherwise.</returns>
        public bool GetMetadata(
            MetadataSourceColumnTag columnTag,
            long offset,
            long maxSize,
            out object out_data)
        {
            LogUtilities.LogFunctionEntrance(Log, columnTag, offset, maxSize, "out_data");
            switch (columnTag)
            {
                case MetadataSourceColumnTag.CATALOG_NAME:
                {
                    out_data = m_Columns[m_Current].m_TableCatalog;
                    return false;
                }

                case MetadataSourceColumnTag.SCHEMA_NAME:
                {
                    out_data = m_Columns[m_Current].m_TableSchema;
                    return false;
                }

                case MetadataSourceColumnTag.TABLE_NAME:
                {
                    out_data = m_Columns[m_Current].m_TableName;
                    return false;
                }

                case MetadataSourceColumnTag.COLUMN_NAME:
                {
                    out_data = m_Columns[m_Current].m_ColumnName;
                    return false;
                }

                case MetadataSourceColumnTag.DATA_TYPE:
                {
                    out_data = (short)m_Columns[m_Current].m_DataType;
                    return false;
                }

                case MetadataSourceColumnTag.DATA_TYPE_NAME:
                {
                    out_data = TypeUtilities.GetTypeName(m_Columns[m_Current].m_DataType).Substring(4);
                    return false;
                }

                case MetadataSourceColumnTag.COLUMN_SIZE:
                {
                    out_data = m_Columns[m_Current].m_ColumnSize;
                    return false;
                }

                case MetadataSourceColumnTag.BUFFER_LENGTH:
                {
                    out_data = m_Columns[m_Current].m_BufferLength;
                    return false;
                }

                case MetadataSourceColumnTag.DECIMAL_DIGITS:
                {
                    out_data = m_Columns[m_Current].m_DecimalDigits;
                    return false;
                }

                case MetadataSourceColumnTag.NUM_PREC_RADIX:
                {
                    SqlType sqlType = m_Columns[m_Current].m_DataType;

                    if (TypeUtilities.IsExactNumericType(sqlType) ||
                        TypeUtilities.IsIntegerType(sqlType) ||
                        TypeUtilities.IsApproximateNumericType(sqlType))
                    {
                        out_data = (short)10;
                    }
                    else
                    {
                        out_data = null;
                    }

                    return false;
                }

                case MetadataSourceColumnTag.NULLABLE:
                {
                    out_data = (short)m_Columns[m_Current].m_Nullable;
                    return false;
                }

                case MetadataSourceColumnTag.REMARKS:
                {
                    out_data = m_Columns[m_Current].m_Remarks;
                    return false;
                }

                case MetadataSourceColumnTag.COLUMN_DEF:
                {
                    out_data = m_Columns[m_Current].m_ColumnDef;
                    return false;
                }

                case MetadataSourceColumnTag.SQL_DATA_TYPE:
                {
                    out_data = (short)TypeUtilities.GetVerboseTypeFromConciseType(
                        m_Columns[m_Current].m_DataType);
                    return false;
                }

                case MetadataSourceColumnTag.SQL_DATETIME_SUB:
                {
                    short dateTimeSub = TypeUtilities.GetIntervalCodeFromConciseType(
                        m_Columns[m_Current].m_DataType);

                    if (0 == dateTimeSub)
                    {
                        out_data = null;
                    }
                    else
                    {
                        out_data = dateTimeSub;
                    }

                    return false;
                }

                case MetadataSourceColumnTag.CHAR_OCTET_LENGTH:
                {
                    if (TypeUtilities.IsCharacterOrBinaryType(m_Columns[m_Current].m_DataType))
                    {
                        out_data = m_Columns[m_Current].m_CharOctetLength;
                    }
                    else
                    {
                        out_data = null;
                    }

                    return false;
                }

                case MetadataSourceColumnTag.ORDINAL_POSITION:
                {
                    out_data = m_Current + 1;
                    return false;
                }

                case MetadataSourceColumnTag.IS_NULLABLE:
                {
                    if (Nullability.Nullable == m_Columns[m_Current].m_Nullable)
                    {
                        out_data = "YES";
                    }
                    else
                    {
                        out_data = "NO";
                    }

                    return false;
                }

                case MetadataSourceColumnTag.USER_DATA_TYPE:
                {
                    out_data = Constants.UDT_STANDARD_SQL_TYPE;
                    return false;
                }

                default:
                {
                    throw ExceptionBuilder.CreateException(
                        Properties.Resources.METADATA_COLUMN_NOT_FOUND,
                        columnTag.ToString());
                }
            }
        }

        /// <summary>
        /// Indicates that the cursor should be moved to before the first row.
        /// </summary>
        /// <returns>True if there are more rows; false otherwise.</returns>
        public bool MoveToBeforeFirstRow()
        {
            LogUtilities.LogFunctionEntrance(Log);
            m_IsFetching = true;
            m_Current = 0;

            return m_Current < m_Columns.Count;
        }

        /// <summary>
        /// Indicates that the cursor should be moved to the next row.
        /// </summary>
        /// <returns>True if there are more rows; false otherwise.</returns>
        public bool MoveToNextRow()
        {
            LogUtilities.LogFunctionEntrance(Log);
            if (m_IsFetching)
            {
                m_Current++;
            }
            else
            {
                m_IsFetching = true;
                m_Current = 0;
            }            

            return m_Current < m_Columns.Count;
        }

        /// <summary>
        /// Initializes the list of columns for the hardcoded Person table.
        /// </summary>
        private void InitializeData()
        {
            LogUtilities.LogFunctionEntrance(Log);

            // First column in the Person table: Name
            ColumnInfo colInfo = new ColumnInfo();
            colInfo.m_TableCatalog = OPlusDriver.UltraLight.UL_CATALOG;
            colInfo.m_TableSchema = OPlusDriver.UltraLight.UL_SCHEMA;
            colInfo.m_TableName = OPlusDriver.UltraLight.UL_TABLE;
            colInfo.m_ColumnName = "Name";
            colInfo.m_DataType = SqlType.WVarChar;
            colInfo.m_ColumnSize = 100;
            colInfo.m_BufferLength = 100;
            colInfo.m_DecimalDigits = 0;
            colInfo.m_Nullable = Nullability.Nullable;
            colInfo.m_Remarks = "Name column remarks";
            colInfo.m_ColumnDef = null;
            colInfo.m_CharOctetLength = 100;
            colInfo.m_OrdinalPosition = 1;
            m_Columns.Add(colInfo);

            // Second column in the Person table: Integer
            colInfo = new ColumnInfo();
            colInfo.m_TableCatalog = OPlusDriver.UltraLight.UL_CATALOG;
            colInfo.m_TableSchema = OPlusDriver.UltraLight.UL_SCHEMA;
            colInfo.m_TableName = OPlusDriver.UltraLight.UL_TABLE;
            colInfo.m_ColumnName = "Integer";
            colInfo.m_DataType = SqlType.Integer;
            colInfo.m_ColumnSize = 10;
            colInfo.m_BufferLength = 4;
            colInfo.m_DecimalDigits = 0;
            colInfo.m_Nullable = Nullability.Nullable;
            colInfo.m_Remarks = "Integer column remarks";
            colInfo.m_ColumnDef = null;
            colInfo.m_CharOctetLength = 0;
            colInfo.m_OrdinalPosition = 2;
            m_Columns.Add(colInfo);

            // Third column in the Person table: Numeric
            colInfo = new ColumnInfo();
            colInfo.m_TableCatalog = OPlusDriver.UltraLight.UL_CATALOG;
            colInfo.m_TableSchema = OPlusDriver.UltraLight.UL_SCHEMA;
            colInfo.m_TableName = OPlusDriver.UltraLight.UL_TABLE;
            colInfo.m_ColumnName = "Numeric";
            colInfo.m_DataType = SqlType.Numeric;
            colInfo.m_ColumnSize = 4;
            colInfo.m_BufferLength = 6;
            colInfo.m_DecimalDigits = 1;
            colInfo.m_Nullable = Nullability.Nullable;
            colInfo.m_Remarks = "Numeric column remarks";
            colInfo.m_ColumnDef = null;
            colInfo.m_CharOctetLength = 0;
            colInfo.m_OrdinalPosition = 3;
            m_Columns.Add(colInfo);
        }

        #endregion // Methods
    }
}
