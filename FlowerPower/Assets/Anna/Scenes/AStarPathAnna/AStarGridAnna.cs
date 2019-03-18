using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AStarGridAnna : MonoBehaviour
{
   public List<AStarNodesAnna> grid = new List<AStarNodesAnna>();
    public int gridSize;

    void Start()
    {
        for (int z = 0; z < gridSize; z++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                grid.Add(new AStarNodesAnna(new Vector3(x, 0, z)));
            }
        }
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < grid.Count; i++)
        {
            Gizmos.DrawCube(grid[i].worldPosition, Vector3.one - new Vector3(0.050f,0, 0.050f));
        }
    }


}
