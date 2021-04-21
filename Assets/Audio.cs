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
        _characterController = GetComponentInParent<CharacterController>();
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

        if (_characterController.velocity.sqrMagnitude > 0)
        {
            _accumulatedDistance += Time.deltaTime;

            if (_accumulatedDistance > _stepDistance)
            {
                _audioSource.volume = UnityEngine.Random.Range(_volumeMin, _volumeMax);
                _audioSource.clip = _audioClips[UnityEngine.Random.Range(0, _audioClips.Length)];
                _audioSource.Play();

                _accumulatedDistance = 0f;
            }
            else
            {
                _accumulatedDistance = 0f;
            }
        }
        
    }
}
