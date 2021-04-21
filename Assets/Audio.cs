using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource _audioSource;
   
    [SerializeField]
    private AudioClip[] _audioClips;

    private CharacterController _characterController;

    private float _volumeMin, _volumeMax;

    private float _accumulatedDistance;
    private float _stepDistance;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckToPlaySoundController();
    }

    private void CheckToPlaySoundController()
    {
        //TODO: do fly sounds
        if (!_characterController.isGrounded) 
            return;
        
    }
}
