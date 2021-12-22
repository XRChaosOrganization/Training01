using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Behavior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collected !");
        Destroy(this.gameObject);
    }
}
