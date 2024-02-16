using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScalar : MonoBehaviour
{
    private Board board;
    public float cameraOffset;
    public float aspectRatio = 0.625f;
    public float padding = 2;
    public float yOffset = 0.5f;
    private void Start()
    {
        board = FindObjectOfType<Board>();
        if(board != null)
        {
            RepositionCamera(board.width -1, board.height -1);
        }
    }

    private void RepositionCamera(float width, float height)
    {
        Vector3 tempPosition = new Vector3(width / 2, height / 2 + yOffset, cameraOffset);
        transform.position = tempPosition;
        if(board.width >= board.height )
        {
            Camera.main.orthographicSize = (board.width / 2 + padding) / aspectRatio;
        }
        else
        {
            Camera.main.orthographicSize = (board.height / 2 + padding) +2 *yOffset;
        }
    }
}
