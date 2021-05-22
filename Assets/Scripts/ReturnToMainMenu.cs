using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public GameObject escapeText;

    private bool escapePrompt;

    private double timeWhenPrompted;

    private AudioManager am;

    double startTime;

    void Start()
    {
        startTime = Time.time;

        if (am == null)
        {
            am = AudioManager.instance;
        }
        am.Stop("Music");
        am.Play("Credits");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime + 2 && escapePrompt == false && Input.anyKey)
        {
            escapeText.SetActive(true);
            escapePrompt = true;
            timeWhenPrompted = Time.time;
        }
        if (escapePrompt == true && Time.time >= (timeWhenPrompted + 1) && Input.GetKeyDown("escape"))
        {
            am.Stop("Credits");
            am.Play("Music");
            SceneManager.LoadScene(0);
        }
    }
}
