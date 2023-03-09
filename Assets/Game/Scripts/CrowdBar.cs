using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class CrowdBar : MonoBehaviour
    {
        public GameObject crowdBar, drunkBar;
        public GameObject player;
        public float crowdRespect;
        public float drunkThresh;
        public float currentDrunkLevel;
        public bool playable;

        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<GameObject>();
            crowdRespect = 50f;
            drunkThresh = 50f;
            currentDrunkLevel = drunkBar.GetComponent<disruptiveBar>().getBarValue();
            playable = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (currentDrunkLevel == drunkThresh)
            {
                crowdRespect -= 10;
            }
            if (currentDrunkLevel == drunkThresh + 10)
            {
                crowdRespect -= 20;
            }
            if (currentDrunkLevel == drunkThresh + 20)
            {
                crowdRespect -= 30;
            }
            if (currentDrunkLevel == drunkThresh + 30)
            {
                crowdRespect -= 40;
            }
            if (currentDrunkLevel == drunkThresh + 40)
            {
                crowdRespect -= 50;
            }

            if (crowdRespect == 0)
            {
                playable = false;
                onCrowdZero();
            }
        }
        private void onCrowdZero()
        {
            Debug.Log("You have lost crowd control! Please reset!!");
            player.SetActive(false);

             
        }
    }
}
