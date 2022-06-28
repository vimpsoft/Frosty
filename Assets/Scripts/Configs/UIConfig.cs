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
        [SerializeField, Tooltip("Сколько снежинок в секунду в среднем появляется")] private float freezingSpeed = 100;
        public float FreezingSpeedRandomness => freezingSpeedRandomness;
        [SerializeField, Tooltip("Насколько может отклоняться среднее значение количества добавленных снежинок")] private float freezingSpeedRandomness = 0.3f;
        public float SnowflakesTweenTime => snowflakesTweenTime;
        [SerializeField, Tooltip("Время появления/исчезновения снежинки")] private float snowflakesTweenTime = 0.75f;
    }
}