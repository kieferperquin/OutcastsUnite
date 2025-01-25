using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseManager : MonoBehaviour
{
    public static PhraseManager Instance { get; private set; }

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

        SetPhrase();
    }

    public PhraseLibrary PhraseLib;
    public int PhraseID;
    [SerializeField] private List<string> currentPhrase;

    public void SetPhrase()
    {
        foreach (Segment phraseSgmt in PhraseLib.Phrases[PhraseID].Segments)
        {
            if (phraseSgmt.GetType() == typeof(PhraseSegment))
            {
                currentPhrase.Add(phraseSgmt.text);
            }
        }
    }

    public void ClearPhrase() { currentPhrase.Clear(); }

    public List<string> GetPhrase() { return currentPhrase; }
    public List<Segment> GetSegments() { return PhraseLib.Phrases[PhraseID].Segments; }
}
