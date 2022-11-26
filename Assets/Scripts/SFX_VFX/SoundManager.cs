using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum Sound
    {
        None,
        Whoosh,
        Punch,
        Slash,
        LaserShot
    }

    public AudioSource source;

    public List<AudioClip> punches = new List<AudioClip>();
    public List<AudioClip> slashes = new List<AudioClip>();
    public List<AudioClip> laserShots = new List<AudioClip>();
    public List<AudioClip> whoosh = new List<AudioClip>();


    public void PlayAfterTime(Sound sound, float time)
    {
        switch (sound)
        {
            case Sound.Punch:
                Invoke(nameof(PlayPunch), time);
                return;
            case Sound.Slash:
                Invoke(nameof(PlaySlash), time);
                return;
            case Sound.LaserShot:
                Invoke(nameof(PlayLaserShot), time);
                return;
            case Sound.Whoosh:
                Invoke(nameof(PlayWhoosh), time);
                return;
        }
    }


    public void PlayPunch()
    {
        source.PlayOneShot(punches[Random.Range(0, punches.Count)]);
    }

    public void PlaySlash()
    {
        source.PlayOneShot(slashes[Random.Range(0, slashes.Count)]);
    }

    public void PlayLaserShot()
    {
        source.PlayOneShot(laserShots[Random.Range(0, laserShots.Count)]);
    }
    public void PlayWhoosh()
    {
        source.PlayOneShot(whoosh[Random.Range(0, whoosh.Count)]);
    }

}
