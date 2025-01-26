using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPop : MonoBehaviour
{
    [SerializeField] private ParticleSystem pSystem;

    private void Update()
    {
        if(pSystem.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
