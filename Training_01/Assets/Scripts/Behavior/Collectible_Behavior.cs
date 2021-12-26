using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Collectible_Behavior : MonoBehaviour
{
    Light2D light2D;
    SpriteRenderer sr;
    float baseItensity;
    public float fadeOutScale;
    float t = 0f;
    bool destroy;

    private void Awake()
    {
        light2D = GetComponentInChildren<Light2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        baseItensity = light2D.intensity;
    }

    private void Update()
    {
        if (destroy)
        {
            light2D.intensity = Mathf.Lerp(baseItensity, 0f, t);
            sr.color.a.Equals(Mathf.Lerp(1f, 0f, t));
            t += fadeOutScale * Time.deltaTime;

            if (t >= 1f)
            {
                t = 0f;
                Destroy(this.gameObject);
            }

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.gc.RestoreLight();
        destroy = true;
    }
}
