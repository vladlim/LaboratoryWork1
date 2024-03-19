using System;
using System.Collections;
using UnityEngine;
using Presentation;

namespace Core
{
    public class ProductionBuilding : MonoBehaviour
    {
        [SerializeField] private int _productionValue;
        [SerializeField] private GameResource _productionResource;
        [SerializeField] private GameManager _manager;
        [SerializeField] private SliderAnimation _sliderAnimation;

        private const float START_PRODUCTION_TIME = 2;
        private float _productionTime = START_PRODUCTION_TIME;
        private readonly ObservableInt _productionLevel = new(1);
        public Action<float> OnProductionTimeChanged { get; set; }
        private ResourceBank _bank;
        private bool _inProduction;

        public ObservableInt GetProductionLevel()
        {
            return _productionLevel;
        }

        private void Start()
        {
            OnProductionTimeChanged += _sliderAnimation.ChangeFillDuration;
            _bank = _manager.GetResourceBank();
            CalculateProductionTime();
        }

        private void CalculateProductionTime()
        {
            _productionTime = START_PRODUCTION_TIME * (1 - _productionLevel.Value / 100) / (_productionLevel.Value + 1);
        }

        public void IncreaseProductionLevel()
        {
            ++_productionLevel.Value;
            CalculateProductionTime();
            OnProductionTimeChanged.Invoke(_productionTime);
        }

        public void StartProduction()
        {
            if (!_inProduction)
            {
                StartCoroutine(FinishProduction());
            }
        }

        private IEnumerator FinishProduction()
        {
            _inProduction = true;
            yield return new WaitForSeconds(_productionTime);
            _bank.ChangeResource(_productionResource, _productionValue);
            _inProduction = false;
        }
    }
}