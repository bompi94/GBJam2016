using UnityEngine;
using System.Collections;

public class CameraShaking : MonoBehaviour {

	public float duration;
    public float magnitude;
    bool shaking = false;
    float count;

    public void StartShaking()
    {
        if(!shaking)
            StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        shaking = true; 
        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(originalCamPos.x+x, originalCamPos.y, originalCamPos.z);
            
            yield return null;
        }
        
        Camera.main.transform.position = originalCamPos;
        shaking = false;
    }
}
