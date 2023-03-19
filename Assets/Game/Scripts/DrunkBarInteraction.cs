using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkBarInteraction : MonoBehaviour
{
    public GameObject drunkBar;
    public GameObject player;
    public float drunkLevel;
    public GameObject bottle;
    public float nBottle;

    // Start is called before the first frame update
    void Start()
    {
        drunkLevel = 0f;
        nBottle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (bottle.GetComponent<Collider>().isTrigger)
        {
            nBottle += 1;
            drunkLevel += 10;
        }
        if (drunkLevel == 100)
        {
            endGame();
        }
       
    }
    private void endGame()
    {
        Debug.Log("You have Lost! Please Reset!");
    }
  
}