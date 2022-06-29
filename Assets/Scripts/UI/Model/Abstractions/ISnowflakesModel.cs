using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Presenter;
using UnityEngine;

namespace UI.Model.Abstractions
{
    public interface ISnowflakesModel
    {
        void RegisterSnowflake(SnowflakePresenter snowflake);
        void UnregisterSnowflake(SnowflakePresenter snowflake);
        Task<IEnumerable<SnowflakePresenter>> GetSnowflakesInRadius(Vector2 screenPoint, float radius);
    }
}