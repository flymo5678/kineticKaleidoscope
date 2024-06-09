using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBody : MonoBehaviour
{

    public GameObject dropdown;

    public void AddBody()
    {
        var newBody = Instantiate(Sim.template);
        newBody.GetComponent<MeshRenderer>().enabled = true;
        newBody.transform.tag = "Body";
        Sim.bodyList.Add(newBody);
        Sim.BodyDropdown.AddOptions(new List<string>{"Body #" + (Sim.bodyList.ToArray().Length - 1).ToString()});
        Sim.BodyDropdown.GetComponent<EditBodies>().UpdateSlider();
    }
}
