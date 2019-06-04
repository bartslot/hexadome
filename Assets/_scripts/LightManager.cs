using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public AudioPeer _audioPeer;
    private GameObject[] _hexagonList;
    private GameObject _hexagonInstance;

    private bool[] _fade;
    private float[] _emissionStrengths;

    public Transform _target;

    [Range(0, 7)]
    public int _audioBand;
    [Range(0, 4)]
    public int _patternRandom = 0;

    [Range(0f, 1f)]
    public float _audioThreshold;
    MeshRenderer _meshRenderer;
    Material[] _materialInstance;
    public Material _material;

    public Color _color;
    public float _emissionStrength = 2f, emissionFadeSpeed = 2f, emissionFadeOutSpeed = 2f;
    public string _colorProperty;

    private float _strength;
    [Range(0.8f, 0.99f)]
    public float _fallbackFactor;
    [Range(1, 4)]
    public float _colorMultiplier;
    private float _emit;

    private void Awake()
    {
        _hexagonList = GameObject.FindGameObjectsWithTag("hexagon").OrderBy(go => go.name).ToArray();
        _fade = new bool[_hexagonList.Length];
        _emissionStrengths = new float[_hexagonList.Length];
    }

    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < _hexagonList.Length; i++)
        {
            if (_hexagonList[i].GetComponent<MeshRenderer>() != null)
            {
                _meshRenderer = _hexagonList[i].GetComponent<MeshRenderer>();

                _material = _meshRenderer.material;


                _material.SetColor("_EmissionColor", _color * 0);
                _emissionStrengths[i] = 0;
            }
            //_materialInstance = new Material(_material);
            //_materialInstance.EnableKeyword("_EmissionColor");
            //_meshRenderer.material = _materialInstance;

        }
        if (_target != null) _meshRenderer = _target.GetComponent<MeshRenderer>();
        else _meshRenderer = GetComponent<MeshRenderer>();
        //_strength = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //if (_audioPeer._audioBand64[_audioBand] > _audioThreshold)
        //{
        //    Colorize();
        //    Pattern();
        //}

        if (_strength > 0)
        {
            _strength *= _fallbackFactor;
        }
        else
        {
            _strength = 0;
        }

        // _hexagonList[3]._materialInstance.SetColor(_colorProperty, _color * _strength * _colorMultiplier);

        for(int i = 0; i < _hexagonList.Length; i++) if (_fade[i])
        {
            _meshRenderer = _hexagonList[i].GetComponent<MeshRenderer>();
            _material = _meshRenderer.material;

            _emit = _emissionStrengths[i];
            _emit = Mathf.Lerp(_emit, _emissionStrength, Time.deltaTime * emissionFadeSpeed);

            _material.SetColor("_EmissionColor", _color * _emit);
            _emissionStrengths[i] = _emit;

            if (_emit >= _emissionStrength) FadeOut();
        }
    }

    public void ActivateHexagon(int i = -1)
    {
        if (i < 0) i = Random.Range(0, _hexagonList.Length);
        _fade[i] = true;
    }






    // Get some fadeOut 









    private void Colorize()
    {
        _strength = 1;
    }





    private void FadeOut()
    {
        _emit = Mathf.Lerp(_emit, _emissionStrength, Time.deltaTime / emissionFadeSpeed);
    }
    private void Pattern()
    {
        for (int i = 0; i < (_hexagonList.Length); i++)
        {
            if (BeatManager._beatFull)
            {
                int _patternRandom = Random.Range(0, 4);

                for (int y = 0; y < (_hexagonList.Length); y++)
                {
                    y = y * (y % _patternRandom);
                }
            }
        }  
    }
}
