using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartSim : MonoBehaviour
{
    private GameObject ui;
    private void Start()
    {
        ui = GameObject.FindWithTag("UI");
    }


    public void OnClick()
    {
        Sim.Running = true;
        ui.GetComponent<Canvas>().enabled = false;
        foreach (var body in Sim.bodyList)
        {
            body.GetComponent<BodyMovement>().currentVel = body.GetComponent<BodyMovement>().initialVel;
        }
    }
}
