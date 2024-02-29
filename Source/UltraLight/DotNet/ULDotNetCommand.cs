// ==========================================================================================================================
//  @file ULDotNetCommand.cs
// 
//  Implementation of the classes required for Simba.NET for branding.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.Data.Common;

namespace Simba.UltraLight
{
    class ULDotNetCommand : Simba.ADO.Net.SCommand
    {
        #region Methods

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// Must be implemented by derived class using CloneFrom() to clone the 
        /// ULDotNetCommand portion of object.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public override object Clone()
        {
            ULDotNetCommand command = new ULDotNetCommand();
            command.CloneFrom(this);
            return command;
        }

        /// <summary>
        /// Creates a new instance of a DbParameter object.
        /// </summary>
        /// <returns>A new DbParameter object.</returns>
        protected override DbParameter CreateDbParameter()
        {
            return new ULDotNetParameter();
        }

        #endregion // Methods
    }
}
