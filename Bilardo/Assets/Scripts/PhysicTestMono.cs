using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicTestMono : MonoBehaviour
{
    public PhysicEngine physicEngine;

    public MyCircleRigid rigidObject;
    
    // Start is called before the first frame update
    void Start()
    {
        physicEngine = new PhysicEngine();
        var allCircleRigids = GameObject.FindObjectsOfType<MyCircleRigid>();
        physicEngine.circleRigids = allCircleRigids.ToList();
        
        rigidObject.AddForce(Vector3.up * 100);
    }

    // Update is called once per frame
    void Update()
    {
        physicEngine.Simulate();
    }
}
