using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkLevel : MonoBehaviour
{
    public int maxDrink = 5;
    public int currentDrink;
    // Start is called before the first frame update
    void Start()
    {
        currentDrink= maxDrink;
    }
}
