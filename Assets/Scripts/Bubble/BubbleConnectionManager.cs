using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleConnectionManager : MonoBehaviour
{
    public static BubbleConnectionManager instance;

    /// <summary> steps to take
    /// 
    /// 5. if i hover over the "player" then then i will send the list of strings to somethings james will make to check if the centence is correct
    /// 
    /// </summary>

    [SerializeField] private GameObject selectorPrefab;

    List<GameObject> selectedBubbles = new List<GameObject>();

    GameObject selector;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Select()
    {
        selector = Instantiate(selectorPrefab);
    }

    public void NewWordCheck(GameObject newWord)
    {
        if (!selectedBubbles.Contains(newWord))
        {
            selectedBubbles.Add(newWord);

            newWord.GetComponent<Bubble>().canMove = false;

            SendDataForConnection();
        }
    }

    public void CheckCentence()
    {
        /// send the list selectedBubbles to check the centence

        Debug.Log("check");

        /// if the centence is correct then delete the bubbles the centence was made with
        
        MakeListEmpty();
    }

    public void Deselect()
    {
        string centence = null;
        foreach (GameObject newWord in selectedBubbles)
        {
            centence += newWord.GetComponent<Bubble>().GetWord() + " ";
        }

        Debug.Log(centence);

        Destroy(selector);

        foreach (GameObject word in selectedBubbles)
        {
            word.GetComponent<Bubble>().canMove = true;

            /// make the lines that are connected to this bubble dissapear

        }

        selectedBubbles = new List<GameObject>();
    }

    void MakeListEmpty()
    {
        selectedBubbles = new List<GameObject>();
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