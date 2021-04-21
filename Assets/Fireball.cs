using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    
    private float _speed = 8f;
    private float _lifeDuration = 2f;
    private float _lifeTimer;

    private void Start()
    {
        _lifeTimer = _lifeDuration;
        MoveController();
        ParticleSystem.Play();
    }

    private void Update()
    {
        MoveController();
    }

    private void MoveController()
    {
        transform.position += transform.forward * (_speed * Time.deltaTime);

        _lifeTimer -= Time.deltaTime;

        if (_lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
