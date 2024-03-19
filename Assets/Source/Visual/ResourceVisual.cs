using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace Presentation
{
    [Serializable]
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private List<TMP_Text> resourceTexts;

        private void Start()
        {
            ResourceBank resourceBank = gameManager.GetResourceBank();
            GameResource[] resources = (GameResource[])Enum.GetValues(typeof(GameResource));

            foreach (var resource in resources)
            {
                int index = (int)resource;
                var observableResource = resourceBank.GetResource(resource);

                observableResource.OnValueChanged += newValue => UpdateResourceVisual(index, newValue);
                UpdateResourceVisual(index, observableResource.Value);
            }
        }

        private void UpdateResourceVisual(int textIndex, int newValue)
        {
            if (textIndex >= 0 && textIndex < resourceTexts.Count)
            {
                resourceTexts[textIndex].text = newValue.ToString();
            }
            else
            {
                Debug.LogWarning($"Text index out of range: {textIndex}");
            }
        }
    }
}