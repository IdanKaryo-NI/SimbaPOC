// ==========================================================================================================================
//  @file ULExecutorUtilities.cs
// 
//  Implementation of the class ULExecutorUtilities.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System.Collections.Generic;
using Simba.DotNetDSI;
using Simba.DotNetDSI.DataEngine;

namespace OPlusDriver.DataEngine
{
    /// <summary>
    /// Helper class for dealing with parameters in a query executor.
    /// </summary>
    internal static class ULExecutorUtilities
    {
        #region Methods

        /// <summary>
        /// Create the parameters for the query executor, if needed.
        /// </summary>
        /// <param name="log">The logger to log to.</param>
        /// <param name="isParameterized">True if there are parameters; false otherwise.</param>
        /// <returns>The list of parameters for the query.</returns>
        internal static IList<ParameterMetadata> CreateParameters(ILogger log, bool isParameterized)
        {
            LogUtilities.LogFunctionEntrance(log, log, isParameterized);

            IList<ParameterMetadata> parameters = new List<ParameterMetadata>();

            if (isParameterized)
            {
                // There are parameters, so create three hardcoded parameters as an example. First
                // add an input-only parameter.
                ParameterMetadata paramMeta = new ParameterMetadata(
                    1,
                    ParameterDirection.Input,
                    TypeMetadataFactory.CreateTypeMetadata(SqlType.VarChar),
                    false);
                paramMeta.TypeMetadata.Length = 100;
                parameters.Add(paramMeta);

                // Add an input/output parameter.
                paramMeta = new ParameterMetadata(
                    2,
                    ParameterDirection.InputOutput,
                    TypeMetadataFactory.CreateTypeMetadata(SqlType.VarChar),
                    false);
                paramMeta.TypeMetadata.Length = 100;
                parameters.Add(paramMeta);

                // Add an output parameter.
                paramMeta = new ParameterMetadata(
                    3,
                    ParameterDirection.Output,
                    TypeMetadataFactory.CreateTypeMetadata(SqlType.VarChar),
                    false);
                paramMeta.TypeMetadata.Length = 100;
                parameters.Add(paramMeta);
            }

            return parameters;
        }

        /// <summary>
        /// Execute the parameters in the context.
        /// </summary>
        /// <param name="log">The logger to log to.</param>
        /// <param name="hasParameters">True if there are parameters to process in the contexts.</param>
        /// <param name="contexts">
        ///     Holds ExecutionContext objects and parameter metadata for execution. There is one
        ///     ExecutionContext for each parameter set to be executed.
        /// </param>
        internal static void ExecuteParameters(
            ILogger log, 
            bool hasParameters, 
            ExecutionContexts contexts)
        {
            LogUtilities.LogFunctionEntrance(log, log, hasParameters, contexts);

            foreach (ExecutionContext context in contexts)
            {
                if (!hasParameters)
                {
                    context.Succeeded = true;
                    continue;
                }

                // Place the input of the input parameter into the output parameter.
                ParameterInputValue input = context.Inputs[0];
                ParameterOutputValue output = context.Outputs[1];

                if (null == input.Data)
                {
                    // Null input -> null output.
                    output.Data = null;
                }
                else if (input.IsDefaultValue)
                {
                    // Default input -> "hello world"
                    output.Data = "Hello World";
                }
                else
                {
                    // Otherwise, just append twice the value of the input to the output.
                    output.Data = (input.Data as string);
                }

                // For the input/output parameter, append twice its current value.
                input = context.Inputs[1];
                output = context.Outputs[0];

                if (null == input.Data)
                {
                    output.Data = null;
                }
                else
                {
                    string inputStr = (input.Data as string);
                    output.Data = inputStr + inputStr;
                }

                context.Succeeded = true;
            }
        }

        #endregion // Methods
    }
}
