using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gc;
    [HideInInspector] public Rigidbody2D playerRB;

    //Inputs
    [HideInInspector] public float xInput => Input.GetAxisRaw("Horizontal");
    [HideInInspector] public float yInput => Input.GetAxisRaw("Vertical");

    public float moveSpeed;



    private void Awake()
    {
        gc = this;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        
    }


    private void Update()
    {
        HandleMovement();
    }


    void HandleMovement()
    {
        Vector2 dir = new Vector2(xInput, yInput);
        playerRB.MovePosition(playerRB.position + dir * Time.deltaTime * moveSpeed);

    }

}
