// ==========================================================================================================================
//  @file UltraLight.cs
// 
//  Implementation of the class UltraLight.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

namespace OPlusDriver
{
    /// <summary>
    /// A static class containing UltraLight driver constants.
    /// </summary>
    internal static class UltraLight
    {
        /// <summary>
        /// The connection key to use when looking up the UID in the connection string.
        /// </summary>
        public const string UL_UID_KEY = "UID";

        /// <summary>
        /// The connection key to use when looking up the PWD in the connection string.
        /// </summary>
        public const string UL_PWD_KEY = "PWD";

        /// <summary>
        /// The connection key to use when looking up the LNG in the connection string.
        /// </summary>
        public const string UL_LNG_KEY = "LNG";

        /// <summary>
        /// The faked catalog for the hardcoded data.
        /// </summary>
        public const string UL_CATALOG = "FakeCatalog";

        /// <summary>
        /// The faked schema for the hardcoded data.
        /// </summary>
        public const string UL_SCHEMA = "FakeSchema";

        /// <summary>
        /// The faked table for the hardcoded data.
        /// </summary>
        public const string UL_TABLE = "Person";

        /// <summary>
        /// The faked custom metadata result for the hardcoded data.
        /// </summary>
        public const string UL_CUSTOMMETADATARESULT = "SampleCustomSchema";
    }
}
