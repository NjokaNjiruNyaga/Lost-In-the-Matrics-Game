using UnityEngine;

public class DataFragmentSound : MonoBehaviour
{
    public AudioClip pickupSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (AudioManager.Instance != null && pickupSound != null)
            {
                AudioManager.Instance.PlaySoundEffect(pickupSound);
            }

            
            Destroy(gameObject);
        }
    }
}

