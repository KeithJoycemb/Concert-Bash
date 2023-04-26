using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongController : MonoBehaviour
{

    [Header("List of Tracks")]
    [SerializeField] private Track[] audioTracks;
    private int trackIndex;
    

    [Header("Text UI")]
    [SerializeField] private Text trackTextUI;

    private AudioSource speakerAudioSource;
    private void Start()
    {
        speakerAudioSource = GetComponent<AudioSource>();

        trackIndex = 0;
        speakerAudioSource.clip = audioTracks[trackIndex].trackAudioClip;

        trackTextUI.text = audioTracks[trackIndex].name;
    }

    public void SkipForwardButton()
    {
        trackIndex++;
        UpdateTrack(trackIndex);

    }

    public void SkipBackwardButton()
    {
        trackIndex--;
        UpdateTrack(trackIndex);
    }

    void UpdateTrack(int index)
    {
        speakerAudioSource.clip = audioTracks[index].trackAudioClip;
        trackTextUI.text = audioTracks[index].name;
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
