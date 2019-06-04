using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class BeatSequencer : MonoBehaviour
{
    public bool _updateInPlaymode;

    [BeatPattern(32,8)]
    public string[] _patternD8;
    public int _countD8;
    private int _countD8LastFrame;
    [HideInInspector]
    public bool _patternD8Complete;
    public bool[][] _patternD8Bool;
    private string[] _patternD8String;

    // Start is called before the first frame update
    void Start()
    {
        _patternD8Bool = new bool[_patternD8.Length][];
        SetPatternBooleans(_patternD8, _patternD8Bool, false, 0);
        _patternD8String = new string[_patternD8.Length];
    }

    // Update is called once per frame
    void Update()
    {
        CheckPatternCompleted();
        if (_updateInPlaymode)
        {
            for (int i = 0; i < _patternD8.Length; i++)
            {
                if (_patternD8String[i] != _patternD8[i])
                {
                    SetPatternBooleans(_patternD8, _patternD8Bool, true, i);
                    _patternD8String[i] = _patternD8[i];
                }
            }
        }
    }
    void SetPatternBooleans(string[] beatPattern, bool[][] boolPattern, bool specificPattern, int specificIndex)
    {
        for (int i = 0; i < beatPattern.Length; i++)
        {
            boolPattern[i] = new bool[beatPattern[i].Length];
            StringBuilder sb = new StringBuilder(beatPattern[i]);
            for (int j = 0; j < sb.Length; j++)
            {
                if (sb[j] == '1')
                {
                    boolPattern[i][j] = true;
                }
                else
                {
                    boolPattern[i][j] = false;
                }
            }

        }
        if (specificPattern)
        {
            StringBuilder sb = new StringBuilder(beatPattern[specificIndex]);
            for (int j = 0; j < sb.Length; j++)
            {
                if (sb[j] == '1')
                {
                    boolPattern[specificIndex][j] = true;
                }
                else
                {
                    boolPattern[specificIndex][j] = false;
                }
            }
        }
    }

    void CheckPatternCompleted()
    {
        if (_patternD8Complete) { _patternD8Complete = false; }
        _countD8LastFrame = _countD8;
        _countD8 = BeatManager._beatCountD8 % 32;

       if (_countD8 == 0 && _countD8LastFrame != _countD8)
        {
            _patternD8Complete = true;
        }
    }
}
