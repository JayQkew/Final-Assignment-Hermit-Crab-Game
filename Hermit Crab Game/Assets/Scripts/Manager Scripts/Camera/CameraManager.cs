using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [Header("Player Follow")]
    [SerializeField] private float lerpSpeed;
    [SerializeField] private GameObject player;
    [SerializeField] private float lookDistance;
    [SerializeField] private float lookDistanceMultiplier;
    private Vector3[] lookPosition =
    {
        new Vector3 (0, 3, -10),
        new Vector3 (0, -3, -10),
        new Vector3 (-3, 0, -10),
        new Vector3 (3, 0, -10),
        new Vector3 (-2, 2, -10),
        new Vector3 (2, 2, -10),
        new Vector3 (2, -2, -10),
        new Vector3 (-2, -2, -10),
    };
    [SerializeField] private Vector3[] updatedLookPosition = new Vector3[8];
    [SerializeField] private Vector3 chosenLookPosition;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CalculateLookPositions();
        MoveCamera();

        #region INPUTS
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A)) chosenLookPosition = updatedLookPosition[4] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.D)) chosenLookPosition = updatedLookPosition[5] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.S)) chosenLookPosition = player.transform.position;
            else chosenLookPosition = updatedLookPosition[0] * lookDistanceMultiplier;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A)) chosenLookPosition = updatedLookPosition[7] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.D)) chosenLookPosition = updatedLookPosition[6] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.W)) chosenLookPosition = player.transform.position;
            else chosenLookPosition = updatedLookPosition[1] * lookDistanceMultiplier;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W)) chosenLookPosition = updatedLookPosition[4] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.S)) chosenLookPosition = updatedLookPosition[7] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.D)) chosenLookPosition = player.transform.position;
            else chosenLookPosition = updatedLookPosition[2] * lookDistanceMultiplier;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W)) chosenLookPosition = updatedLookPosition[5] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.S)) chosenLookPosition = updatedLookPosition[6] * lookDistanceMultiplier;
            else if (Input.GetKey(KeyCode.A)) chosenLookPosition = player.transform.position;
            else chosenLookPosition = updatedLookPosition[3] * lookDistanceMultiplier;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            chosenLookPosition = player.transform.position + new Vector3(0, 0, -10);
        }
        #endregion

    }

    private void CalculateLookPositions()
    {
        for (int i = 0; i < lookPosition.Length; i++)
        {
            updatedLookPosition[i] = player.transform.position + lookPosition[i];
        }
    }

    private void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, chosenLookPosition, lerpSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(player.transform.position, chosenLookPosition);
    }
}
