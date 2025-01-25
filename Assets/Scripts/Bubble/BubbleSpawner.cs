using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public static BubbleSpawner Instance;

    [SerializeField] private GameObject bubblesLocation;
    [SerializeField] private GameObject bubblePrefab;

    List<GameObject> bubbles = new List<GameObject>();

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

    public void SpawnBubble(string wordToGive)
    {
        GameObject bubble = Instantiate(bubblePrefab, bubblesLocation.transform);

        bubble.GetComponent<Bubble>().GiveWord(wordToGive);

        //give the bubble a random position

        bubbles.Add(bubble);
    }
}