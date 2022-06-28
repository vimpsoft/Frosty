using System.Collections.Generic;
using UnityEngine;

namespace Configs.Abstractions
{
    public interface ISnowflakesConfig
    {
        IReadOnlyList<Sprite> AllTheFlakes { get; }
    }
}