using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNodesAnna 
{
    public Vector3 worldPosition;
    public bool isWalkable;
    public int gCost;
    public int hCost;

    public AStarNodesAnna(Vector3 worldPosition)
    {
        this.worldPosition = worldPosition;
    }
}
