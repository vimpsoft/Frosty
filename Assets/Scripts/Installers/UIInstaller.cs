using UI.Model;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TouchEffectPowerModel>().AsSingle();
        }
    }
}
