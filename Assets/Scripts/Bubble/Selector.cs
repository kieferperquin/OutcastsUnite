using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Selector : MonoBehaviour
{
    [SerializeField] private InputAction CursorPos;

    Vector3 pos;

    void Update()
    {
        pos = Input.mousePosition;
        pos.z = 11.8f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble") || other.CompareTag("Obstacle"))
        {
            BubbleConnectionManager.Instance.NewWordCheck(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            BubbleConnectionManager.Instance.CheckSentence();
        }
    }
}