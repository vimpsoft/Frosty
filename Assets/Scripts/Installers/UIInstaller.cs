using UI.Model;
using UI.Model.Abstractions;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITouchEffectPowerModel>().To<TouchEffectPowerModel>().AsSingle();
        }
    }
}
