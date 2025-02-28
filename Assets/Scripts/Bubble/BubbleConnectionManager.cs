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
                AudioManager.Instance.PlayConnSound(selectedBubbles.Count);

                word.canMove = false;

                SendDataForConnection();
            }
            else
            {
                AudioManager.Instance.PlayBadConnSound();

                BubbleSpawner.Instance.SpawnBubble(word.GetSegment());

                Destroy(word.gameObject);

                Deselect();
            }
        }
    }

    public void CheckSentence()
    {
        ConnectionVisualizer.Instance.ClearConnections();

        List<string> currentPhrase = new List<string>();
        List<List<string>> controlPhrases = PhraseManager.Instance.GetPhrases();

        foreach (GameObject currentWord in selectedBubbles)
        {
            currentPhrase.Add(currentWord.GetComponent<WordBubble>().GetSegment().text);
        }

        foreach (List<string> controlPhrase in controlPhrases)
        {
            if (currentPhrase.SequenceEqual(controlPhrase))
            {
                Player.Instance.CorrectSentence();
                foreach (GameObject bubbleObj in selectedBubbles)
                {
                    Destroy(bubbleObj);
                }
            }
        }

        Deselect();
    }

    public void Deselect()
    {
        ConnectionVisualizer.Instance.ClearConnections();
        
        Destroy(selector);

        foreach (GameObject word in selectedBubbles)
        {
            if(word != null)
            {
                word.GetComponent<WordBubble>().canMove = true;
            }
        }

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