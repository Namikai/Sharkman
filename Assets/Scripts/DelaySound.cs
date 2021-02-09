using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay=2;

    void Start()
    {
        audioSource.PlayDelayed(delay);
    }
}