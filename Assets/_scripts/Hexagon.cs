using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public int _band;
    public bool _useBuffer;

    public int _redIntensity;
    public int _greenIntensity;
    public int _blueIntensity;
    


    Material _material;
    Color _color;


    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            //Bass
            if (_band <= 1)
            {
                if (AudioPeer._audioBandBuffer[_band] >= .4) { 
                    _color = new Color(AudioPeer._audioBandBuffer[_band], (1.1f * AudioPeer._audioBandBuffer[_band]), AudioPeer._audioBandBuffer[_band]);
                } else
                {
                    _color = new Color(_redIntensity, _greenIntensity, _blueIntensity);
                }
            }

            for (int i = 0; i < 32; i++)
            {
                if (i % 3 == 0) {
                   
                }
            }


            //Midtones
            if (_band >= 2)
            {
                _color = new Color(0, 200, AudioPeer._audioBandBuffer[_band]);

            }
            //Highs
            if (_band >= 6)
            {
                _color = new Color(AudioPeer._audioBandBuffer[_band], (AudioPeer._audioBandBuffer[_band] * -1.1f), 0);

            }

            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer)
        {
            Color _color = new Color(AudioPeer._audioBand[_band], AudioPeer._audioBand[_band], AudioPeer._audioBand[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
