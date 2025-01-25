using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Selector : MonoBehaviour
{
    [SerializeField] private InputAction CursorPos;

    Vector3 pos;

    void Update()
    {
        pos = Input.mousePosition;
        pos.z = 6;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");

        if (other.CompareTag("Bubble"))
        {
            BubbleConnectionManager.instance.NewWordCheck(other.gameObject);
        }

        if(other.CompareTag("Player"))
        {
            BubbleConnectionManager.instance.CheckSentence();
        }
    }
}