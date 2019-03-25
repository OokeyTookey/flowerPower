using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class Pathfinding : MonoBehaviour
{
    PathRequestManager requestManager;
    //public Transform seeker, target;
    Grid grid;

    void Awake()
    {
        requestManager = GetComponent<PathRequestManager>();
        grid = GetComponent<Grid>();
    }

    void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    FindPath(seeker.position, target.position);

        //}

       

    }


    public void StartFindPath(Vector3 startPos, Vector3 targetPos)
    {
        
        StartCoroutine(FindPath(startPos, targetPos));
    }
    //void FindPath(Vector3 startPos, Vector3 targetPos)
    //{
    //    Stopwatch sw = new Stopwatch();
    //    sw.Start();
    //    Node startNode = grid.NodeFromWorldPoint(startPos);
    //    Node targetNode = grid.NodeFromWorldPoint(targetPos);

    //    Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
    //    List<Node> openSet = new List<Node>();
    //    HashSet<Node> closedSet = new HashSet<Node>();
    //    openSet.Add(startNode);

    //    while (openSet.Count > 0)
    //    {
    //        Node node = openSet.RemoveFirst();
    //        Node node = openSet[0];
    //        for (int i = 1; i < openSet.Count; i++)
    //        {
    //            if (openSet[i].FCost < node.FCost || openSet[i].FCost == node.FCost)
    //            {
    //                if (openSet[i].hCost < node.hCost)
    //                    node = openSet[i];
    //            }
    //        }

    //        openSet.Remove(node);
    //        closedSet.Add(node);

    //        if (node == targetNode)
    //        {
    //            sw.Stop();
    //            print("Path found: " + sw.ElapsedMilliseconds + " ms");
    //            RetracePath(startNode, targetNode);
    //            return;
    //        }

    //        foreach (Node neighbor in grid.GetNeighbors(node))
    //        {
    //            if (!neighbor.walkable || closedSet.Contains(neighbor))
    //            {
    //                continue;
    //            }

    //            int newCostToNeighbour = node.gCost + GetDistance(node, neighbor);
    //            if (newCostToNeighbour < neighbor.gCost || !openSet.Contains(neighbor))
    //            {
    //                neighbor.gCost = newCostToNeighbour;
    //                neighbor.hCost = GetDistance(neighbor, targetNode);
    //                neighbor.parent = node;

    //                if (!openSet.Contains(neighbor))
    //                    openSet.Add(neighbor);
    //            }
    //        }
    //    }
    //}
    IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Vector3[] waypoints = new Vector3[0];
        bool pathSuccess = false;

        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);
        if (startNode.walkable && targetNode.walkable)
        {

            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            //List<Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node node = openSet.RemoveFirst();
                //Node node = openSet[0];
                //for (int i = 1; i < openSet.Count; i++)
                //{
                //    if (openSet[i].FCost < node.FCost || openSet[i].FCost == node.FCost)
                //    {
                //        if (openSet[i].hCost < node.hCost)
                //            node = openSet[i];
                //    }
                //}

                //openSet.Remove(node);
                closedSet.Add(node);

                if (node == targetNode)
                {
                    sw.Stop();
                    print("Path found: " + sw.ElapsedMilliseconds + " ms");
                    pathSuccess = true;

                    break;
                }

                foreach (Node neighbor in grid.GetNeighbors(node))
                {
                    if (!neighbor.walkable || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int newCostToNeighbour = node.gCost + GetDistance(node, neighbor);
                    if (newCostToNeighbour < neighbor.gCost || !openSet.Contains(neighbor))
                    {
                        neighbor.gCost = newCostToNeighbour;
                        neighbor.hCost = GetDistance(neighbor, targetNode);
                        neighbor.parent = node;

                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                    }
                }
            }
        }
        yield return null;
        if (pathSuccess)
        {
            waypoints = RetracePath(startNode, targetNode);
        }
        requestManager.FinishedProcessingPath(waypoints, pathSuccess);
    }

    Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(startNode);
        Vector3[] waypoints = SimplifyPath(path);
        Array.Reverse(waypoints);
        return waypoints;
    }


    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if(directionNew != directionOld){
            waypoints.Add(path[i-1].worldPosition);
        }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }
    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}