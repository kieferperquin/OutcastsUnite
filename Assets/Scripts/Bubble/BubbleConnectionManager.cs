using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubbleConnectionManager : MonoBehaviour
{
    public static BubbleConnectionManager Instance;
    [SerializeField] private GameObject selectorPrefab;
    private List<GameObject> selectedBubbles = new List<GameObject>();
    private GameObject selector;

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

    public void Select()
    {
        selector = Instantiate(selectorPrefab);
    }

    public void NewWordCheck(GameObject newWord)
    {
        if (!selectedBubbles.Contains(newWord))
        {
            selectedBubbles.Add(newWord);

            WordBubble word = newWord.GetComponent<WordBubble>();

            Debug.Log(word.GetSegment().GetType());

            if (word.GetSegment().GetType() == typeof(PhraseSegment))
            {
                word.canMove = false;

                SendDataForConnection();
            }
            else
            {
                BubbleSpawner.Instance.SpawnBubble(word.GetSegment());

                Destroy(word.gameObject);

                Deselect();
            }
        }
    }

    public void CheckSentence()
    {
        List<string> currentPhrase = new List<string>();
        List<string> controlPhrase = PhraseManager.Instance.GetPhrase();

        foreach (GameObject currentWord in selectedBubbles)
        {
            currentPhrase.Add(currentWord.GetComponent<WordBubble>().GetSegment().text);
        }
        
        if (currentPhrase.SequenceEqual(controlPhrase))
        {
            Player.Instance.CorrectSentence();
            foreach (GameObject go in selectedBubbles)
            {
                Destroy(go);
            }
        }
        
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

        MakeListEmpty();
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
        ConnectionVisualizer.Instance.Connect(pointA, pointB);
    }
}