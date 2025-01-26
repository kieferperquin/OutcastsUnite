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

        ConnectionVisualizer.Instance.GiveMouseObj(selector);
    }

    public void NewWordCheck(GameObject newWord)
    {
        if (!selectedBubbles.Contains(newWord))
        {
            selectedBubbles.Add(newWord);

            WordBubble word = newWord.GetComponent<WordBubble>();

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
        Debug.Log(2);
        List<string> currentPhrase = new List<string>();
        List<List<string>> controlPhrases = PhraseManager.Instance.GetPhrases();

        Debug.Log(3);
        foreach (GameObject currentWord in selectedBubbles)
        {
            currentPhrase.Add(currentWord.GetComponent<WordBubble>().GetSegment().text);
        }

        Debug.Log(4);
        foreach (List<string> controlPhrase in controlPhrases)
        {
            if (currentPhrase.SequenceEqual(controlPhrase))
            {
                Player.Instance.CorrectSentence();
                foreach (GameObject go in selectedBubbles)
                {
                    Destroy(go);
                }
            }
        }
        Debug.Log(5);

        Deselect();
    }

    public void Deselect()
    {
        string sentence = null;
        foreach (GameObject currentWord in selectedBubbles)
        {
            sentence += currentWord.GetComponent<WordBubble>().GetSegment().text + " ";
        }

        Destroy(selector);

        foreach (GameObject word in selectedBubbles)
        {
            word.GetComponent<WordBubble>().canMove = true;
        }
        ConnectionVisualizer.Instance.ClearConnections();

        MakeListEmpty();
    }

    void MakeListEmpty()
    {
        selectedBubbles = new List<GameObject>();
    }

    void SendDataForConnection()
    {
        ConnectionVisualizer.Instance.Connect(selectedBubbles[selectedBubbles.Count - 1]);
    }
}