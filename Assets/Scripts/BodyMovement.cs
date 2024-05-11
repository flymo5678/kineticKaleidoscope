using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public Vector3 initialVel;
    public bool ignoreOthers;
    public Vector3 currentVel;
    
    public void UpdatePos()
    {
        float timestep = Time.fixedDeltaTime;
        if (ignoreOthers == false)
        {
            foreach (var body in Sim.bodyList.ToArray())
            {
                currentVel += Calculate.Acceleration(transform.position, body.transform.position,
                    body.GetComponent<Rigidbody>().mass) * timestep;
            }
            
            gameObject.transform.position += currentVel * timestep;
        }
    }
}
