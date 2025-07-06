using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the exit trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Player reached the exit!");

            MazeTimer timer = FindObjectOfType<MazeTimer>();
            if (timer != null)
            {
                timer.PlayerReachedExit();
            }
        }
    }
}
