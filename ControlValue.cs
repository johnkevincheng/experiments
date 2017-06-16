using System;

namespace Experiments
{
    /// <summary>
    /// Represents a control value for ICandidate values to be tested against.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ControlValue<T> : IControl<T>
    {
        public ControlValue(String name, T value)
        {
            Value = value;
            Name = name;
        }

        public T Value { get; private set; }
        public String Name { get; private set; }
    }
}
