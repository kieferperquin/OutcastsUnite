using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBubble : Bubble
{
    [SerializeField] private GameObject bubbleWord;

    public bool canMove = true;

    private void Update()
    {
        if (canMove) Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChangeTargetPos(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        ChangeTargetPos(collision);
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