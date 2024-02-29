// ==========================================================================================================================
//  @file ULDotNetParameter.cs
// 
//  Implementation of the classes required for Simba.NET for branding.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;

namespace Simba.UltraLight
{
    class ULDotNetParameter : Simba.ADO.Net.SParameter
    {
        #region Methods

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// Must be implemented by derived class using CloneFrom() to clone the 
        /// ULDotNetParameter portion of object.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public override object Clone()
        {
            ULDotNetParameter parameter = new ULDotNetParameter();
            parameter.CloneFrom(this);
            return parameter;
        }

        #endregion // Methods
    }
}
