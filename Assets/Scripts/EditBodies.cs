using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class EditBodies : MonoBehaviour
{
    public new List<Slider> propertySliders;
    public new List<InputField> propertyFields;
    private bool wait;

    public  void UpdateSlider()
    {
        for (int i = 0; i < 7; i++)
        {
            propertyFields[i].text = propertySliders[i].value.ToString();
        }
    }

    public void UpdateVal()
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

        for (int i = 0; i < 7; i++)
        {
            propertyFields[i].text = propertySliders[i].value.ToString();
        }
    }

    public void UpdateField()
    {
        for (int i = 0; i < 7; i++)
        {
            
            if (propertyFields[i].text != "" && propertyFields[i].text != "-")
            {
                propertySliders[i].value = float.Parse(propertyFields[i].text);
            }
        }
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
