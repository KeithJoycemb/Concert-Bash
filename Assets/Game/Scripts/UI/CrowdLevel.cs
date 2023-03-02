using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdLevel : MonoBehaviour
{
    public int maxCrowd = 5;
    public int currentCrowd;
    // Start is called before the first frame update
    void Start()
    {
        currentCrowd = maxCrowd;
    }
}
