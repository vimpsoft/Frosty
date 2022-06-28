using Configs.Abstractions;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace UI.Presenter
{
    public class SnowflakesPresenter : MonoBehaviour
    {
        [Inject] private readonly SnowflakePresenter.Pool snowflakesPool = null;
        [Inject] private readonly IUIConfig uiConfig = null;
        
        [SerializeField] private Transform snowflakesHolder;
        
        private void Update()
        {
            var mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError($"Main camera is null! Snowflakes cancelled.");
                return;
            }
            
            var newSnowflakesCount = Mathf.RoundToInt(uiConfig.FreezingSpeed * Time.deltaTime);
            //Добавим немного случайности
            newSnowflakesCount += Mathf.RoundToInt(Random.Range(-newSnowflakesCount * uiConfig.FreezingSpeedRandomness, newSnowflakesCount * uiConfig.FreezingSpeedRandomness));

            for (var i = 0; i < newSnowflakesCount; i++)
            {
                snowflakesPool.Spawn();
            }
        }
    }
}
