using Configs.Abstractions;
using UI.Model.Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace UI.Presenter
{
    public class SnowflakesPresenter : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly SnowflakePresenter.Pool snowflakesPool = null;
        [Inject] private readonly IUIConfig uiConfig = null;
        [Inject] private readonly ISnowflakesModel model = null;
        [Inject] private readonly ITouchEffectPowerModel touchEffectPowerModel = null;
        
        private void Update()
        {
            for (var i = 0; i < uiConfig.FreezingSpeed; i++)
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
