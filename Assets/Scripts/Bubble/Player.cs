using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private GameObject protactiveBubble;
    [SerializeField] private GameObject pbPlacement;
    int amountProtection;

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
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {

    }

    public void CorrectCentance()
    {
        amountProtection -= 1;

        ChangeVisuals();

        if (amountProtection <= 0)
        {
            /// win / clear level
        }
    }

    void ChangeVisuals()
    {

    }
}