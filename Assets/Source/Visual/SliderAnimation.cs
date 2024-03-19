using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    public class SliderAnimation : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private AnimationCurve statusCurve;
        [SerializeField] private float fillDuration = 2f;
        private bool isAnimating;

        public void ChangeFillDuration(float newDuration)
        {
            fillDuration = newDuration;
        }

        public void StartAnimation()
        {
            if (!isAnimating)
            {
                StartCoroutine(AnimateSlider());
            }
        }

        private IEnumerator AnimateSlider()
        {
            isAnimating = true;
            float elapsedTime = 0f;

            while (elapsedTime < fillDuration)
            {
                elapsedTime += Time.deltaTime;
                slider.value = statusCurve.Evaluate(elapsedTime / fillDuration);
                yield return null;
            }

            slider.value = 0f;
            isAnimating = false;
        }
    }
}
