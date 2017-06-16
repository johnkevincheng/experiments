using System;

namespace Experiments
{
    /// <summary>
    /// Represents a value to be tested against an IControl value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CandidateValue<T> : ICandidate<T>
    {
        public CandidateValue(String name, T value)
        {
            Value = value;
            Name = name;
        }

        public T Value { get; private set; }
        public String Name { get; private set; }
    }
}
