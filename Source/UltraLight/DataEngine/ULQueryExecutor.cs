// ==========================================================================================================================
//  @file ULQueryExecutor.cs
// 
//  Implementation of the interface IQueryExecutor.
// 
//  Copyright (C) 2011-2023 Simba Technologies Incorporated.
// ==========================================================================================================================

using System.Collections.Generic;
using Simba.DotNetDSI;
using Simba.DotNetDSI.DataEngine;

namespace OPlusDriver.DataEngine
{
    /// <summary>
    /// UltraLight query executor implementation.
    /// </summary>
    public class ULQueryExecutor : IQueryExecutor
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="log">The logger to use for the query executor.</param>
        /// <param name="isSelect">True if the query is a SELECT query.</param>
        /// <param name="isParameterized">True if the query has parameters.</param>
        public ULQueryExecutor(ILogger log, bool isSelect, bool isParameterized)
        {
            // TODO(ODBC) #07: Implement a QueryExecutor.
            // TODO(ADO)  #09: Implement a QueryExecutor.
            LogUtilities.LogFunctionEntrance(log, log, isSelect, isParameterized);
            Log = log;

            // Create the prepared results.
            Results = new List<IResult>();
            if (isSelect)
            {
                Results.Add(new ULPersonTable(Log));
            }
            else
            {
                Results.Add(new DSIRowCountResult(12));
            }

            // Create the parameters.
            // TODO(ODBC) #08: Provide parameter information.
            // TODO(ADO)  #10: Provide parameter information.
            ParameterMetadata = ULExecutorUtilities.CreateParameters(Log, isParameterized);
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Get or set the logger to use for the query executor.
        /// </summary>
        private ILogger Log
        {
            get;
            set;
        }

        /// <summary>
        /// Get the metadata for the parameters in the query.
        /// 
        /// The position of the ParameterMetadata in the list should match their position in the
        /// query, so parameter 1 should be at position 0, parameter 2 should be at position 1, 
        /// etc...
        /// 
        /// Even if parameters are named instead of numbered, this positioning should be 
        /// maintained. Positions should correlate with the parameter numbers in the 
        /// ParameterMetadata objects.
        /// </summary>
        public IList<ParameterMetadata> ParameterMetadata
        {
            get;
            private set;
        }

        /// <summary>
        /// Get the results of query.
        /// 
        /// Results may be fetched before query execution but only column metadata will be available
        /// if possible. Other operations should throw exceptions.
        /// </summary>
        public IList<IResult> Results
        {
            get;
            private set;
        }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Cancels the currently executing query.
        /// </summary>
        public void CancelExecute()
        {
            LogUtilities.LogFunctionEntrance(Log);

            // It's not possible to cancel execution in the UltraLight driver, as there is no actual
            // 'execution', everything is already hardcoded within the driver.
        }

        /// <summary>
        /// Clears any state that might have been set by CancelExecute().
        /// </summary>
        public void ClearCancel()
        {
            LogUtilities.LogFunctionEntrance(Log);
        }

        /// <summary>
        /// Clears any parameter data that has been pushed down using PushParamData(). The 
        /// ULQueryExecutor may be re-used for execution following this call.
        /// </summary>
        public void ClearPushedParamData()
        {
            LogUtilities.LogFunctionEntrance(Log);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting 
        /// unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            // Do nothing.
        }

        /// <summary>
        /// Executes the prepared statement for each parameter set provided, or once if there are
        /// no parameters supplied.
        /// </summary>
        /// <param name="contexts">
        ///     Holds ExecutionContext objects and parameter metadata for execution. There is one
        ///     ExecutionContext for each parameter set to be executed.
        /// </param>
        /// <param name="warningListener">Used to post warnings about the execution.</param>
        public void Execute(ExecutionContexts contexts, IWarningListener warningListener)
        {
            // TODO(ODBC) #09: Implement Query Execution.
            // TODO(ADO)  #11: Implement Query Execution.
            LogUtilities.LogFunctionEntrance(Log, contexts, warningListener);

            // The contexts argument provides access to the parameters that were not pushed.
            // Statement execution is a 3 step process:
            //      1. Serialize all input parameters into a form that can be consumed by the data 
            //         source. If your data source does not support parameter streaming for pushed
            //         parameters, then you will need to re-assemble them from your parameter cache.
            //         See PushParamData.
            //      2. Send the Execute() message.
            //      3. Retrieve all output parameters from the server and update the contexts with
            //         their contents.
            ULExecutorUtilities.ExecuteParameters(Log, (0 != ParameterMetadata.Count), contexts);

            // No action needs to be taken here since the results are static and encapsulated in
            // ULPersonTable and DSISimpleRowCountResult.
        }

        /// <summary>
        /// Informs the ULQueryExecutor that all parameter values which will be pushed have been 
        /// pushed prior to query execution. After the next Execute() call has finished, this pushed 
        /// parameter data may be cleared from memory, even if the Execute() call results in an 
        /// exception being thrown.
        /// 
        /// The first subsequent call to PushParamData() should behave as if the executor has a 
        /// clear cache of pushed parameter values.
        /// </summary>
        public void FinalizePushedParamData()
        {
            LogUtilities.LogFunctionEntrance(Log);
        }

        /// <summary>
        /// Pushes part of an input parameter value down before execution. This value
        /// should be stored for use later during execution.
        /// 
        /// This method may only be called once for any parameter set/parameter
        /// combination (a "parameter cell") where the parameter has a
        /// non-character/binary data type.
        /// 
        /// For parameters with character or binary data types, this method may be
        /// called multiple times for the same parameter set/parameter combination.
        /// The multiple parts should be concatenated together in order to get the
        /// complete value. For character data, the byte array passed down for one
        /// chunk may NOT necessarily be a complete UTF-8 string representation.
        /// There may be bytes provided in the previous or subsequent chunk to
        /// complete codepoints at the start and/or end.
        /// 
        /// The metadata passed in should be taken notice of because it may not match
        /// metadata supplied by a possible call to GetMetadataForParameters(), as
        /// the ODBC consumer is able to change parameter metadata themselves.
        /// </summary>
        /// <param name="parameterSet">The parameter set the pushed value belongs to.</param>
        /// <param name="value">The pushed parameter value, including metadata for identification.</param>
        public void PushParamData(int parameterSet, ParameterInputValue value)
        {
            LogUtilities.LogFunctionEntrance(Log, parameterSet, value);

            // This is where pushed parameter data would be cached, to be used during execution.
        }

        #endregion // Methods
    }
}
