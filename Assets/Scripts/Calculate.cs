using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    public static Vector3 Acceleration(Vector3 body1Pos, Vector3 body2Pos, float mass)
    {
        Vector3 acceleration = Vector3.zero;
        if (body1Pos != body2Pos)
        {
            float sqrDistance = (body2Pos - body1Pos).sqrMagnitude;
            Vector3 direction = (body2Pos - body1Pos).normalized;
            acceleration += direction * Sim.G * mass / sqrDistance;
        }

        return acceleration;
    }
}
