using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleConnectionManager : MonoBehaviour
{
    /// <summary> steps to take
    /// 
    /// 1. i need to check for when i select if i am on a bubble
    /// 2. if i am on a bubble then i need to put it in a list 
    /// 3. and while holding down the select button and i hover over a different bubble that is not in the list do step 2
    /// 4. if i release the select button than the list will be reset
    /// 5. if i hover over the "player" then then i will send the list of strings to somethings james will make to check if the centence is correct
    /// 
    /// </summary>
     
    List<GameObject> selectedBubbles = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Select()
    {

    }

    void SendDataForConnection()
    {
        if (selectedBubbles.Count <= 1) return;

        GameObject pointA = selectedBubbles[selectedBubbles.Count - 2];
        GameObject pointB = selectedBubbles[selectedBubbles.Count - 1];

        /// send pointA and pointB to connectionvisualizer script
    }
}
    /*
    void connectionvisualizer(Transform a, Transform b)
    {

    }

    void connectionvisualizer(GameObject a, GameObject b)
    {
        connectionvisualizer(a.transform, b.transform);
    }*/