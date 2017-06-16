using System;

namespace Experiments
{
    /// <summary>
    /// Represents the results of an experiment.
    /// </summary>
    public class ExperimentResult
    {
        /// <summary>
        /// Gets or sets the name of the experiment.
        /// </summary>
        public String ExperimentName { get; private set; }

        /// <summary>
        /// Gets or sets the name of the IControl value.
        /// </summary>
        public String ControlName { get; private set; }

        /// <summary>
        /// Gets or sets the name of the ICandidate value.
        /// </summary>
        public String CandidateName { get; private set; }

        /// <summary>
        /// Gets or sets whether the experiment results matched.
        /// </summary>
        public Boolean Matched { get; private set; }

        /// <summary>
        /// Gets or sets any exceptions encountered while processing the ICandidate value.
        /// </summary>
        public Exception Exception { get; private set; }

        public ExperimentResult(String experimentName, String controlName, String candidateName, Boolean matched)
        {
            ExperimentName = experimentName;
            ControlName = controlName;
            CandidateName = candidateName;
            Matched = matched;
        }

        public ExperimentResult(String experimentName, String controlName, String candidateName, Exception exception)
        {
            ExperimentName = experimentName;
            ControlName = controlName;
            CandidateName = candidateName;
            Matched = false;
            Exception = exception;
        }
    }
}
