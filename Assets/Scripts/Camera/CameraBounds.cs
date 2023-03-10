using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    // Public Variables //
    public GameObject Bounds1;
    public GameObject Bounds2;


    // Private Variables //
    private Camera _Camera;
    private EdgeCollider2D _CameraEdgeCollider;
    private float _Width, _Height;

    // Start is called before the first frame update
    void Awake()
    {
        AwakeComponents();
        AwakeCalculateSizes();

        //Boundy Area
        _CameraEdgeCollider.points = SetCameraBounds();

        //EndGame Area
        AwakeCreateGameOverbounds();
    }

    private void AwakeComponents()
    {
        //Get Components
        _Camera = Camera.main.GetComponent<Camera>();
        _CameraEdgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void AwakeCalculateSizes()
    {
        _Width = 1 / (_Camera.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
        _Height = 1 / (_Camera.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f);
    }

    private Vector2[] SetCameraBounds()
    {
        Vector2[] tempArray;
        Vector2 point1 = new Vector2(_Width / 2, _Height / 2);
        Vector2 point2 = new Vector2(_Width / 2, -_Height / 2);
        Vector2 point3 = new Vector2(-_Width / 2, -_Height / 2);
        Vector2 point4 = new Vector2(-_Width / 2, _Height / 2);
        
        tempArray = new Vector2[] { point3, point4, point1, point2 };

        Bounds1.transform.position = point4;
        Bounds2.transform.position = point1;

        return tempArray;
    }

    private void AwakeCreateGameOverbounds()
    {
        GameObject gameObject = new GameObject("==GameOver==");
        gameObject.transform.SetParent(transform, false);
        EdgeCollider2D gameOverEdges = gameObject.AddComponent<EdgeCollider2D>();

        gameObject.tag = "GameOver";

        gameOverEdges.points = SetGameOverBounds();
    }

    private Vector2[] SetGameOverBounds()
    {
        Vector2[] tempArray;
        Vector2 point2 = new Vector2(_Width / 2, -_Height / 2);
        Vector2 point3 = new Vector2(-_Width / 2, -_Height / 2);

        tempArray = new Vector2[] { point2, point3 };

        return tempArray;

    }
}
