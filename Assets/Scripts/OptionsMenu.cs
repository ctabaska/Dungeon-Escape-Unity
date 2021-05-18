using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject backMenu;

    public void setVolume(float scale)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(scale) * 20);
    }

    public void optionsBack()
    {
        backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
