using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume")) //taking the variable value
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            Load();
        }
        else
            Save();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void ChangeVolume() //change the volume value
    {
        AudioListener.volume = volumeSlider.value;

        Save();
    }
    public void Load() //load the volume based on music volume
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
