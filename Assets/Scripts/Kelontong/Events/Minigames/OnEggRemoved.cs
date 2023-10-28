
namespace Kelontong.Events.Minigames
{
    struct OnEggRemoved
    {
        public float eggWeight;
        public int eggAmount;

        public OnEggRemoved(float weight, int amount) {
            eggAmount = amount;
            eggWeight = weight;
        }
    }
}