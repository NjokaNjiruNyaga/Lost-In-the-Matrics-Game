using UnityEngine;

public class DataFragmentGlitch : MonoBehaviour
{
    public float flickerInterval = 0.3f;  // Time between flickers
    private float flickerTimer;
    private Renderer rend;
    private bool isVisible = true;

    void Start()
    {
        rend = GetComponent<Renderer>();  // Get the object's material renderer
    }

    void Update()
    {
        if (rend == null) return;

        flickerTimer += Time.deltaTime;

        if (flickerTimer >= flickerInterval)
        {
            isVisible = !isVisible;          // Toggle visibility
            rend.enabled = isVisible;
            flickerTimer = 0f;
        }
    }
}
