using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderer : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Line_render line;

    // Start is called before the first frame update
    void Start()
    {
        line.setupline(points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
