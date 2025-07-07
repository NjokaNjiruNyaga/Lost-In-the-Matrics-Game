using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource runAudio;

    public void StartRunning()
    {
        if (!runAudio.isPlaying)
            runAudio.Play();
    }

    public void StopRunning()
    {
        if (runAudio.isPlaying)
            runAudio.Stop();
        }
}
