using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private GameObject protactiveBubble;
    [SerializeField] private GameObject pbPlacement;
    [SerializeField] int amountProtection;

    List<GameObject> spawnedProtection = new List<GameObject>();

    [SerializeField] private float areaSize;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ChangeVisuals();
    }

    private void Update()
    {
        Movement();
        RotateBubble();
    }

    void Movement()
    {
        Vector3 newLoc = GetRandomPos(transform.position);

        Debug.Log(newLoc);

        /// use the newLoc vector to move with the moveSpeed variable


    }


    Vector3 GetRandomPos(Vector2 currLoc)
    {
        Vector2 areaAddetive = new Vector2(areaSize, areaSize);

        Vector2 maxArea = currLoc + areaAddetive;
        Vector2 minArea = currLoc - areaAddetive;

        return new Vector3(Random.Range(maxArea.x, minArea.x), Random.Range(maxArea.y, minArea.y), 0);
    }

    void RotateBubble()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    public void CorrectCentance()
    {
        amountProtection -= 1;

        /// play animation if we want/ have time

        ChangeVisuals();

        if (amountProtection <= 0)
        {
            /// win / clear level
        }
    }

    void ChangeVisuals()
    {
        ClearList(spawnedProtection);

        for (int i = 0; i < amountProtection; i++)
        {
            GameObject protection = Instantiate(protactiveBubble, pbPlacement.transform);

            float scaleSize = 1 + (.1f * i);

            protection.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);

            spawnedProtection.Add(protection);
        }
    }


    void ClearList(List<GameObject> listToChange)
    {
        if (listToChange.Count <= 0 || listToChange == null) return;

        foreach (GameObject obj in listToChange)
        {
            Destroy(obj);
        }

        listToChange = new List<GameObject>();
    }
}