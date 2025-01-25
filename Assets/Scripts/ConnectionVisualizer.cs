using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionVisualizer : MonoBehaviour
{
    public static ConnectionVisualizer Instance;

    private LineRenderer lr;

    List<Transform> points = new List<Transform>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(List<Transform> points)
    {
        lr.positionCount = points.Count;
        this.points = points;
    }

    private void Update()
    {
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }

    public void Connect(GameObject a)
    {
        Connect(a.transform);
    }

    public void Connect(Transform a)
    {
        points.Insert(points.Count - 1, a);
        SetUpLine(points);
    }

    public void GiveMouseObj(GameObject mousePosObj)
    {
        GiveMouseObj(mousePosObj.transform);
        SetUpLine(points);
    }

    public void GiveMouseObj(Transform mousePosObj)
    {
        points.Add(mousePosObj);
    }

    public void ClearConnections()
    {
        points.Clear();
        SetUpLine(points);
    }
}