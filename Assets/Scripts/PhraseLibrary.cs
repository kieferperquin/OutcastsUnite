using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PhraseLibrary/New Library")]
public class PhraseLibrary : ScriptableObject
{
    
    public List<Phrase> Phrases = new List<Phrase>();

    List<Segment> GetPhraseSegmentsByID(int id)
    {
        return Phrases[id].Segments;
    }
}

[System.Serializable]
public class Phrase
{
    [SerializeReference, SubclassSelector]
    public List<Segment> Segments = new List<Segment>();
}

[System.Serializable]
public abstract class Segment
{
    public string text;
}

[System.Serializable]
public class PhraseSegment : Segment
{
    
}

[System.Serializable]
public class ObstacleSegment : Segment
{
    
}
