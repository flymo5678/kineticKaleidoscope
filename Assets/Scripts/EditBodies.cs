using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EditBodies : MonoBehaviour
{
    public new List<Slider> propertySliders;
    private bool wait;
    public  void UpdateSlider()
    {
        int index = Sim.BodyDropdown.value + 1;
        wait = true;
        propertySliders[0].value = Sim.bodyList[index].transform.position.x;
        propertySliders[1].value = Sim.bodyList[index].transform.position.y;
        propertySliders[2].value = Sim.bodyList[index].transform.position.z;
        propertySliders[3].value = Sim.bodyList[index].GetComponent<BodyMovement>().initialVel.x;
        propertySliders[4].value = Sim.bodyList[index].GetComponent<BodyMovement>().initialVel.y;
        propertySliders[5].value = Sim.bodyList[index].GetComponent<BodyMovement>().initialVel.z;
        propertySliders[6].value = Sim.bodyList[index].GetComponent<Rigidbody>().mass;
        wait = false; 
    }

    public void UpdateBody()
    {
        if (!wait)
        {
            int index = Sim.BodyDropdown.value + 1;

            Vector3 position = new Vector3(propertySliders[0].value, propertySliders[1].value, propertySliders[2].value);
            Sim.bodyList[index].transform.position = position;

            Vector3 initialVel = new Vector3(propertySliders[3].value, propertySliders[4].value, propertySliders[5].value);
            Sim.bodyList[index].GetComponent<BodyMovement>().initialVel = initialVel;

            Sim.bodyList[index].GetComponent<Rigidbody>().mass = propertySliders[6].value;
        }
    }
}
