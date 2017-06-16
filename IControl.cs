
using System;

namespace Experiments
{
    public interface IControl<T>
    {
        T Value { get; }
        String Name { get; }
    }
}
