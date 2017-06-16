
using System;

namespace Experiments
{
    public interface ICandidate<T>
    {
        T Value { get; }
        String Name { get; }
    }
}
