using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] private GameObject VfxObj;

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
            GetNewPosition();
        }
        if (targetPos == transform.position)
        {
            GetNewPosition();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    Vector3 GetRandomPos(Vector2 currLoc)
    {
        Vector2 areaAddetive = new Vector2(areaSize, areaSize);

        Vector2 maxArea = currLoc + areaAddetive;
        Vector2 minArea = currLoc - areaAddetive;

        return new Vector3(Random.Range(maxArea.x, minArea.x), Random.Range(maxArea.y, minArea.y), 0);
    }

    public void RotateBubble()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    public void ChangeTargetPos(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            GetNewPosition();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GetNewPosition();
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            GetNewPosition();
        }
    }

    void GetNewPosition()
    {
        targetPos = GetRandomPos(transform.position);
    }

    private void OnDestroy()
    {
        Instantiate(VfxObj).gameObject.transform.position = transform.position;
    }
}