using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnAudio : MonoBehaviour
{
    public AudioPeer _audioPeer;
    [Range(0, 63)]
    public int _audioBand;
    [Range(0f, 1f)]
    public float _audioThreshold;
    private MeshRenderer _meshRenderer;
    public Material _material;
    private Material _materialInstance;
    public Color _color;
    public string _colorProperty;

    private float _strength;
    [Range(0.8f, 0.99f)]
    public float _fallbackFactor;
    [Range(1, 4)]
    public float _colorMultiplier;
    // Use this for initialization
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

          
    }

    // Update is called once per frame
    void Update()
    {
        if (_audioPeer._audioBand64[_audioBand] > _audioThreshold)
        {
            Colorize();
        }

        if (_strength > 0)
        {
            _strength *= _fallbackFactor;
        }
        else
        {
            _strength = 0;
        }

        _materialInstance.SetColor(_colorProperty, _color * _strength * _colorMultiplier);
    }

    void Colorize()
    {
        _strength = 1;
    }
}
