using Configs;
using JetBrains.Annotations;
using Zenject;

namespace UI.Model
{
    [UsedImplicitly]
    public class TouchEffectPowerModel
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