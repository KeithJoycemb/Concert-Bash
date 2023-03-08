using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdBar : MonoBehaviour
{
    public GameObject crowdBar;
    public float crowdRespect;
    public float drunkLevel;
    public float currentDrunkLevel;
    public bool playable;

    // Start is called before the first frame update
    void Start()
    {
        crowdBar = GetComponent<GameObject>();
        crowdRespect = 50f;
        drunkLevel = 50f;
        currentDrunkLevel = 10;
        playable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDrunkLevel==drunkLevel)
        {
            crowdRespect -=10;
        }
        if(currentDrunkLevel==drunkLevel+10)
        {
            crowdRespect -= 20;
        }
         if(currentDrunkLevel==drunkLevel+20)
        {
            crowdRespect -= 30;
        }
         if(currentDrunkLevel==drunkLevel+30)
        {
            crowdRespect -= 40;
        }
        if(currentDrunkLevel==drunkLevel+40)
        {
            crowdRespect -= 50;
        }

        if(crowdRespect==0)
        {
            playable = false;
            onCrowdZero();
        }
    }
    private void onCrowdZero()
    {
        Debug.Log("You have lost crowd control! Please reset!!");
    }
}
