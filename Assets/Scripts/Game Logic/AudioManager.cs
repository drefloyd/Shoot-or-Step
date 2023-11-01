using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [Header("--------Audio Source------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip---------")]
    public AudioClip menuMusic;
    public AudioClip bullet;
    public AudioClip moveSound;
    public AudioClip gunshotSound;
    public AudioClip explosion;
    public AudioClip powerUpPickup;
    public AudioClip diceRoll;
    public AudioClip background;
    public AudioClip takeDamage;
    bool m_Play;
    bool m_ToggleChange;
    private void Start()
    {
        PlayMusic(menuMusic);
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip,20);
    }
    public void PlayMusic(AudioClip clip)
    {
       
        MusicSource.PlayOneShot(clip);
       
        
    }
    public void Update()
    {

    }
}
