using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepSFX;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float playRate;
    private float _lastPlayTime;

    private void Update()
    {
        if (rig.velocity.magnitude > 0 && Time.time - _lastPlayTime > playRate)
        {
            Play();
        }
    }

    void Play()
    {
        _lastPlayTime = Time.time;

        AudioClip clipToPlay = footstepSFX[Random.Range(0, footstepSFX.Length)];
        audioSource.PlayOneShot(clipToPlay);
    }
}
