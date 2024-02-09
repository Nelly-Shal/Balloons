using Balloons.Features.Actions;
using UnityEngine;

namespace Balloons.Features.GameControllers
{
    /// <summary>
    /// Обновляет текущий счет при клики на объект
    /// </summary>
    public class OnTargetClickUpdatScore : OnTargetClickCallback
    {
        [SerializeField]
        protected int currentScore = 0;

        protected override void UpdateOnTargtCallback() => currentScore++;
    }
}
