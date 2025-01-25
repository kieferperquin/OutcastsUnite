using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionVisualizer : MonoBehaviour
{
    public static ConnectionVisualizer Instance;

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
    }

    public void Connect(GameObject a, GameObject b)
    {
        Connect(a.transform, b.transform);
    }

    public void Connect(Transform a, Transform b)
    {
        /// connect A to B and save it
    }

    public void ClearConnections()
    {
        /// destroy all saved connections
    }
}