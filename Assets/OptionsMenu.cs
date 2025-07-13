using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        optionsPanel.SetActive(false); // Start hidden

        if (AudioManager.Instance != null)
        {
            musicSlider.value = AudioManager.Instance.musicVolume;
            sfxSlider.value = AudioManager.Instance.sfxVolume;
        }

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.Instance?.SetMusicVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager.Instance?.SetSFXVolume(volume);
    }
}
