using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SplineFollow : MonoBehaviour
{

    public PathCreator spline;
    public EndOfPathInstruction end;
    public AnimationCurve speed;
    float traveledDst;



    void Update()
    {

        traveledDst += 100 * speed.Evaluate(traveledDst/spline.path.length) * Time.deltaTime;
        transform.position = spline.path.GetPointAtDistance(traveledDst, end);
    }
}
