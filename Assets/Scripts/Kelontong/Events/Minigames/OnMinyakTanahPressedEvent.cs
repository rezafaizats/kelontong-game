

using Kelontong.Views;
using UnityEngine.UI;

namespace Kelontong.Events.Minigames
{
    struct OnMinyakTanahPressedEvent
    {
        public float fillRate;

        public OnMinyakTanahPressedEvent(float rate) {
            fillRate = rate;
        }
    }
}