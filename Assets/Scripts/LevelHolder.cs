using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    public static LevelHolder Instance { get; private set; }

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

    public List<PhraseLibrary> PhraseLibraries;
}
