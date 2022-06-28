using System.Collections.Generic;
using Configs.Abstractions;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(order = 0, fileName = nameof(SnowflakesConfig), menuName = "Frosty/Configs/" + nameof(SnowflakesConfig))]
    public class SnowflakesConfig : ScriptableObject, ISnowflakesConfig
    {
        public IReadOnlyList<Sprite> AllTheFlakes => snowflakeSprites;
        [SerializeField] private List<Sprite> snowflakeSprites;
    }
}
