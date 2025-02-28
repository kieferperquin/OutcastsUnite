using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public static BubbleSpawner Instance;

    [SerializeField] private GameObject bubbleContainer;
    [SerializeField] private List<GameObject> bubblePrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> obstaclePrefabs = new List<GameObject>();

    [SerializeField] private GameObject playerObj;
    
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

    public void SpawnPlayer()
    {
        Instantiate(playerObj);
    }

    public void SpawnBubble(Segment segment)
    {
        // Determine word length / bubble size
        int prefabID = 2;
        if (segment.text.Length < 24) { prefabID = 1; }
        if (segment.text.Length < 13) { prefabID = 0; }

        // Determine bubble type.
        GameObject prefab;
        if (segment.GetType() == typeof(PhraseSegment)) { prefab = bubblePrefabs[prefabID]; }
        else { prefab = obstaclePrefabs[prefabID]; }

        //give the bubble a random position
        GameObject bubble = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity, bubbleContainer.transform);

        bubble.GetComponent<WordBubble>().SetSegment(segment);
    }

    public void LevelClear()
    {
        /*while(bubbleContainer.transform.childCount > 0)
        {
            Destroy(bubbleContainer.transform.GetChild(0).gameObject);
        }*/

        foreach (Transform bubble in bubbleContainer.transform)
        {
            Destroy(bubble.gameObject);
        }

        PhraseManager manager = PhraseManager.Instance;

        manager.LevelIndex++;
        manager.ClearPhrase();
        manager.SpawnNewSetOfPhrases();
    }
}