﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public SoundManager _soundManager;
    public AudioClip _tap, _tick;
    public AudioClip[] _strum;
    int _randomStrum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BeatManager._beatFull)
        {
            _soundManager.PlaySound(_tap, 1);
            if (BeatManager._beatCountFull % 2 == 0)
            {
                _randomStrum = Random.Range(0, _strum.Length);
            }

        }
        if (BeatManager._beatCountX8 % 8 == 0)
        {
            _soundManager.PlaySound(_tick, 0.1f);
        }
        if(BeatManager._beatD8 && (BeatManager._beatCountD8 % 8 == 2 || BeatManager._beatCountD8 % 8 == 4))
        {
            _soundManager.PlaySound(_strum[_randomStrum], 1);
        }
    }
}
