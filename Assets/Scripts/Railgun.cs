﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railgun : MonoBehaviour
{

    [SerializeField]
    private Turret myGun;
    [SerializeField]
    private bool shouldFire;

    public AudioClip railgun_activate;
    Animator animator;
    AudioSource _audio;

    private bool _shooting = false;
    private bool _active = false;

    public bool isShooting
    {
        get { return _shooting; }
        set
        {
            animator.SetBool("shooting", value);
            _shooting = value;
        }
    }

    public bool isActive
    {
        get { return _active; }
        set
        {
            if (value && !_active && railgun_activate != null)
            {
                _audio.PlayOneShot(railgun_activate);
            }
            animator.SetBool("activated", value);
            _active = value;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    public void FireLaser(string whichone)
    {
        if (shouldFire)
        {
            myGun.StartCoroutine("Shoot" + whichone);
            _audio.Play();
        }
    }
}
