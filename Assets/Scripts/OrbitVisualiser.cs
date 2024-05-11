using System;
using UnityEditor;
using UnityEngine;

public class OrbitVisualiser : MonoBehaviour
{
    public int iterations;
    public GameObject centralBody;
    public int index;
    
    private void FixedUpdate()
    {
        orbitLine();
    }
        

    class FakeBody
    {
        public Vector3 position;
        public Vector3 velocity;
        public float mass;

        public FakeBody (GameObject body) 
        {
            position = body.transform.position;
            if (Sim.Running)
            {
                velocity = body.GetComponent<BodyMovement>().currentVel; 
            }
            else
            {
                velocity = body.GetComponent<BodyMovement>().initialVel;
            }
            mass = body.GetComponent<Rigidbody>().mass;
        }
    }
    
    void orbitLine ()
    {
        GameObject[] bodies = Sim.bodyList.ToArray();
        var points = new Vector3[bodies.Length][];
        var fakeBodies = new FakeBody[bodies.Length];
        int referenceFrameIndex = 0;
        Vector3 referenceBodyInitialPosition = Vector3.zero;
        
        for (int i = 0; i < bodies.Length; i++)
        {
            fakeBodies[i] = new FakeBody(bodies[i]);
            points[i] = new Vector3[iterations];

            if (bodies[i] == centralBody)
            {
                referenceFrameIndex = i;
                referenceBodyInitialPosition = bodies[i].transform.position;
            }
        }

        float timeStep = Time.fixedDeltaTime;

        for (int step = 0; step < iterations; step++)
        {
            Vector3 referenceBodyPosition = fakeBodies[referenceFrameIndex].position;
            
            for (int i = 0; i < fakeBodies.Length; i++)
            {
                Vector3 currentVel = fakeBodies[i].velocity;
                for (int j = 0; j < fakeBodies.Length; j++)
                {
                    currentVel += Calculate.Acceleration(fakeBodies[i].position, fakeBodies[j].position,
                        fakeBodies[j].mass) * timeStep;
                }
                Vector3 nextPos = fakeBodies[i].position + currentVel * timeStep;
                fakeBodies[i].velocity = currentVel;
                nextPos -= referenceBodyPosition;

                if (i == referenceFrameIndex)
                {
                    nextPos = referenceBodyInitialPosition;
                }
                
                points[i][step] = nextPos;
                fakeBodies[i].position = nextPos;
            }
        }

        for (int i = 0; i < fakeBodies.Length; i++)
        {
            var lineRenderer = bodies[i].gameObject.GetComponent<LineRenderer>();
            lineRenderer.enabled = true;
            lineRenderer.positionCount = points[i].Length;
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
            lineRenderer.SetPositions(points[i]);
        }
        
    }
}
