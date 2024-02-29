// ==========================================================================================================================
//  @file ULDotNetConnection.cs
// 
//  Implementation of the classes required for Simba.NET for branding.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.Collections.Generic;
using System.Data.Common;

using Simba.DotNetDSI;
using Simba.ADO.Net;

namespace Simba.UltraLight
{
    class ULDotNetConnection : Simba.ADO.Net.SConnection
    {
        #region Properties

        /// <summary>
        /// Get the DbProviderFactory for this connection.
        /// </summary>
        protected override DbProviderFactory DbProviderFactory
        {
            get
            {
                return ULDotNetFactory.Instance;
            }
        }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// Must be implemented by derived class using CloneFrom() to clone the 
        /// ULDotNetConnection portion of object.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public override object Clone()
        {
            ULDotNetConnection connection = new ULDotNetConnection();
            connection.CloneFrom(this);
            return connection;
        }

        /// <summary>
        /// Creates and returns a ULDotNetCommand object associated with the current connection.
        /// </summary>
        /// <returns>A new DbCommand object.</returns>
        protected override DbCommand CreateDbCommand()
        {
            ULDotNetCommand command = new ULDotNetCommand();
            command.Connection = this;

            return command;
        }

        /// <summary>
        /// Creates and returns a DSIDriver Instance.
        /// </summary>
        /// <param name="connectionSettings">The settings from the connection.</param>
        /// <returns>The new IDriver instance.</returns>
        protected override IDriver CreateDSIDriverInstance(
            Dictionary<string, object> connectionSettings)
        {
            // TODO(ADO)  #02: Construct the IDriver instance.
            return new ULDriver();
        }

        /// <summary>
        /// Returns branding of the registry keys to load configuration from.
        /// </summary>
        /// <returns>The branding section for the registry.</returns>
        protected override string GetConfigurationBranding()
        {
            // TODO(ODBC) #12: Set the branding of the registry key to read configuration from.
            // TODO(ADO)  #14: Set the branding of the registry key to read configuration from.
            return @"Simba\DotNetUltraLight";
        }

        /// <summary>
        /// Get any custom schemas that are supplied by the connection.
        /// 
        /// This function works in conjunction with IDataEngine.MakeNewCustomMetadataResult().
        /// Override MakeNewCustomMetadataResult() in the data engine to return any custom schemas.
        /// </summary>
        /// <returns>The collection of custom schema information.</returns>
        protected override ICollection<SchemaInfo> GetCustomSchemas()
        {
            // SAMPLE: Here is where you list information custom schemas available to the ADO.Net application.
            // To enable data retrieval for these schemas, implement IDataEngine.MakeNewCustomMetadataResult()
            // to return a result set for this schema name.

            // Create a sample custom schema.
            SchemaInfo info = new SchemaInfo();
            info.m_Name = UltraLight.UL_CUSTOMMETADATARESULT;
            info.m_NumIdentifierParts = 1;
            info.m_Restrictions = new List<RestrictionInfo>();

            // Add a sample restriction, although it won't be enforced.
            RestrictionInfo restriction = new RestrictionInfo();
            restriction.m_Name = "SampleRestriction";
            restriction.m_Default = "Column1";
            info.m_Restrictions.Add(restriction);

            // Return the information for the custom schema.
            IList<SchemaInfo> schemas = new List<SchemaInfo>();
            schemas.Add(info);
            return schemas;
        }

        #endregion // Methods
    }
}
