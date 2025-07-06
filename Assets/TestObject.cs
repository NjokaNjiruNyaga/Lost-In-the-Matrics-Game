using UnityEngine;

public class TestDrop : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}

