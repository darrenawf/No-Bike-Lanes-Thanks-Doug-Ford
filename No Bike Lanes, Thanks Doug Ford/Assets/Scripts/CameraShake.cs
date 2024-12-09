using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isShaking = false;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Get the main camera reference
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeCamera(float duration, float severity, bool vertical, bool horizontal)
    {
        if (isShaking)
        {
            return;
        }
        
        // Set the initial camera size to 4.25 during the shake
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 4.25f;
        }

        StartCoroutine(Shake(duration, severity, vertical, horizontal));
    }

    private IEnumerator Shake(float duration, float severity, bool vertical, bool horizontal)
    {
        originalPosition = transform.localPosition;
        isShaking = true;

        float elapsedTime = 0f;
        float initialSize = 4.25f; // Initial orthographic size during shake
        float targetSize = 4.5f;   // Final orthographic size after shake

        while (elapsedTime < duration)
        {
            // Exponential decay for easing out
            float easeFactor = Mathf.Exp(-elapsedTime * 3f / duration);
            Vector3 shakeOffset = Vector3.zero;

            if (horizontal)
            {
                shakeOffset.x = Random.Range(-1f, 1f) * severity * easeFactor;
            }

            if (vertical)
            {
                shakeOffset.y = Random.Range(-1f, 1f) * severity * easeFactor;
            }

            transform.localPosition = originalPosition + shakeOffset;

            if (mainCamera != null)
            {
                mainCamera.orthographicSize = Mathf.Lerp(initialSize, targetSize, 1f - easeFactor);
            }

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Reset the camera position and size after shaking
        transform.localPosition = originalPosition;
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = targetSize;
        }

        isShaking = false;
    }
}