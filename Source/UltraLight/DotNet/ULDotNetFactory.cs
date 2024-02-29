// ==========================================================================================================================
//  @file ULDotNetFactory.cs
// 
//  Implementation of the classes required for Simba.NET for branding.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.Data.Common;

namespace Simba.UltraLight
{
    /// <summary>
    /// ULDotNet factory class for exposing DotNet classes as ULDotNet branded classes.
    /// </summary>
    public sealed class ULDotNetFactory : Simba.ADO.Net.SFactory
    {
        #region Fields

        /// <summary>
        /// The singleton instance of the SFactory.
        /// </summary>
        public static readonly ULDotNetFactory Instance = new ULDotNetFactory();

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Default constructor. Made private as this is a singleton.
        /// </summary>
        private ULDotNetFactory()
        {
            // Do nothing.
        }

        #endregion // Constructor

        #region Methods

        // TODO(ADO)  #01: Rename the Simba.ADO.Net sub-classes:
        //      Simba.ADO.Net.SFactory
        //      Simba.ADO.Net.SCommand
        //      Simba.ADO.Net.SCommandBuilder
        //      Simba.ADO.Net.SConnection
        //      Simba.ADO.Net.SConnectionStringBuilder
        //      Simba.ADO.Net.SDataAdapter
        //      Simba.ADO.Net.SParameter

        /// <summary>
        /// Create a new instance of the DbConnection class.
        /// </summary>
        /// <returns>A new instance of the DbConnection class.</returns>
        public override DbCommand CreateCommand()
        {
            return new ULDotNetCommand();
        }

        /// <summary>
        /// Create a new instance of the DbCommandBuilder class.
        /// </summary>
        /// <returns>A new instance of the DbCommandBuilder class.</returns>
        public override DbCommandBuilder CreateCommandBuilder()
        {
            return new ULDotNetCommandBuilder();
        }

        /// <summary>
        /// Create a new instance of the DbConnection class.
        /// </summary>
        /// <returns>A new instance of the DbConnection class.</returns>
        public override DbConnection CreateConnection()
        {
            return new ULDotNetConnection();
        }

        /// <summary>
        /// Create a new instance of the DbConnectionStringBuilder class.
        /// </summary>
        /// <returns>A new instance of the DbConnectionStringBuilder class.</returns>
        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new ULDotNetConnectionStringBuilder();
        }

        /// <summary>
        /// Create a new instance of the DbDataAdapter class.
        /// </summary>
        /// <returns>A new instance of the DbDataAdapter class.</returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new ULDotNetDataAdapter();
        }

        /// <summary>
        /// Create a new instance of the DbParameter class.
        /// </summary>
        /// <returns>A new instance of the DbParameter class.</returns>
        public override DbParameter CreateParameter()
        {
            return new ULDotNetParameter();
        }

        #endregion // Methods
    }
}
