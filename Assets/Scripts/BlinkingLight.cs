using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public float blinkPeriod = 1f;
    public Light lightComponent;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }

    private void OnEnable()
    {
        StartCoroutine(BlinkRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private System.Collections.IEnumerator BlinkRoutine()
    {
        float halfPeriod = blinkPeriod / 2f;

        while (true)
        {
            lightComponent.enabled = true;
            yield return new WaitForSeconds(halfPeriod);

            lightComponent.enabled = false;
            yield return new WaitForSeconds(halfPeriod);
        }
    }
}
