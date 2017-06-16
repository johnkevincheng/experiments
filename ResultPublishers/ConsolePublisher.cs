using System;

namespace Experiments.ResultPublishers
{
    public class ConsolePublisher : IResultPublisher
    {
        public Boolean PublishOnlyFailedExperiments { get; set; }

        public void ProcessResult(ExperimentResult result)
        {
            if (result.Matched)
            {
                if (!PublishOnlyFailedExperiments)
                    Console.WriteLine("Experiment \"{0}\": Candidate \"{1}\" matched the control value \"{2}\".", result.ExperimentName, result.CandidateName, result.ControlName);
            }
            else
            {
                if (result.Exception != null)
                    Console.WriteLine("Experiment \"{0}\": Candidate \"{1}\" threw an exception.", result.ExperimentName, result.CandidateName);
                else
                    Console.WriteLine("Experiment \"{0}\": Candidate \"{1}\" does not match the control value \"{2}\".", result.ExperimentName, result.CandidateName, result.ControlName);
            }
        }
    }
}
