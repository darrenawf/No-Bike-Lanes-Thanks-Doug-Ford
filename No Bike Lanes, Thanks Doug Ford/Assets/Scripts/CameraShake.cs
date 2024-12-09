using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isShaking = false;
    // Start is called before the first frame update
    void Start()
    {

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
        StartCoroutine(Shake(duration, severity, vertical, horizontal));
    }

    private IEnumerator Shake(float duration, float severity, bool vertical, bool horizontal)
    {
        originalPosition = transform.localPosition;//NOT NEEDED
        isShaking = true;
        while (duration > 0)
        {
            Vector3 shakeOffset = Vector3.zero;

            if (horizontal)
            {
                shakeOffset.x = Random.Range(-1f, 1f) * severity;
            }

            if (vertical)
            {
                shakeOffset.y = Random.Range(-1f, 1f) * severity;
            }

            transform.localPosition = originalPosition + shakeOffset;

            duration -= Time.deltaTime;

            yield return null;
        }
    }
}
