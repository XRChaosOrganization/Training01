using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameController : MonoBehaviour
{
    public static GameController gc;
    [HideInInspector] public Rigidbody2D playerRB;
    [HideInInspector] public Light2D lSource;

    //Inputs
    [HideInInspector] public float xInput => Input.GetAxisRaw("Horizontal");
    [HideInInspector] public float yInput => Input.GetAxisRaw("Vertical");

    //Values
    float maxLight;
    float minLight = 0.4f;
    public float lightTimer;
    public float lRecoverSpeed;
    float t;

    public float moveSpeed;

    [HideInInspector] public bool isLevelStarted;
    [HideInInspector] public bool isControllable;

    bool loosingLight;
    bool gainingLight;
    float lerpStart;
    static float lerpTimeScale;



    private void Awake()
    {
        gc = this;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        lSource = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light2D>();
        maxLight = lSource.pointLightOuterRadius;


    }

    private void Start()
    {
        StartLevel();
    }


    private void Update()
    {
        if(isControllable)
            HandleMovement();

        if (loosingLight && isLevelStarted)
            LightShrink();
        if (gainingLight)
            LightLerp();

    }


    void HandleMovement()
    {
        Vector2 dir = new Vector2(xInput, yInput);
        playerRB.MovePosition(playerRB.position + dir * Time.deltaTime * moveSpeed);

    }

    void LightShrink()
    {
        if (t > 0)
        {
            lSource.pointLightOuterRadius = ((maxLight - minLight) * (t / lightTimer)) + minLight;
            t -= Time.deltaTime;
        }
        else
        {
            t = 0;
            loosingLight = false;
        } 
         
    }

    //Call This Method from anywhere to start the level
    public void StartLevel()
    {
        isControllable = true;
        t = lightTimer;
        isLevelStarted = true;
        loosingLight = true;
    }

    public void RestoreLight()
    {
        lerpStart = lSource.pointLightOuterRadius;
        loosingLight = false;
        gainingLight = true;

    }

    void LightLerp()
    {
        lSource.pointLightOuterRadius = Mathf.Lerp(lerpStart, maxLight, lerpTimeScale);
        lerpTimeScale += lRecoverSpeed * Time.deltaTime;

        if (lerpTimeScale >= 1f)
            ResetLerp();

    }

    void ResetLerp()
    {
        gainingLight = false;
        lerpTimeScale = 0f;

        if (isLevelStarted)
        {
            t = lightTimer;
            loosingLight = true;
        }
        
    }

}
