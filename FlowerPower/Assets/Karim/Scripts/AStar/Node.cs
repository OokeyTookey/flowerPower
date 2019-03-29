using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{

    public bool walkable;
    public Vector3 worldPosition;

    public int gCost;
    public int hCost;

    public int gridX;
    public int gridY;
    int heapIndex;

    public Node parent;

    public Node (bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int FCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = FCost.CompareTo(nodeToCompare.FCost);
        if(compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }
}

