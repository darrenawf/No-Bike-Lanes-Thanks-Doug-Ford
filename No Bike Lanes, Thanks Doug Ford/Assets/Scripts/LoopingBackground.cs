using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{   
    public float backgroundSpeed;
    public Renderer backgroundRenderer;

    void Update()
    {
        //Move background by a magnitude of background speed
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
