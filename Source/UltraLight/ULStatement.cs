// ==========================================================================================================================
//  @file ULStatement.cs
// 
//  Implementation of the class ULStatement.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using OPlusDriver.DataEngine;
using Simba.DotNetDSI;
using Simba.DotNetDSI.DataEngine;

namespace OPlusDriver
{
    /// <summary>
    /// UltraLight DSIStatement implementation class.
    /// </summary>
    class ULStatement : Simba.DotNetDSI.DSIStatement
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="connection">The parent connection.</param>
        public ULStatement(ULConnection connection) : base(connection)
        {
            LogUtilities.LogFunctionEntrance(Connection.Log, connection);
        }

        #endregion // Constructor

        #region Methods

        /// <summary>
        /// Factory method for creating IDataEngines.
        /// </summary>
        /// <returns>A new IDataEngine instance.</returns>
        public override IDataEngine CreateDataEngine()
        {
            LogUtilities.LogFunctionEntrance(Connection.Log);
            return new ULDataEngine(this);
        }

        #endregion // Methods
    }
}
