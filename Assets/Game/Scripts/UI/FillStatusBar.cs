using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public CrowdLevel crowd;
    public DrinkLevel drink;
    public DistrubanceLevel distrubance;
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValueCrowd = crowd.currentCrowd / crowd.maxCrowd;
        slider.value = fillValueCrowd;
        float fillValueDrink = drink.currentDrink / drink.maxDrink;
        slider.value = fillValueDrink;
        float fillValueDisturb = distrubance.currentDisturb/ distrubance.maxDisturb;
        slider.value = fillValueDisturb;

    }
}
