using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{


    public GameObject anim1;
    public float delay1;
    public GameObject anim2;
    public float delay2;
    public GameObject anim3;
    public float delay3;



    private void Start()
    {
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        anim1.SetActive(true);
        yield return new WaitForSeconds(delay1);
        anim1.SetActive(false);
        anim2.SetActive(true);
        yield return new WaitForSeconds(delay2);
        anim3.SetActive(true);
        yield return new WaitForSeconds(delay3);
        //globalLight.intensity = 0.03f;

    }
}
