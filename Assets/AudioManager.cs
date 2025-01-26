using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource Mus;
    public AudioSource WaterAmb;
    public AudioSource BadConn;

    public List<AudioSource> RandAmb;
    public List<AudioSource> ConnFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayMusic()
    {
        Mus.Play();
        WaterAmb.Play();
    }

    public void StopMusic()
    {
        Mus.Stop();
        WaterAmb.Stop();
    }

    public void PlayConnSound(int index)
    {
        ConnFX[index - 1 % 5].Play();
    }

    public void PlayBadConnSound()
    {
        BadConn.Play();
    }
}
