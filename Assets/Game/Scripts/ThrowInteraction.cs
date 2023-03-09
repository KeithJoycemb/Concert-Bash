using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class ThrowInteraction : MonoBehaviour
    {
        public GameObject enemyPerformer;
        public GameObject player;
        public bool hitEnemy;
        public float disruption;
        public GameObject disruptionbar;
        public GameObject drunkBar;
        public float drunkLevel;

        // Start is called before the first frame update
        void Start()
        {
            hitEnemy = false;
            disruption = 0f;
            drunkLevel = drunkBar.GetComponent<disruptiveBar>().getBarValue();
        }

        // Update is called once per frame
        void Update()
        {
            if (hitEnemy)
            {
                disruption += 15;
                if (drunkLevel==0f)
                {
                    
                    disruptionbar.GetComponent<disruptiveBar>().SetDisruption(disruption);
                }
                else
                {
                    IncrementWithDrink(disruption);
                    disruptionbar.GetComponent<disruptiveBar>().SetDisruption(disruption);
                }
                
            }


            else
                Debug.Log("Did not hit DJ!!");

            if (disruption == 100)
                performerOff(disruption);


        }

        private void performerOff(float disruption)
        {
            disruption = 100f;
            enemyPerformer.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag=="Performer1")
            hitEnemy = true;
        }
        private void IncrementWithDrink(float disruption)
        {
            if(drunkLevel==10)
            {
                disruption *= 1.2f;
            }
            if(drunkLevel>10 && drunkLevel<40)
            {
                disruption *= 1.5f;
            }
            if(drunkLevel>40)
            {
                disruption *= 2f;
            }
        }
    }
}
