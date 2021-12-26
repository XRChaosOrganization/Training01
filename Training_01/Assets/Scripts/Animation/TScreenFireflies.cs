using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TScreenFireflies : MonoBehaviour
{

    public List<Light2D> fireflies;
    public Transform container;
    bool isFinished;
    int count;



    private void Awake()
    {
        foreach (Transform child in container)
        {
            fireflies.Add(child.GetComponentInChildren<Light2D>());
        }

        
    }

    private void Update()
    {
        if (!isFinished)
        {
            foreach (Light2D light in fireflies)
            {
                if (light.gameObject.transform.position.x >= transform.position.x && light.GetComponent<Flicker>().isOn == false)
                {
                    light.GetComponent<Flicker>().isOn = true;
                    count++;
                }
            }

            if (count >= fireflies.Count)
            {
                isFinished = true;
                fireflies.Clear();
            }
        }
        
    }

}
