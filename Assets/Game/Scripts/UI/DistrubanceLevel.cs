using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrubanceLevel : MonoBehaviour
{
    public int maxDisturb = 5;
    public int currentDisturb;
    // Start is called before the first frame update
    void Start()
    {
        currentDisturb = maxDisturb;
    }
}
