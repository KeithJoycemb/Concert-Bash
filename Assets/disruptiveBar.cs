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

        public void SetMaxDisruption(float disruption)
        {
            slider.maxValue = 100;
            slider.value = disruption;

            fill.color = gradient.Evaluate(1f);
        }

        public void SetDisruption(float disruption)
        {
            slider.value = disruption;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
