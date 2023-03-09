using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicAttraction : MonoBehaviour
{
    public GameObject atom, attractor;
    public Gradient gradient;
    public Material material;
    Material[] sharedMaterial;
    Color[] sharedColor;
    public int[] attractPoints;
    public Vector3 spacingDirection;
    [Range(0, 20)]
    public float spacingBetweenAttractPoints;
    [Range(0, 10)]
    public float scaleAttractPoints;
    GameObject[] attractorArray, atomArray;
    [Range(1, 64)]
    public int amountOfAtomPerPoint;
    public Vector2 atomScaleMinMax;
    float[] atomScaleSet;
    public float strengthOfAttraction, maxMagnitude,randomPosDistance;
    public bool useGravity;


    public float audioScaleMultiplier,audioEmissionMultiplier;

    [Range(0.0f,1.0f)]
    public float thresholdEmission;

    float[] audioBandEmissionThreshold;
    float[] audioBandEmissionColour;
    float[] audioBandScale;

    public enum emissionThreshold { Buffered,NoBuffer};
    public emissionThreshold emissionThreshold1 = new emissionThreshold();
    public enum emissionColour { Buffered, NoBuffer };
    public emissionColour emissionColour1 = new emissionColour();
    public enum atomScale { Buffered, NoBuffer };
    public atomScale atomScale1 = new atomScale();


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
            Gizmos.DrawSphere(pos, scaleAttractPoints*0.5f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        attractorArray = new GameObject[attractPoints.Length];
        atomArray = new GameObject[attractPoints.Length * amountOfAtomPerPoint];
        atomScaleSet = new float[attractPoints.Length * amountOfAtomPerPoint];

        audioBandEmissionThreshold = new float [8];
        audioBandEmissionColour = new float[8];
        audioBandScale = new float[8];

        sharedMaterial = new Material[8];
        sharedColor = new Color[8];


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

            //set colors to material
            Material matInstance = new Material(material);
            sharedMaterial[i] = matInstance;
            sharedColor[i] = gradient.Evaluate(0.125f * i);

            for (int j =0;j<amountOfAtomPerPoint;j++)
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
                //atomInstance.transform.parent = transform.parent.transform;

                atomInstance.GetComponent<MeshRenderer>().material = sharedMaterial[i];
                countAtom++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SelectAudioValues();
        AtomBehaviour();
    }

    void AtomBehaviour()
    {
        int countAtom = 0;
        for (int i = 0; i < attractPoints.Length; i++)
        {

            if(audioBandEmissionThreshold[attractPoints[i]]>=thresholdEmission)
            {
                Color audioColor = new Color(sharedColor[i].r * audioBandEmissionColour[attractPoints[i]] * audioEmissionMultiplier,
                    sharedColor[i].g * audioBandEmissionColour[attractPoints[i]] * audioEmissionMultiplier,
                    sharedColor[i].b * audioBandEmissionColour[attractPoints[i]] * audioEmissionMultiplier, 1);
                sharedMaterial[i].SetColor("EmissionColour", audioColor);
            }
            else
            {
                Color audioColor = new Color(0, 0, 0, 1);
                sharedMaterial[i].SetColor("EmissionColour", audioColor);
            }

            for (int j = 0; j < amountOfAtomPerPoint; j++)
            {
                atomArray[countAtom].transform.localScale = new Vector3(atomScaleSet[countAtom] + audioBandScale[attractPoints[i]] * audioScaleMultiplier,
                    atomScaleSet[countAtom] + audioBandScale[attractPoints[i]] * audioScaleMultiplier,
                    atomScaleSet[countAtom] + audioBandScale[attractPoints[i]] * audioScaleMultiplier);
                countAtom++;
            }
        }
    }

    void SelectAudioValues()
    {
        //Threshold
        if (emissionThreshold1==emissionThreshold.Buffered)
        {
            for(int i = 0;i<8;i++)
            {
                audioBandEmissionThreshold[i] = AudioPeer.audioBandBuffer[i];
            }
        }
        if (emissionThreshold1 == emissionThreshold.NoBuffer)
        {
            for (int i = 0; i < 8; i++)
            {
                audioBandEmissionThreshold[i] = AudioPeer.audioBand[i];
            }
        }

        //emission colour
        if (emissionColour1 == emissionColour.Buffered)
        {
            for (int i = 0; i < 8; i++)
            {
                audioBandEmissionColour[i] = AudioPeer.audioBandBuffer[i];
            }
        }
        if (emissionColour1 == emissionColour.NoBuffer)
        {
            for (int i = 0; i < 8; i++)
            {
                audioBandEmissionColour[i] = AudioPeer.audioBand[i];
            }
        }

        // Atom scale
        if (atomScale1 == atomScale.Buffered)
        {
            for (int i = 0; i < 8; i++)
            {
                audioBandScale[i] = AudioPeer.audioBandBuffer[i];
            }
        }
        if (atomScale1 == atomScale.NoBuffer)
        {
            for (int i = 0; i < 8; i++)
            {
                audioBandScale[i] = AudioPeer.audioBand[i];
            }
        }
    }
}
