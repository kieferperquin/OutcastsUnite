using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleConnectionManager : MonoBehaviour
{
    public static BubbleConnectionManager instance;
    [SerializeField] private GameObject selectorPrefab;
    private List<GameObject> selectedBubbles = new List<GameObject>();
    private GameObject selector;

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

            newWord.GetComponent<WordBubble>().canMove = false;

            SendDataForConnection();
        }
    }

    public void CheckSentence()
    {
        /// send the list selectedBubbles to check the sentence
        List<string> currentPhrase = new List<string>();
        List<string> controlPhrase = PhraseManager.Instance.GetPhrase();

        foreach (GameObject currentWord in selectedBubbles)
        {
            currentPhrase.Add(currentWord.GetComponent<WordBubble>().GetSegment().text);
            Debug.Log(currentWord.GetComponent<WordBubble>().GetSegment().text);
        }
        
        if (currentPhrase.SequenceEqual(controlPhrase))
        {
            Debug.Log("YESSSS");
        }

        /// if the sentence is correct then delete the bubbles the sentence was made with
        
        MakeListEmpty();
    }

    public void Deselect()
    {
        string sentence = null;
        foreach (GameObject currentWord in selectedBubbles)
        {
            sentence += currentWord.GetComponent<WordBubble>().GetSegment().text + " ";
        }

        Debug.Log(sentence);

        Destroy(selector);

        foreach (GameObject word in selectedBubbles)
        {
            word.GetComponent<WordBubble>().canMove = true;

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