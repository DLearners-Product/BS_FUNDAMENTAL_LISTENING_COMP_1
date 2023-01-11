using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : MonoBehaviour
{
    public GameObject maskPrefab;
    public bool ispressed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousepos = Input.mousePosition;
        mousepos.z = 2;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        if (ispressed)
        {
            GameObject mask = Instantiate(maskPrefab, mousepos, Quaternion.identity);
            mask.transform.parent = gameObject.transform;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            ispressed = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            ispressed = false;
        }
    }
    
}

