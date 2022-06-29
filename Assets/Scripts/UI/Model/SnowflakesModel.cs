using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UI.Model.Abstractions;
using UI.Presenter;
using UnityEngine;

namespace UI.Model
{
    [UsedImplicitly]
    public class SnowflakesModel : ISnowflakesModel
    {
        private readonly List<Vector2> Positions = new ();
        private readonly List<SnowflakePresenter> Snowflakes = new ();

        public void RegisterSnowflake(SnowflakePresenter snowflake)
        {
            Snowflakes.Add(snowflake);
            
            Positions.Add(RectTransformToScreenSpace(snowflake.GetComponent<RectTransform>(), Camera.main));
            
            static Vector2 RectTransformToScreenSpace(RectTransform transform, Camera cam, bool cutDecimals = false)
            {
                var worldCorners = new Vector3[4];

                transform.GetWorldCorners(worldCorners);

                return new Rect(worldCorners[0].x,
                    worldCorners[0].y,
                    worldCorners[2].x - worldCorners[0].x,
                    worldCorners[2].y - worldCorners[0].y).center;
            }
        }

        public void UnregisterSnowflake(SnowflakePresenter snowflake)
        {
            var index = Snowflakes.IndexOf(snowflake);
            Snowflakes.RemoveAt(index);
            Positions.RemoveAt(index);
        }

        public async Task<IEnumerable<SnowflakePresenter>> GetSnowflakesInRadius(Vector2 screenPoint, float radius)
        {
            var screenRelativeRadius = radius * Screen.height * 0.5f;
            return await Task.Run(() => ComputeSnowflakesInRadius(screenPoint, screenRelativeRadius));
        }

        private IEnumerable<SnowflakePresenter> ComputeSnowflakesInRadius(Vector2 touchPoint, float radius)
        {
            var result = new List<SnowflakePresenter>();
            for (var i = 0; i < Positions.Count; i++)
            {
                var distance = Vector2.Distance(Positions[i], touchPoint);
                if (distance <= radius)
                {
                    result.Add(Snowflakes[i]);
                }
            }
            return result;
        }
    }
}
