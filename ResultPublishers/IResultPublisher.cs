using System;

namespace Experiments.ResultPublishers
{
    public interface IResultPublisher
    {
        Boolean PublishOnlyFailedExperiments { get; set; }
        void ProcessResult(ExperimentResult result);
    }
}
