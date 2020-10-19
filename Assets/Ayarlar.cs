using UnityEngine;
using System.Collections;

public class Ayarlar : MonoBehaviour {
    AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.mute = PlayerPrefs.GetInt("audio_mute") == 1 ? true : false;
    }

    public void sesac()
    {
        audio.mute = false;
        PlayerPrefs.SetInt("audio_mute", 0);
    }
    public void seskapat()
    {
        audio.mute = true;
        PlayerPrefs.SetInt("audio_mute", 1);
    }
}
