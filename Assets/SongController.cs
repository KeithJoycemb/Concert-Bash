using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController : MonoBehaviour
{
    private AudioSource speakerAudioSource;

    private void Start()
    {
        speakerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        speakerAudioSource.Play();
    }

    public void PauseAudio()
    {
        speakerAudioSource.Pause();
    }

    public void StopAudio()
    {
        speakerAudioSource.Stop();
    }
}
