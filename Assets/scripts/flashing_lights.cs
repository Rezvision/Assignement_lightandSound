using UnityEngine;
using System.Collections;
public class flashing_lights : MonoBehaviour
{
    public Light flashingLight;
    public float flashInterval = 0.5f;
    private bool isLightOn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (flashingLight == null)
        {
            flashingLight = GetComponent<Light>();
            if (flashingLight == null)
            {
                Debug.LogError("FlashingLights script requires a Light component.");
                enabled = false;
                return;
            }
        }

        // Start the flashing coroutine
        StartCoroutine(FlashLights());
    }

    IEnumerator FlashLights()
    {
        while (true)
        {
            yield return new WaitForSeconds(flashInterval);

            // Toggle the light status
            isLightOn = !isLightOn;

            // Enable or disable the light based on the status
            flashingLight.enabled = isLightOn;
        }
    }
}
