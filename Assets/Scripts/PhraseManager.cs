using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseManager : MonoBehaviour
{
    public static PhraseManager Instance { get; private set; }
    public int LevelIndex = 0;
    public PhraseLibrary PhraseLib;
    [SerializeField] private List<List<string>> currentPhrases = new List<List<string>>();

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

    public void SpawnNewSetOfPhrases()
    {

        if (LevelIndex < LevelHolder.Instance.PhraseLibraries.Count)
        {
            SpawnNewPhrases(LevelHolder.Instance.PhraseLibraries[LevelIndex]);
        }
        else
        {
            /// win screen
        }
    }

    void SpawnNewPhrases(PhraseLibrary library)
    {
        Instance.PhraseLib = library;
     
        SetPhrases();

        int phraseID = 0;

        foreach (List<string> _ in currentPhrases)
        {
            
            foreach (Segment sgmt in Instance.GetSegments(phraseID))
            {
                BubbleSpawner.Instance.SpawnBubble(sgmt);
            }

            phraseID++;
        }

        Player.Instance.SetRings(currentPhrases.Count);
    }

    public void SetPhrases()
    {
        for (int phraseID = 0; phraseID < PhraseLib.Phrases.Count; phraseID++)
        {
            List<string> currentPhrase = new List<string>();

            foreach (Segment segment in PhraseLib.Phrases[phraseID].Segments)
            {
                if (segment.GetType() == typeof(PhraseSegment))
                {
                    currentPhrase.Add(segment.text);
                }
            }

            currentPhrases.Add(currentPhrase);
        }
    }

    public void ClearPhrase() { currentPhrases.Clear(); }
    public List<List<string>> GetPhrases() { return currentPhrases; }
    public List<Segment> GetSegments(int phraseID) { return PhraseLib.Phrases[phraseID].Segments; }
}
