using UnityEngine;

public class EmissionPulse : MonoBehaviour
{
    public Color emissionColor = Color.cyan; // Neon glow color
    public float pulseSpeed = 2f;            // How fast it pulses
    public float intensity = 2f;             // Brightness multiplier

    private Material mat;
    private Color baseColor;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        if (mat.HasProperty("_EmissionColor"))
        {
            baseColor = emissionColor;
            mat.EnableKeyword("_EMISSION");
        }
    }

    void Update()
    {
        if (mat != null)
        {
            float glow = (Mathf.Sin(Time.time * pulseSpeed) + 1f) * 0.5f;
            Color finalColor = baseColor * (glow * intensity);
            mat.SetColor("_EmissionColor", finalColor);
        }
    }
}
