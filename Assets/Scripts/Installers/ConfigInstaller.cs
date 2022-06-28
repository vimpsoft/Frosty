using Configs;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private UIConfig uiConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<IUIConfig>().FromInstance(uiConfig);
        }
    }
}
