

using UnityEngine.UI;

namespace Kelontong.Events.Minigames
{
    struct OnMinyakTanahPressedEvent
    {
        public Button fillButton;

        public OnMinyakTanahPressedEvent(Button fillButton) {
            this.fillButton = fillButton;
        }
    }
}