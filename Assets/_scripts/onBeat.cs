using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class onBeat : MonoBehaviour
{
    public BeatManager _soundManager;
    public AudioClip _tap, _tick;
    public AudioClip[] _strum;
    int _randomStrum;

    public int beatSection;
    public int _bankSize;

    private List<AudioSource> _soundClip;


    public Transform[] _prefabPos;
    public AudioMixer _audioMixer;


    // Use this for initialization
    void Start() {

        _soundClip = new List<AudioSource>();
        for (int i = 0; i < _bankSize; i++)
        {
            GameObject soundInstance = new GameObject("sound");
            soundInstance.AddComponent<AudioSource>();
            soundInstance.transform.parent = this.transform;
            _soundClip.Add(soundInstance.GetComponent<AudioSource>());
        }
        beatSection = 0;
    }
    public void PlaySound(AudioClip clip, float volume)
    {
        for (int i = 0; i < _soundClip.Count; i++)
        {
            if(!_soundClip[i].isPlaying)
            {
                _soundClip[i].clip = clip;
                _soundClip[i].volume = volume;
                _soundClip[i].Play();
                return;

            }
        }
        GameObject soundInstance = new GameObject("sound");
        soundInstance.AddComponent<AudioSource>();
        soundInstance.transform.parent = this.transform;
        soundInstance.GetComponent<AudioSource>().clip = clip;
        soundInstance.GetComponent<AudioSource>().volume = volume;
        soundInstance.GetComponent<AudioSource>().Play();
        _soundClip.Add(soundInstance.GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update() {
        if (BeatManager._beatFull) {

            if (BeatManager._beatFull == true)
            {

            }
            beatSection++;
            _audioMixer.SetFloat("lowcutoff", Random.Range(500f, 10000f));
            _audioMixer.SetFloat("delayecho", Random.Range(500f, 10000f));
        }
        if (/*beatSection == 1 &&*/ BeatManager._beatCountX8 == 0 && BeatManager._beatFull) {
            //GameObject prefab = (GameObject)Instantiate(_prefab[0]);
            
            // change shit;
        }
    }
}
