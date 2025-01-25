using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float areaSize;

    private Vector3 targetPos;

    public bool canMove = true;

    public void Movement()
    {
        if(!canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, moveSpeed * Time.deltaTime);
            return;
        }


        if (targetPos == null)
        {
            targetPos = GetRandomPos(transform.position);
        }
        if (targetPos == transform.position)
        {
            targetPos = GetRandomPos(transform.position);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    Vector3 GetRandomPos(Vector2 currLoc)
    {
        Vector2 areaAddetive = new Vector2(areaSize, areaSize);

        Vector2 maxArea = currLoc + areaAddetive;
        Vector2 minArea = currLoc - areaAddetive;

        return CheckAllowed(new Vector3(Random.Range(maxArea.x, minArea.x), Random.Range(maxArea.y, minArea.y), 0));
    }

    Vector3 CheckAllowed(Vector3 pos)
    {
        float X = 5.2f;
        float Y = 2.5f;

        pos.x = Mathf.Clamp(pos.x, -X, X);
        pos.y = Mathf.Clamp(pos.y, -Y, Y);

        return pos;
    }
    public void RotateBubble()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    public void ChangeTargetPos(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            targetPos = GetRandomPos(transform.position);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            targetPos = GetRandomPos(transform.position);
        }
    }
}