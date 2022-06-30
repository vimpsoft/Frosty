using Configs.Abstractions;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(order = 0, fileName = nameof(UIConfig), menuName = "Frosty/Configs/" + nameof(UIConfig))]
    public class UIConfig : ScriptableObject, IUIConfig
    {
        public float DefaultTouchForce => defaultTouchForce;
        [SerializeField] private float defaultTouchForce = 0.5f;
        public int SnowflakesPoolWarmUpCount => snowflakesPoolWarmUpCount;
        [SerializeField] private int snowflakesPoolWarmUpCount = 10000;
        public float FreezingSpeed => freezingSpeed;
        [SerializeField, Tooltip("Сколько снежинок в кадр появляется")] private float freezingSpeed = 1;
        public float SnowflakesTweenTime => snowflakesTweenTime;
        [SerializeField, Tooltip("Время появления/исчезновения снежинки")] private float snowflakesTweenTime = 0.75f;
    }
}