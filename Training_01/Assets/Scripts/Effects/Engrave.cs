using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Engrave : MonoBehaviour
{
    public bool affectLight;
    public Light2D globalLight;
    Material mat;
    float fade;
    bool isDone;
    [Range(0f, 1f)] public float timeScale;

    private void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (!isDone)
        {
            fade += timeScale * Time.deltaTime;
            if (fade >= 1)
            {
                fade = 1f;
                isDone = true;
            }
        }
        mat.SetFloat("_FadeIn", fade);

        if (affectLight)
            globalLight.intensity = Mathf.Lerp(0.01f, 0.02f, fade);
    }
}
