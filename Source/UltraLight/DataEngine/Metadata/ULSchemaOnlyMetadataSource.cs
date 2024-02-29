// ==========================================================================================================================
//  @file ULSchemaOnlyMetadataSource.cs
// 
//  Implementation of the class ULSchemaOnlyMetadataSource.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;

using Simba.DotNetDSI;
using Simba.DotNetDSI.DataEngine;

namespace OPlusDriver.DataEngine
{
    /// <summary>
    /// UltraLight sample metadata table for schemas.
    /// 
    /// This source contains the following output columns as defined by SimbaEngine:
    ///     SCHEMA_NAME
    /// </summary>
    class ULSchemaOnlyMetadataSource : IMetadataSource
    {
        #region Fields

        /// <summary>
        /// Is fetching underway.
        /// </summary>
        private bool m_IsFetching = false;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="log">The logger to use for this metadata source.</param>
        public ULSchemaOnlyMetadataSource(ILogger log)
        {
            LogUtilities.LogFunctionEntrance(log, log);
            Log = log;
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
                case MetadataSourceColumnTag.SCHEMA_NAME:
                {
                    out_data = OPlusDriver.UltraLight.UL_SCHEMA;
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
            m_IsFetching = false;
            return true;
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
                return false;
            }

            m_IsFetching = true;
            return true;
        }

        #endregion // Methods
    }
}
