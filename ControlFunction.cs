using System;

namespace Experiments
{
    /// <summary>
    /// Represents a control function for ICandidate values to be tested against.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>Func is a .NET 3.5 feature, so this class needs to be removed to downgrade to earlier versions of .NET.</remarks>
    public class ControlFunction<T> : IControl<T>
    {
        public ControlFunction(String name, Func<T> functionCall)
        {
            _functionAction = functionCall;
            Name = name;
        }

        private readonly Func<T> _functionAction;

        public T Value
        {
            get
            {
                return _functionAction();
            }
        }

        public String Name { get; private set; }
    }
}
