using System.Collections.Generic;
using Configs.Abstractions;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace UI.Presenter
{
    public class SnowflakePresenter : MonoBehaviour
    {
        [Inject] private readonly IUIConfig uiConfig = null;
        
        [SerializeField] private Transform viewTransform;
        [SerializeField] private Image image;
        [SerializeField] private RectTransform selfTransform;

        private void Init(Sprite sprite)
        {
            image.sprite = sprite;
            viewTransform.Rotate(Vector3.forward, Random.Range(0f, 360f));
            viewTransform.localScale = Vector3.one * Mathf.Cos(Mathf.PI / 2f * Random.Range(0f, 1f));

            selfTransform.anchorMin = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
            selfTransform.anchorMax = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
            selfTransform.anchoredPosition = Vector2.zero;

            DOVirtual.Color(Color.clear, Color.white, uiConfig.SnowflakesTweenTime, value => image.color = value);
        }
        
        [UsedImplicitly]
        public class Pool : MonoMemoryPool<SnowflakePresenter>
        {
            private readonly IReadOnlyList<Sprite> availableSprites;
            
            public Pool(IReadOnlyList<Sprite> availableSprites)
            {
                this.availableSprites = availableSprites;
            }

            protected override void OnSpawned(SnowflakePresenter item)
            {
                base.OnSpawned(item);
                
                item.Init(availableSprites[Random.Range(0, availableSprites.Count)]);
            }
        }
    }
}
