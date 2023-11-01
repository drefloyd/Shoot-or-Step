using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [Header("--------Audio Source------")]
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip---------")]
    public AudioClip bullet;
    public AudioClip moveSound;
    public AudioClip gunshotSound;
    public AudioClip explosion;
    public AudioClip powerUpPickup;
    public AudioClip diceRoll;
    public AudioClip takeDamage;
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip,20);
    }

}
