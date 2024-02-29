// ==========================================================================================================================
//  @file ULConnectionDialog.cs
// 
//  Implementation of the class ULConnectionDialog.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OPlusDriver
{
    /// <summary>
    /// Sample implementation of the business logic for a SQLDriverConnect dialog in a C# driver.
    /// </summary>
    public partial class ULConnectionDialog : Form
    {
        /// <summary>
        /// The connection settings to populate.
        /// </summary>
        private Dictionary<string, object> m_ConnectionSettings;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="connectionSettings">Settings map to initialize GUI fields with and to
        /// populate with GUI values when the user presses OK.</param>
        /// <param name="disableOptional">Indicates that optional fields should be disabled</param>
        public ULConnectionDialog(
            Dictionary<string, object> connectionSettings, 
            bool disableOptional)
        {
            InitializeComponent();

            m_ConnectionSettings = connectionSettings;

            if (connectionSettings.ContainsKey("UID"))
            {
                object uid = connectionSettings["UID"];
                if (uid != null)
                {
                    UIDField.Text = uid.ToString();
                }
            }

            if (connectionSettings.ContainsKey("PWD"))
            {
                object pwd = connectionSettings["PWD"];
                if (pwd != null)
                {
                    PWDField.Text = pwd.ToString();
                }
            }

            if (disableOptional)
            {
                // There are no optional settings or GUI elements in DotNetUltraLight,
                // but if there were, the controls could be disabled here.
            }
        }

        /// <summary>
        /// Event handler for the OK button. Updates the connection settings and
        /// closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ULOKButton_Click(object sender, EventArgs e)
        {
            m_ConnectionSettings["UID"] = UIDField.Text;
            m_ConnectionSettings["PWD"] = PWDField.Text;
            this.Dispose();
        }

        /// <summary>
        /// Event handler for the Cancel button. Closes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ULCancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
