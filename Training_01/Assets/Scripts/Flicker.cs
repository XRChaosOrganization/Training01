using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    
    public bool isLight;
    Light2D lSource;
    

    [Space]

    public Vector2 timerRange;
    public Vector2 sizeRange;
    float size;


    float timerMax;
    float timer;

    private void Awake()
    {
        if (isLight)
            lSource = GetComponent<Light2D>();
        

    }

    private void Start()
    {
        timerMax = Random.Range(timerRange.x, timerRange.y);
        timer = timerMax;
    }

    private void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            size = Random.Range(sizeRange.x, sizeRange.y);

            if (isLight)
                lSource.pointLightOuterRadius = size;
            else transform.localScale = new Vector2(size, size);

            timerMax = Random.Range(timerRange.x, timerRange.y);
            timer = timerMax;

        }

    }
}
