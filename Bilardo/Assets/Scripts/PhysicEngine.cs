using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PhysicEngine
{
    public List<MyCircleRigid> circleRigids;

    public const float FixedTime = 0.02f;

    float totalTime;


    public void Simulate()
    {
        SyncRigidTransforms();
        
        var fixedCount = GetFixedStepCount(Time.deltaTime);
        for (int i = 0; i < fixedCount; i++)
        {
            Motion();
        }
        SyncTransforms();
    }
    
    public void Motion()
    {
        foreach (var rigid in circleRigids)
        {
            rigid.velocity += rigid.acceleration * FixedTime;
            rigid.position += rigid.velocity * FixedTime;
            
            rigid.acceleration = Vector3.zero;
        }
    }
    
    public int GetFixedStepCount(float deltaTime)
    {
        totalTime += deltaTime;
        int i = 0;
        while (totalTime >= FixedTime)
        {
            i++;
            totalTime -= FixedTime;
        }

        return i;
    }

    public bool CircleCircleCollisionDetection()
    {
        for (int i = 0; i < circleRigids.Count; i++)
        {
            for (int j = i+1; j < circleRigids.Count; j++)
            {
                var c1 = circleRigids[i];
                var c2 = circleRigids[j];

                var radiusSum = c1.radius + c2.radius;
                var c1ToC2 = c2.position - c1.position;
                
                

            }
        }

        return false;
    }
    
    public void SyncTransforms()
    {
        foreach (var rigid in circleRigids)
        {
            rigid.transform.position=rigid.position;
        }
    }

    public void SyncRigidTransforms()
    {
        foreach (var rigid in circleRigids)
        {
            rigid.position = rigid.transform.position;
        }
    }
    
}