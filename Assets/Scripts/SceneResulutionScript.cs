using Assets.Scripts.Models;
using Assets.Scripts.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneResulutionScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D topWall;
    [SerializeField] private BoxCollider2D bottomWall;
    [SerializeField] private BoxCollider2D rightWall;
    [SerializeField] private BoxCollider2D leftWall;

    // Start is called before the first frame update
    void Start()
    {
        SetWallColliders();
    }
    void SetWallColliders()
    {
        ObjectsPositionsService getObjectsPositions = new ObjectsPositionsService();

        rightWall.transform.position = getObjectsPositions.GetRightWallPositionByScene(rightWall);
        leftWall.transform.position = getObjectsPositions.GetLeftWallPositionByScene(leftWall);
        topWall.transform.position = getObjectsPositions.GetTopWallPositionByScene(topWall);
        bottomWall.transform.position = getObjectsPositions.GetBottomWallPositionByScene(bottomWall);

        ObjectsSizesService getObjectsSizes= new ObjectsSizesService();
        topWall.size = getObjectsSizes.GetHorizontalWallSizeByScene(topWall);
        bottomWall.size = getObjectsSizes.GetHorizontalWallSizeByScene(bottomWall);
    }
}
