using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    public class disruptiveBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;

        public void SetMaxDisruption(float barValue)
        {
            slider.maxValue = 100;
            slider.value = barValue;

            fill.color = gradient.Evaluate(1f);
        }

        public void SetDisruption(float barValue)
        {
            slider.value = barValue;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
        public float getBarValue()
        {
            return slider.value;
        }
    }
}
