using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class BeatManager : MonoBehaviour {
    private static BeatManager _beatmanagerInstance;

    public LightManager lightManager;
    
    
    //Beat Detection
    public float _bpm;
    private float _beatInterval, _beatTimer, _beatIntervalD8, _beatTimerD8;
    public static bool _beatFull, _beatD8;
    public static int _beatCountFull, _beatCountX2, _beatCountX4, _beatCountX8, _beatCountX16, _beatCountD2, _beatCountD4, _beatCountD8;

    public float[] _tapTime = new float[4];
    public static int _tap;
    public static bool _customBeat;

    private void Awake ()
    {
        _beatmanagerInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
        Tapping();
        BeatDetection();
    }

    void TappinMefoot()
    {
        if(lightManager != null) lightManager.ActivateHexagon();
    }

    void Tapping()
    {
        if ( Input.GetKeyUp(KeyCode.Space))
        {
            _customBeat = true;
            _tap = 0;
        }
        if (_customBeat)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (_tap < 4)
                {
                    _tapTime[_tap] = Time.realtimeSinceStartup;
                    _tap++;
                }
                if(_tap == 4)
                {
                    float averageTime = ((_tapTime[1] - _tapTime[0]) + (_tapTime[2] - _tapTime[1]) + (_tapTime[3] - _tapTime[2])) / 3;
                    _bpm = (float)System.Math.Round((double)60/averageTime, 2);
                    _tap = 0;
                    _beatTimer = 0;
                    _beatTimerD8 = 0;
                    _beatCountFull = 0;
                    _beatCountD2 = 0;
                    _customBeat = false;
                }
            }
        }
    }

    void BeatDetection()
    {
        //normal beat count
        _beatFull = false;

        _beatInterval = 60 / _bpm;
        _beatTimer += Time.deltaTime;

        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _beatFull = true;
            _beatCountFull++;
            // Debug.Log("Full");
            TappinMefoot();
        }
        _beatCountX2 = _beatCountFull % 2;
        _beatCountX4 = _beatCountFull % 4;
        _beatCountX8 = _beatCountFull % 8;
        _beatCountX16 = _beatCountFull % 16;


        //divided beat count
        _beatD8 = false;
        _beatIntervalD8 = _beatInterval / 8;
        _beatTimerD8 += Time.deltaTime;

        if (_beatTimerD8 >= _beatIntervalD8)
        {
            _beatTimerD8 -= _beatIntervalD8;
            _beatD8 = true;
            _beatCountD8++;
            //Debug.Log("D8");
        }
    }
}