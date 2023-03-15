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

        // Start is called before the first frame update
        void Start()
        {
            enemyPerformer = GetComponent<GameObject>();
            player = GetComponent<GameObject>();
            disruptionbar = GetComponent<GameObject>();
            hitEnemy = false;
            disruption = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (hitEnemy)
            {
                //disruption += 15;
                //disruptiveBar.SetDisruption(disruption);
            }


            else
                Debug.Log("Did not hit DJ!!");

            if (disruption == 100)
                performerOff(disruption);


        }

        private void performerOff(float disruption)
        {
            disruption = 0f;
            enemyPerformer.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            hitEnemy = true;
        }
        private void IncrementWithDrink(float drunkLevel)
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
                disruption *= 2;
            }
        }
    }
}
