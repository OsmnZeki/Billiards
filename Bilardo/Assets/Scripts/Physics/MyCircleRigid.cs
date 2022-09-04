using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCircleRigid : MonoBehaviour
{
    public Vector3 position;
    public Vector3 acceleration;
    public Vector3 velocity;
    
    public float mass;
    public float inverseMass;
    
    public float radius;

    public void AddForce(Vector3 force)
    {
        acceleration += force * inverseMass;
    }
}
