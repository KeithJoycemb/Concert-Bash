using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractTo : MonoBehaviour
{
    Rigidbody rigidBody;
    public Transform attractedTo;
    public float strengthOfAttraction,maxMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(attractedTo!=null)
        {
            Vector3 direction = attractedTo.position - transform.position;
            rigidBody.AddForce(strengthOfAttraction * direction);
            
            if(rigidBody.velocity.magnitude>maxMagnitude)
            {
                rigidBody.velocity = rigidBody.velocity.normalized * maxMagnitude;

            }
        }


    }
}
