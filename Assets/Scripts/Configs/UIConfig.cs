using Configs.Abstractions;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(order = 0, fileName = nameof(UIConfig), menuName = "Frosty/Configs/" + nameof(UIConfig))]
    public class UIConfig : ScriptableObject, IUIConfig
    {
        public float DefaultTouchForce => defaultTouchForce;
        [SerializeField] private float defaultTouchForce = 0.5f;
    }
}