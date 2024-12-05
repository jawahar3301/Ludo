using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointParent :  PathPoint
{
    public PathPoint[] commanPathPoint;
    public PathPoint[] redPathPoint;
    public PathPoint[] greenPathPoint;
    public PathPoint[] bluePathPoint;
    public PathPoint[] yellowPathPoint;

    [Header("Scale and Position")]
    public float[] scale;
    public float[] position;

    public PathPoint[] basePoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
