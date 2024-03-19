using System.Collections.Generic;

namespace Core
{
    public class ResourceBank
    {

        readonly Dictionary<GameResource, ObservableInt> resourceBank;
        public ResourceBank(int humans = 0, int food = 0, int wood = 0, int stone = 0, int gold = 0)
        {
            resourceBank = new Dictionary<GameResource, ObservableInt>();
            AddResource(GameResource.Humans, humans);
            AddResource(GameResource.Food, food);
            AddResource(GameResource.Wood, wood);
            AddResource(GameResource.Stone, stone);
            AddResource(GameResource.Gold, gold);
        }

        private void AddResource(GameResource resource, int amount)
        {
            resourceBank.Add(resource, new ObservableInt(amount));
        }

        public void ChangeResource(GameResource resource, int value)
        {
            resourceBank[resource].Value += value;
        }

        public ObservableInt GetResource(GameResource resource)
        {
            return resourceBank[resource];
        }
    }
}