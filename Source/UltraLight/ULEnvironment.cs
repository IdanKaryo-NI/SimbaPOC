// ==========================================================================================================================
//  @file ULEnvironment.cs
// 
//  Implementation of the class ULEnvironment.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using Simba.DotNetDSI;

namespace OPlusDriver
{
    /// <summary>
    /// UltraLight DSIEnvironment implementation class.
    /// </summary>
    public class ULEnvironment : Simba.DotNetDSI.DSIEnvironment
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="driver">The parent IDriver.</param>
        public ULEnvironment(IDriver driver) : base(driver)
        {
            LogUtilities.LogFunctionEntrance(Driver.Log, driver);
        }

        /// <summary>
        /// Factory method for creating IConnections.
        /// </summary>
        /// <returns>A new IConnection instance.</returns>
        public override Simba.DotNetDSI.IConnection CreateConnection()
        {
            LogUtilities.LogFunctionEntrance(Driver.Log);
            return new ULConnection(this);
        }
    }
}
