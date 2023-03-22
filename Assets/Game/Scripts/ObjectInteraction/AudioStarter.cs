using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AudioStarter : MonoBehaviour
    {
        AudioSource typeAudio;
        bool typePlay;
        bool mute;

        private void Start()
        {
            typeAudio = GetComponent<AudioSource>();
            typePlay = false;
            mute = typeAudio.mute;


        }
        private void Update()
        {
            if (typePlay == true && mute == false)
            {
                typeAudio.mute = false;
            }
       
                
        }
        private void OnTriggerEnter(Collider other)
        {
            typePlay = true;
            mute = false;

        }
    }
}
