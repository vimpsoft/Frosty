using Configs;
using Configs.Abstractions;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private SnowflakesConfig snowflakesConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<IUIConfig>().FromInstance(uiConfig);
            Container.Bind<ISnowflakesConfig>().FromInstance(snowflakesConfig);
        }
    }
}
