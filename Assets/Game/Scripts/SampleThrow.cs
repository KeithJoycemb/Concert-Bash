using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleThrow : MonoBehaviour
{
    public float throwForce = 10f;
    public GameObject objectPrefab;
    public Transform throwPoint;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    private void Throw()
    {
        GameObject obj = Instantiate(objectPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
