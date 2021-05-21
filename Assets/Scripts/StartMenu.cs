using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public AudioMixer audioMixer;

    private bool optionsMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            goToMainMenu();
        }
    }

    public void goToOptions()
    {
        optionsMenuOpen = true;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void goToMainMenu()
    {
        optionsMenuOpen = false;
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void setVolume(float scale)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(scale) * 20);
    }
}
