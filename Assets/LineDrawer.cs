using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer lr;
    public Transform[] points;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        for(int i =0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}
