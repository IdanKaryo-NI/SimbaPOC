// ==========================================================================================================================
//  @file ULDriver.cs
// 
//  Implementation of the class ULDriver.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using Simba.DotNetDSI;

namespace OPlusDriver
{
    /// <summary>
    /// UltraLight DSIDriver implementation class.
    ///
    /// This driver exposes simple hard-coded data.
    /// </summary>
    public class ULDriver : Simba.DotNetDSI.DSIDriver
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public ULDriver()
        {
            LogUtilities.LogFunctionEntrance(Log);
            SetDriverPropertyValues();

            // SAMPLE: Adding resource managers here allows you to localize the Simba DotNetDSI and/or ADO.Net components.
            Simba.DotNetDSI.Properties.Resources.ResourceManager.AddResourceManager(
                new System.Resources.ResourceManager("Simba.UltraLight.Properties.SimbaDotNetDSI", GetType().Assembly));
        }

        #endregion // Constructor

        #region Properties

        // TODO(ODBC) #11: Set the vendor name, which will be prepended to error messages.
        // TODO(ADO)  #13: Set the vendor name, which will be prepended to error messages.

        /*
         * NOTE: We do not set the vendor name here on purpose, because the default vendor name is 'Simba'.
         * The code below shows how to set the vendor name.
        /// <summary>
        /// Get the driver-wide vendor name. This property should always return the same value
        /// for a given IDriver implementation.
        /// </summary>
        public override System.String VendorName
        {
            get
            {
                return "DotNetUltraLight";
            }
        }
         */

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Factory method for creating IEnvironments.
        /// </summary>
        /// <returns>A new IEnvironment instance.</returns>
        public override Simba.DotNetDSI.IEnvironment CreateEnvironment()
        {
            LogUtilities.LogFunctionEntrance(Log);
            return new ULEnvironment(this);
        }

        /// <summary>
        /// Overrides some of the default driver properties.
        /// </summary>
        private void SetDriverPropertyValues()
        {
            // TODO(ODBC) #02: Set the driver properties.
            // TODO(ADO)  #03: Set the driver properties.
            SetProperty(DriverPropertyKey.DSI_DRIVER_DRIVER_NAME, "OPlusDriver");
        }

        #endregion // Methods
    }
}
