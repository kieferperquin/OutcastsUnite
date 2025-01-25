using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBubble : Bubble
{
    [SerializeField] private GameObject bubbleWord;
    [SerializeField] private Segment segment;

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

    public Segment GetSegment()
    {
        return segment;
    }
    public void SetSegment(Segment sgmt)
    {
        segment = sgmt;
        bubbleWord.GetComponent<Text>().text = segment.text;
    }
}