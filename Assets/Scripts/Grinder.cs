using UnityEngine;

public class StartGrind : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float playDuration = 10f;
    public Collider coll;
    public GameObject cylinder;
    private Material cylinderMaterial;
    private bool isPlaying = false;
    private float fadeTimer = 0f;
    public GameObject socket;

    private void Start()
    {
        if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
        else
        {
            Debug.LogError("No Particle System attached to the script or the GameObject.");
        }

        if (cylinder != null)
        {
            Renderer renderer = cylinder.GetComponent<Renderer>();
            if (renderer != null)
            {
                cylinderMaterial = renderer.material;
                Color color = cylinderMaterial.color;
                color.a = 0f;
                cylinderMaterial.color = color;
            }
            else
            {
                Debug.LogError("No Renderer found on the cylinder GameObject.");
            }
        }
        else
        {
            Debug.LogError("No cylinder GameObject assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPlaying && particleSystem != null && other == coll)
        {
            isPlaying = true;
            particleSystem.Play();
            fadeTimer = 0f;
            Invoke("StopParticleSystem", playDuration);
        }
    }

    private void Update()
    {
        if (isPlaying && cylinderMaterial != null)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / playDuration);
            Color color = cylinderMaterial.color;
            color.a = alpha;
            cylinderMaterial.color = color;
        }
    }

    private void StopParticleSystem()
    {
        if (particleSystem != null)
        {
            particleSystem.Stop();
            if (socket != null)
            {
                socket.SetActive(false);
            }
        }
        isPlaying = false;
    }
}