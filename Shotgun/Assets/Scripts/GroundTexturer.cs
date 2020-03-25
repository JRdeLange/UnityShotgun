using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTexturer : MonoBehaviour
{
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 scale = new Vector2(transform.localScale.x, transform.localScale.z);
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
