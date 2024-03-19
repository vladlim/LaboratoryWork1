using UnityEngine;
using UnityEngine.UIElements;

namespace Core
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private ProductionBuilding[] productionBuildings;
        private ResourceBank resourceBank;

        private void Start()
        {
            resourceBank = gameManager.GetResourceBank();
        }

        public void UpgradeProductionLevel(string resourceName)
        {
            switch (resourceName)
            {
                case "Humans":
                    productionBuildings[0].IncreaseProductionLevel();
                    break;
                case "Food":
                    productionBuildings[1].IncreaseProductionLevel();
                    break;
                case "Wood":
                    productionBuildings[2].IncreaseProductionLevel();
                    break;
                case "Stone":
                    productionBuildings[3].IncreaseProductionLevel();
                    break;
                case "Gold":
                    productionBuildings[4].IncreaseProductionLevel();
                    break;
                default: break;
            }
        }
    }
}