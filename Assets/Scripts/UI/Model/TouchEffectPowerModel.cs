using Configs.Abstractions;
using JetBrains.Annotations;
using UI.Model.Abstractions;
using Zenject;

namespace UI.Model
{
    [UsedImplicitly]
    public class TouchEffectPowerModel : ITouchEffectPowerModel
    {
        public float TouchForce { get; private set; }

        [Inject]
        private void Init(IUIConfig uiConfig)
        {
            TouchForce = uiConfig.DefaultTouchForce;
        }
        
        public void UpdateTouchForce(float newValue)
        {
            TouchForce = newValue;
        }
    }
}