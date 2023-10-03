using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkLogic : MonoBehaviour
{
    public float chunkRadius;
    public bool locked = false;

    [SerializeField] private LayerMask chunkLayer;

    public bool[] chunkDirection; // 0 = up, 1 = down, 2 = left, 3 = right

    private void Update()
    {
        ChunkDirecitonCheck();
        locked = Array.TrueForAll(chunkDirection, x => x == true); // checks if chunk is locked
    }

    private void ChunkDirecitonCheck()
    {
        chunkDirection[0] = ChunkCheck(Vector2.up);
        chunkDirection[1] = ChunkCheck(Vector2.down);
        chunkDirection[2] = ChunkCheck(Vector2.left);
        chunkDirection[3] = ChunkCheck(Vector2.right);
    }

    private bool ChunkCheck(Vector3 direction)
    {
        Vector3 origin = transform.position + direction;

        return Physics2D.CircleCast(origin, chunkRadius, direction, 0, chunkLayer);
    }
}
