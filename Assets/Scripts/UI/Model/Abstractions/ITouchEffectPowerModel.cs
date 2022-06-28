namespace UI.Model.Abstractions
{
    public interface ITouchEffectPowerModel
    {
        float TouchForce { get; }
        void UpdateTouchForce(float newValue);
    }
}