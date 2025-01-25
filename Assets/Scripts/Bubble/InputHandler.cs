using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    List<string> alphabed = new List<string>() {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

    int lettercount = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            BubbleConnectionManager.instance.Select();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            BubbleConnectionManager.instance.Deselect();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Segment sgmt in PhraseManager.Instance.GetSegments())
            {
                BubbleSpawner.Instance.SpawnBubble(sgmt);
            }
        }
    }
}