using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private const int START_HUMANS_COUNTER = 10;
        private const int START_FOOD_COUNTER = 5;
        private const int START_WOOD_COUNTER = 5;

        private ResourceBank resourceBank;

        private void Awake()
        {
          resourceBank = new ResourceBank(START_HUMANS_COUNTER, START_FOOD_COUNTER, START_WOOD_COUNTER);
        }

        public ResourceBank GetResourceBank()
        {
            return resourceBank;
        }
    }
}