using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public void PlayClickSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonSound();
        }
    }
}
