using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLogic : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private LayerMask chunks;
    [SerializeField] private LayerMask walls;
    [SerializeField] private Vector3Int currentGridPos;

    public Space[] spaceChecks = new Space[8];
    /*
     * 0 = up
     * 1 = down
     * 2 = left
     * 3 = right
     * 4 = top-left
     * 5 = top-right
     * 6 = bot-right
     * 7 = bot-left
     */

    [SerializeField]
    private Vector3Int[] spacePos =
    {
        Vector3Int.up,
        Vector3Int.down,
        Vector3Int.left,
        Vector3Int.right,
        new Vector3Int(-1, 1, 0),
        new Vector3Int(1, 1, 0),
        new Vector3Int(1, -1, 0),
        new Vector3Int(-1, -1, 0),
    };

    private void Awake()
    {
        grid = LevelGenerationManager.Instance.grid;
    }

    private void Start()
    {
        currentGridPos = grid.WorldToCell(gameObject.transform.position);
    }
    public void SpaceCheck()
    {
        for(int i = 0; i < spaceChecks.Length; i++)
        {
            spaceChecks[i] = SpaceType(spacePos[i]);
        }
    }

    public Space SpaceType(Vector3Int spacePos)
    {
        if (GridChecker(spacePos, chunks)) return Space.Chunk;
        else if (GridChecker(spacePos, walls)) return Space.Wall;
        else return Space.Empty;
    }

    private bool GridChecker(Vector3Int spacePos, LayerMask layer) // returns true if there is a chunk
    {
        Vector3Int checkPos = currentGridPos + spacePos;
        Vector3 worldCheckPos = grid.GetCellCenterWorld(checkPos);

        return Physics2D.CircleCast(worldCheckPos, 5f, Vector3.zero, 0, layer);
    }

}
    public enum Space
    {
        Empty,
        Wall,
        Chunk
    }
