using Assets.Scripts.Models;
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
        SceneSize size = new SceneSize();

        rightWall.transform.position = new Vector3(size.sceneMaxX + (rightWall.size.x / 2), 0);
        leftWall.transform.position = new Vector3(size.sceneMinX - (leftWall.size.x / 2), 0);
        topWall.transform.position = new Vector3(0, size.sceneMaxY + (topWall.size.y / 2));
        bottomWall.transform.position = new Vector3(0, size.sceneMinY - (bottomWall.size.y / 2));

        topWall.size = new Vector3(size.sceneMaxX - size.sceneMinX, topWall.size.y);
        bottomWall.size = new Vector3(size.sceneMaxX - size.sceneMinX, bottomWall.size.y);
    }
}
