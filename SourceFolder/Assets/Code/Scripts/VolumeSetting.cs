using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeSetting : MonoBehaviour
{    
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SxSlider;
    void Start()
    {
        float startVolume = 0.5f;
        musicSlider.value = Mathf.Pow(10, startVolume / 20);
        myMixer.SetFloat("Music", Mathf.Log10(startVolume) * 20);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }

    
}
