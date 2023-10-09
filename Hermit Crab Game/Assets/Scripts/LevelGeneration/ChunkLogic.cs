using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkLogic : MonoBehaviour
{
    [SerializeField] public LayerMask layerMask; // chunks or walls
    [SerializeField] private Grid grid;

    #region WALLS
    [Header("Walls")]
    [SerializeField] private GameObject p_wall;
    [SerializeField] private Transform wallParent;
    #endregion

    private Vector3Int[] checkGrid =
    {
        // EDGES
        Vector3Int.up,
        Vector3Int.down,
        Vector3Int.left,
        Vector3Int.right,
        Vector3Int.zero,

        // CORNERS
        new Vector3Int(-1, 1, 0), // top left
        new Vector3Int(-1, -1, 0), // bot left
        new Vector3Int(1, -1, 0), // bot right
        new Vector3Int(1, 1, 0), // top right
    };

    private void Awake()
    {
        grid = LevelGenerationManager.Instance.grid;
        wallParent = LevelGenerationManager.Instance.wallParent;
    }

    public void ChunkOrWall()
    {
        foreach (Vector3Int check in checkGrid)
        {
            if (!GridCheck(check))
            {
                GameObject wall = Instantiate(p_wall, GridPos(check), Quaternion.identity, wallParent);
                LevelGenerationManager.Instance.walls.Add(wall);
            }
        }
    }

    private Vector3 GridPos(Vector3Int pos)
    {
        Vector3Int gridPos = grid.WorldToCell(transform.position);

        Vector3Int gridCastPos = gridPos + pos;

        return grid.GetCellCenterWorld(gridCastPos);
    }

    private bool GridCheck(Vector3Int direction)
    {

        Vector3Int gridPos = grid.WorldToCell(transform.position);

        Vector3Int gridCastPos = gridPos + direction;

        Vector3 worldCastPos = grid.GetCellCenterWorld(gridCastPos);

        return Physics2D.CircleCast(worldCastPos, 5f, Vector3.zero, 0, layerMask, -5f, 5f);
    }

}
