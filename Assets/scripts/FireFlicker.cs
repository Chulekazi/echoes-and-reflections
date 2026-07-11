using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireFlicker : MonoBehaviour
{
    [Header("Light Component")]
    public Light2D fireLight;

    [Header("Flicker Intensity (Brightness)")]
    public float minIntensity = 3f;     // Widened range for more contrast
    public float maxIntensity = 7f;

    [Header("Flicker Size (Scale)")]
    public float minScale = 0.9f;         // Widened range for sharper jumps
    public float maxScale = 1.1f;

    [Header("Flicker Speeds")]
    public float flickerSpeed = 6f;       // Increased for a more aggressive crackle
    public float colorFlickerSpeed = 3f;  // Colors usually shift a bit slower than the physical crackle

    private float randomOffset;

    void Awake()
    {
        if (fireLight == null)
        {
            fireLight = GetComponent<Light2D>();
        }

        // Pick a random starting point so multiple fires don't sync up
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // 1. GENERATE INDEPENDENT NOISE
        // By adding +10 and +20, the brightness, size, and color are all reading 
        // completely different parts of the random wave. This creates true chaos!
        float intensityNoise = Mathf.PerlinNoise(Time.time * flickerSpeed + randomOffset, 0f);
        float scaleNoise = Mathf.PerlinNoise(Time.time * flickerSpeed + randomOffset + 10f, 0f);

        // 2. FLICKER INTENSITY
        fireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, intensityNoise);

        // 3. FLICKER SCALE
        float scaleFlicker = Mathf.Lerp(minScale, maxScale, scaleNoise);
        transform.localScale = new Vector3(scaleFlicker, scaleFlicker, 1f);
    }
}