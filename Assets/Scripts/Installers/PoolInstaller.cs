using Configs.Abstractions;
using UI.Presenter;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PoolInstaller : MonoInstaller
    {
        [Inject] private readonly IUIConfig uiConfig = null;
        [Inject] private readonly ISnowflakesConfig snowflakesConfig = null;
        
        [SerializeField] private SnowflakePresenter snowflakePrefab;
        [SerializeField] private Transform snowflakesHolder;
        
        public override void InstallBindings()
        {
            Container.BindMemoryPool<SnowflakePresenter, SnowflakePresenter.Pool>()
                .WithInitialSize(uiConfig.SnowflakesPoolWarmUpCount)
                .WithFactoryArguments(snowflakesConfig.AllTheFlakes)
                .FromComponentInNewPrefab(snowflakePrefab)
                .UnderTransform(snowflakesHolder);
        }
    }
}
