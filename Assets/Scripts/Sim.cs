using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Sim : MonoBehaviour
{
    public static TMP_Dropdown BodyDropdown;
    public const float G = 100f;
    public static bool Running = false;
    public static GameObject template;
    public static List<GameObject> bodyList = new List<GameObject>();
    GameObject[] bodies;
    void Start()
    {
        BodyDropdown = GameObject.FindObjectOfType<TMP_Dropdown>();
        bodyList = GameObject.FindGameObjectsWithTag("Body").ToList();
        template = GameObject.FindGameObjectWithTag("BodyTemplate");
    }

    void FixedUpdate()
    {
        bodies = bodyList.ToArray();
        if (Running)
        {
            foreach (var body in bodies)
            {
                body.GetComponent<BodyMovement>().UpdatePos();
            }
        }
        
    }
}
