using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerLogic : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private LayerMask chunks;
    [SerializeField]
    private Vector3Int[] moveDirections =
    {
        Vector3Int.up,
        Vector3Int.down,
        Vector3Int.left,
        Vector3Int.right
    };

    private void Awake()
    {
        grid = LevelGenerationManager.Instance.grid;
    }

    public void MoveSeeker()
    {
        Vector3Int currentGridPos = grid.WorldToCell(transform.position);

        Vector3Int newPos = currentGridPos + moveDirections[Random.Range(0, moveDirections.Length)];

        transform.position = grid.GetCellCenterWorld(newPos);
    }

    public void ChooseAction()
    {
        if(Physics2D.CircleCast(transform.position, 0.5f, Vector3.zero, 0, chunks))
        {
            LevelGenerationManager.Instance.SeekerSpawn(transform.position);
        }
        else
        {
            LevelGenerationManager.Instance.ChunkSpawn(transform.position);
        }
    }
}
