using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] private GameObject bubbleWord;

    bool canMove;

    private void Update()
    {
        if (canMove) Movement();
    }

    void Movement()
    {

    }

    public string GetWord()
    {
        return bubbleWord.GetComponent<Text>().text;
    }
    public void GiveWord(string word)
    {
        bubbleWord.GetComponent<Text>().text = word;
    }
}