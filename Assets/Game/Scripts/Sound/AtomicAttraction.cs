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
    GameObject[] attractorArray, atomArray;
    [Range(1, 64)]
    public int amountOfAtomPerPoint;
    public Vector2 atomScaleMinMax;
    float[] atomScaleSet;
    public float strengthOfAttraction, maxMagnitude,randomPosDistance;
    public bool useGravity;

    private void OnDrawGizmos()
    {
        for(int i =0;i <attractPoints.Length;i++)
        {
            float evaluateStep = 0.125f ;
            Color color = gradient.Evaluate(Mathf.Clamp (evaluateStep * attractPoints[i],0,7));
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
        attractorArray = new GameObject[attractPoints.Length];
        atomArray = new GameObject[attractPoints.Length * amountOfAtomPerPoint];
        atomScaleSet = new float[attractPoints.Length * amountOfAtomPerPoint];

        int countAtom = 0;
        //instantiate attract points
        for (int i = 0; i< attractPoints.Length;i++)
        {
            GameObject attractorInstance = (GameObject)Instantiate(attractor);
            attractorArray[i] = attractorInstance;

            attractorInstance.transform.position =new Vector3(transform.position.x + (spacingBetweenAttractPoints * i * spacingDirection.x),
                                        transform.position.y + (spacingBetweenAttractPoints * i * spacingDirection.y),
                                        transform.position.z + (spacingBetweenAttractPoints * i * spacingDirection.z));

            attractorInstance.transform.parent = this.transform;
            attractorInstance.transform.localScale = new Vector3(scaleAttractPoints, scaleAttractPoints, scaleAttractPoints);

            for (int j =0;j<amountOfAtomPerPoint;i++)
            {
                GameObject atomInstance = (GameObject)Instantiate(atom);
                atomArray[countAtom] = atomInstance;
                atomInstance.GetComponent<AttractTo>().attractedTo = attractorArray[i].transform;
                atomInstance.GetComponent<AttractTo>().strengthOfAttraction = strengthOfAttraction;
                atomInstance.GetComponent<AttractTo>().maxMagnitude = maxMagnitude;
                if (useGravity)
                {
                    atomInstance.GetComponent<Rigidbody>().useGravity = true;
                }
                else
                {
                    atomInstance.GetComponent<Rigidbody>().useGravity = false;
                }

                atomInstance.transform.position = new Vector3(attractorArray[i].transform.position.x + Random.Range(-randomPosDistance, randomPosDistance),
                    attractorArray[i].transform.position.y + Random.Range(-randomPosDistance, randomPosDistance),
                    attractorArray[i].transform.position.z + Random.Range(-randomPosDistance, randomPosDistance));
                
                float randomScale = Random.Range(atomScaleMinMax.x, atomScaleMinMax.y);
                atomScaleSet[countAtom] = randomScale;
                atomInstance.transform.localScale = new Vector3(atomScaleSet[countAtom], atomScaleSet[countAtom], atomScaleSet[countAtom]);
                atomInstance.transform.parent = transform.parent.transform;
                
                countAtom++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
