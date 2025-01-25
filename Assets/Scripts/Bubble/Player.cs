using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Bubble
{
    public static Player Instance;

    [SerializeField] private GameObject protactiveBubble;
    [SerializeField] private GameObject pbPlacement;
    [SerializeField] int amountProtection;

    List<GameObject> spawnedProtection = new List<GameObject>();

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

    private void OnCollisionEnter(Collision collision)
    {
        ChangeTargetPos(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        ChangeTargetPos(collision);
    }

    public void CorrectSentence()
    {
        amountProtection -= 1;

        /// play animation if we want/ have time

        ChangeVisuals();

        if (amountProtection <= 0)
        {
            /// win / clear level
            BubbleSpawner.Instance.LevelClear();
        }
    }

    public void SetRings(int rings)
    {
        amountProtection = rings;
        ChangeVisuals();
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