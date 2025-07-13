using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip buttonClickSound;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float musicVolume = 0.7f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.volume = musicVolume;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayButtonSound()
    {
        if (sfxSource != null && buttonClickSound != null)
        {
            sfxSource.PlayOneShot(buttonClickSound, sfxVolume);
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip, sfxVolume);
        }
    }

    // ✅ NEW: Called by the Options Menu
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        if (sfxSource != null)
        {
            sfxSource.volume = sfxVolume;
        }
    }
}
