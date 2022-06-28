using UI.Model;
using UI.Model.Abstractions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Presenter
{
    public class TouchEffectPowerPresenter : MonoBehaviour
    {
        [Inject] private readonly ITouchEffectPowerModel model = null;
        
        [SerializeField] private Slider slider;
    
        private void Start()
        {
            slider.value = model.TouchForce;
            slider.onValueChanged.AddListener(model.UpdateTouchForce);
        }
    }
}
