using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public void Play1()
    {
        src.volume = 1f;
        src.clip = sfx1;
        src.pitch = UnityEngine.Random.Range(1f, 1.8f);
        src.Play();
    }

    public void Play2()
    {
        src.volume = 0.8f;
        src.clip = sfx2;
        src.pitch = UnityEngine.Random.Range(0.5f, 0.9f);
        src.Play();
    }

    public void Play3()
    {
        src.volume = 0.3f;
        src.clip = sfx3;
        src.Play();
    }
}
