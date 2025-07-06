using UnityEngine;

public class CollectFragment : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MasterLevelInfo.DataCount += value;
            Destroy(gameObject);
        }
    }
}

