using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    AudioSource audioS;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip pickUpClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        audioS = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip audio)
    {
        audioS.PlayOneShot(audio);
    }

    public void ChangeMusic(AudioClip audio)
    {
        audioS.clip = audio;
        audioS.Play();
    }
}
