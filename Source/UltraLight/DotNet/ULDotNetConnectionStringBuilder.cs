// ==========================================================================================================================
//  @file ULDotNetConnectionStringBuilder.cs
// 
//  Implementation of the classes required for Simba.NET for branding.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.ComponentModel;
using System.Data.Common;

using Simba.DotNetDSI;

namespace Simba.UltraLight
{
    class ULDotNetConnectionStringBuilder : Simba.ADO.Net.SConnectionStringBuilder
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public ULDotNetConnectionStringBuilder()
        {
            // Do nothing.
        }

        #endregion // Constructors

        #region Properties

        // TODO(ADO)  #04: Create the properties for the connection string keys.

        [Category("Connection Settings")]
        [DisplayName(UltraLight.UL_UID_KEY)]
        [RefreshProperties(RefreshProperties.All)]
        public string UserName
        {
            get
            {
                object outValue;
                if (this.TryGetValue(UltraLight.UL_UID_KEY, out outValue))
                {
                    return outValue as string;
                }

                return "";
            }
            set
            {
                this[UltraLight.UL_UID_KEY] = value;
            }
        }

        [Category("Connection Settings")]
        [PasswordPropertyText(true)]
        [DisplayName(UltraLight.UL_PWD_KEY)]
        [RefreshProperties(RefreshProperties.All)]
        public string Password
        {
            get
            {
                object outValue;
                if (this.TryGetValue(UltraLight.UL_PWD_KEY, out outValue))
                {
                    return outValue as string;
                }

                return "";
            }
            set
            {
                this[UltraLight.UL_PWD_KEY] = value;
            }
        }

        [Category("Connection Settings")]
        [DisplayName(UltraLight.UL_LNG_KEY)]
        [RefreshProperties(RefreshProperties.All)]
        public string Language
        {
            get
            {
                object outValue;
                if (this.TryGetValue(UltraLight.UL_LNG_KEY, out outValue))
                {
                    return outValue as string;
                }

                return "";
            }
            set
            {
                this[UltraLight.UL_LNG_KEY] = value;
            }
        }

        #endregion // Properties
    }
}
