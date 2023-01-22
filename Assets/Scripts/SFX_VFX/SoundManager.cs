using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> punches = new List<AudioClip>();
    public List<AudioClip> slashes = new List<AudioClip>();
    public List<AudioClip> laserShots = new List<AudioClip>();
    public List<AudioClip> whoosh = new List<AudioClip>();
    public List<AudioClip> bulletImpacts = new List<AudioClip>();
    public List<AudioClip> armorHit = new List<AudioClip>();


    public AudioClip arrowShot;
    public AudioClip arrowDamage;

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    public void PlayPunch()
    {
        source.PlayOneShot(punches[Random.Range(0, punches.Count)]);
    }

    public void PlayArmorHit()
    {
        source.PlayOneShot(armorHit[Random.Range(0, armorHit.Count)]);
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
    public void PlayBulletImpact()
    {
        source.PlayOneShot(bulletImpacts[Random.Range(0, bulletImpacts.Count)]);
    }

}
