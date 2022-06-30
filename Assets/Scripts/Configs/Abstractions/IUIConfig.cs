namespace Configs.Abstractions
{
    internal interface IUIConfig
    {
        float DefaultTouchForce { get; }
        int SnowflakesPoolWarmUpCount { get; }
        float FreezingSpeed { get; }
        float SnowflakesTweenTime { get; }
    }
}