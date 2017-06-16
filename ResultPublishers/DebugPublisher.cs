using System;
using System.Diagnostics;

namespace Experiments.ResultPublishers
{
    public class DebugPublisher : IResultPublisher
    {
        public Boolean PublishOnlyFailedExperiments { get; set; }

        public void ProcessResult(ExperimentResult result)
        {
            if (result.Matched)
            {
                if (!PublishOnlyFailedExperiments)
                    Debug.WriteLine(String.Format("Experiment \"{0}\": Candidate \"{1}\" matched the control value \"{2}\".", result.ExperimentName, result.CandidateName, result.ControlName));
            }
            else
            {
                if (result.Exception != null)
                    Debug.WriteLine(String.Format("Experiment \"{0}\": Candidate \"{1}\" threw an exception.", result.ExperimentName, result.CandidateName));
                else
                    Debug.WriteLine(String.Format("Experiment \"{0}\": Candidate \"{1}\" does not match the control value \"{2}\".", result.ExperimentName, result.CandidateName, result.ControlName));
            }

        }
    }
}
