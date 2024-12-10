/*
Attached: Main Camera
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isShaking = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void ShakeCamera(float duration, float severity, bool vertical, bool horizontal)
    {
        if (isShaking)
        {
            return;
        }
        
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
        
        float initialSize = 4.25f;
        // Default Size
        float targetSize = 4.5f;

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

        // Reset camera position and size after shaking
        transform.localPosition = originalPosition;
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = targetSize;
        }

        isShaking = false;
    }
}