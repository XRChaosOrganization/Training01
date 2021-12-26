using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    public bool isOn;
    public bool isLight;
    public bool intensity;
    Light2D lSource;
    

    [Space]

    public Vector2 timerRange;
    public Vector2 sizeRange;
    public Vector2 intensityRange;
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
        if (isOn)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                size = Random.Range(sizeRange.x, sizeRange.y);

                if (isLight && !intensity)
                    lSource.pointLightOuterRadius = size;
                else if (isLight && intensity)
                    lSource.intensity = Random.Range(intensityRange.x, intensityRange.y);
                else transform.localScale = new Vector2(size, size);


                timerMax = Random.Range(timerRange.x, timerRange.y);
                timer = timerMax;

            }
        }
        

    }
}
