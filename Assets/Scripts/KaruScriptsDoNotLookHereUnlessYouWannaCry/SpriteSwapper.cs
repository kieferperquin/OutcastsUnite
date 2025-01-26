using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] spriteArray;
    [SerializeField] private float displayTime = 3.0f;

    private int currentSpriteIndex = 0;
    private float timeElapsed = 0f;
    private bool isSwapping = false;

    bool canStart = true;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteArray.Length > 0 && spriteRenderer != null)
        {
            spriteRenderer.sprite = spriteArray[0];
        }
    }

    private void Update()
    {
        if (currentSpriteIndex >= 21)
        {
            StopSwapping();
        }

        if (isSwapping && spriteArray.Length > 0)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= displayTime)
            {
                timeElapsed = 0f;
                currentSpriteIndex = (currentSpriteIndex + 1) % spriteArray.Length;
                spriteRenderer.sprite = spriteArray[currentSpriteIndex];
            }
        }
    }

    public void StartSwapping()
    {
        if (spriteArray == null || spriteArray.Length == 0)
        {
            return;
        }

        isSwapping = true;
        timeElapsed = 0f;
        currentSpriteIndex = 0;
        spriteRenderer.sprite = spriteArray[currentSpriteIndex];
    }

    public void StopSwapping()
    {
        isSwapping = false;
        if (canStart)
        {
            canStart = false;

            BubbleSpawner.Instance.SpawnPlayer();
            PhraseManager.Instance.SpawnNewSetOfPhrases();
            AudioManager.Instance.PlayMusic();
        }
    }
}
