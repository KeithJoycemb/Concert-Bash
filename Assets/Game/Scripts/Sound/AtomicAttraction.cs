using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicAttraction : MonoBehaviour
{
    public GameObject atom, attractor;
    public Gradient gradient;
    public int[] attractPoints;
    public Vector3 spacingDirection;
    [Range(0, 20)]
    public float spacingBetweenAttractPoints;
    [Range(0, 20)]
    public float scaleAttractPoints;

    private void OnDrawGizmos()
    {
        for(int i =0;i <attractPoints.Length;i++)
        {
            float evaluateStep = 1.0f / attractPoints.Length;
            Color color = gradient.Evaluate(evaluateStep * i);
            Gizmos.color = color;

            Vector3 pos = new Vector3(transform.position.x + (spacingBetweenAttractPoints * i * spacingDirection.x),
                                        transform.position.y + (spacingBetweenAttractPoints * i * spacingDirection.y),
                                        transform.position.z + (spacingBetweenAttractPoints * i * spacingDirection.z));
            Gizmos.DrawSphere(pos, scaleAttractPoints);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
