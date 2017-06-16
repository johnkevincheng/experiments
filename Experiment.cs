using System;
using System.Collections.Generic;
using Experiments.ResultPublishers;

namespace Experiments
{
    /// <summary>
    /// Represents an experiment sandbox to test against a control value.
    /// </summary>
    public static class Experiment
    {
        /// <summary>
        /// Run an experiment to test candidates against an established control value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="controlValue"></param>
        /// <param name="candidatesValue"></param>
        /// <returns>The control value.</returns>
        public static T Do<T>(String name, IControl<T> controlValue, params ICandidate<T>[] candidatesValue)
        {
            T control = controlValue.Value;
            foreach (var candidateValue in candidatesValue)
            {
                ExperimentResult result;
                try
                {
                    T candidate = candidateValue.Value;
                    result = new ExperimentResult(name, controlValue.Name, candidateValue.Name, Equals(control, candidate));
                }
                catch (Exception ex)
                {
                    result = new ExperimentResult(name, controlValue.Name, candidateValue.Name, ex);
                }

                foreach (var publisher in ResultPublishers)
                    publisher.ProcessResult(result);
            }

            return control;
        }

        private static readonly List<IResultPublisher> ResultPublishers = new List<IResultPublisher>();

        /// <summary>
        /// Sets whether the IResultPublisher processors should suppress successful results. New processors attached after this are not affected.
        /// </summary>
        public static Boolean PublishOnlyFailedExperiments
        {
            set
            {
                foreach (var experimentResult in ResultPublishers)
                    experimentResult.PublishOnlyFailedExperiments = value;
            }
        }

        /// <summary>
        /// Clears all IResultPublisher. All results will not be displayed.
        /// </summary>
        public static void ClearPublishers()
        {
            ResultPublishers.Clear();
        }

        /// <summary>
        /// Attach an IResultPublisher to process results of experiments to an output destination. Extend IResultPublisher to define custom output destinations.
        /// </summary>
        /// <param name="resultPublisher"></param>
        public static void AttachPublisher(IResultPublisher resultPublisher)
        {
            if (resultPublisher != null)
                ResultPublishers.Add(resultPublisher);
        }
    }
}
