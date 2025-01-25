using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
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
    }
}