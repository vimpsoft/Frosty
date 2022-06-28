using JetBrains.Annotations;

namespace UI.Model
{
    [UsedImplicitly]
    public class TouchEffectPowerModel
    {
        public float TouchForce { get; private set; }
        
        public void UpdateTouchForce(float newValue)
        {
            TouchForce = newValue;
        }
    }
}