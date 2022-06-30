using System;
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

        private Tween currentTween;

        private void Init(Sprite sprite)
        {
            image.sprite = sprite;
            viewTransform.Rotate(Vector3.forward, Random.Range(0f, 360f));
            viewTransform.localScale = Vector3.one * Mathf.Sin(Mathf.PI / 4f + Mathf.PI / 2f * Random.Range(0f, 1f));

            selfTransform.anchorMin = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
            selfTransform.anchorMax = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));

            currentTween = DOVirtual.Color(Color.clear, Color.white, uiConfig.SnowflakesTweenTime, value => image.color = value);
        }

        public void Hide(Action onComplete)
        {
            if (currentTween != null)
            {
                currentTween.Kill();
            }
            var randomDelay = Random.Range(0f, 1f); //Оптимизация, чтобы не все объекты сразу дестроились и не было сразу одного большого спайка
            var initialColor = image.color;
            currentTween = DOVirtual.Color(initialColor, Color.clear, uiConfig.SnowflakesTweenTime,
                    value => image.color = value)
                .SetDelay(randomDelay)
                .OnComplete(() =>
                {
                    currentTween = null;
                    onComplete();
                });
        }
        
        [UsedImplicitly]
        public class Pool : MonoMemoryPool<SnowflakePresenter>
        {
            [Inject] private readonly IReadOnlyList<Sprite> availableSprites = null;

            protected override void OnSpawned(SnowflakePresenter item)
            {
                base.OnSpawned(item);
                
                item.Init(availableSprites[Random.Range(0, availableSprites.Count)]);
            }
        }
    }
}
