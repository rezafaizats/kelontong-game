

namespace Kelontong.Events.Minigames
{
    struct OnSubmitTelurEvent
    {
        public int eggTotal;
        public float eggWeight;

        public OnSubmitTelurEvent(int eggTotal, float eggWeight) {
            this.eggTotal = eggTotal;
            this.eggWeight = eggWeight;
        }
    }
}
    