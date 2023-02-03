using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{

    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;
    Material material;
    




    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        material.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (useBuffer) 
        { 
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBandBuffer[band] *scaleMultiplier)+ startScale, transform.localScale.z);
            Color color = new Color(AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band]);
            material.SetColor("EmissionColor", color);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
            //Color color = new Color(AudioPeer.audioBand[band], AudioPeer.audioBand[band], AudioPeer.audioBand[band]);
            // material.SetColor("EmissionColor", color);
            Color _color = new Color(1, 0, 0, 1); //which is red
            material.SetColor("_EmissionColor", _color * AudioPeer.audioBand[0]);
            // material.SetColor("_EmissionColor", _color * AudioPeer.audioBand[0] * someMultiplierFloat);
           
        }
    }
}