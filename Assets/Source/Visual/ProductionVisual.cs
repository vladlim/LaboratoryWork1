using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;

namespace Presentation
{
    public class ProductionVisual : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> productionTexts;
        [SerializeField] private List<ProductionBuilding> buildings;

        private void Start()
        {
            foreach (var building in buildings)
            {
                int index = buildings.IndexOf(building);
                building.GetProductionLevel().OnValueChanged += newValue =>
                {
                    UpdateProductionText(index, newValue);
                };

                UpdateProductionText(index, building.GetProductionLevel().Value);
            }
        }

        private void UpdateProductionText(int index, int newValue)
        {
            if (index >= 0 && index < productionTexts.Count)
            {
                productionTexts[index].text = newValue.ToString();
            }
        }
    }
}