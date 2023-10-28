
namespace Kelontong.Events.Minigames
{
    struct OnEggAdded
    {
        public float eggWeight;
        public int eggAmount;

        public OnEggAdded(float weight, int amount) {
            eggAmount = amount;
            eggWeight = weight;
        }
    }
}