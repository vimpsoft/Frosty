using Configs.Abstractions;
using UI.Model.Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Random = UnityEngine.Random;

namespace UI.Presenter
{
    public class SnowflakesPresenter : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly SnowflakePresenter.Pool snowflakesPool = null;
        [Inject] private readonly IUIConfig uiConfig = null;
        [Inject] private readonly ISnowflakesModel model = null;
        [Inject] private readonly ITouchEffectPowerModel touchEffectPowerModel = null;
        
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
                model.RegisterSnowflake(snowflakesPool.Spawn());
            }
        }

        public async void OnPointerClick(PointerEventData eventData)
        {
            var snowflakesAffected = await model.GetSnowflakesInRadius(eventData.position, touchEffectPowerModel.TouchForce);
            foreach (var snowflakePresenter in snowflakesAffected)
            {
                model.UnregisterSnowflake(snowflakePresenter);
                snowflakePresenter.Hide(() => snowflakesPool.Despawn(snowflakePresenter));
            }
        }
    }
}
