    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStarSpin : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 0.05f));
    }
}
