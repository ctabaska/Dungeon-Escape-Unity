using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public GameObject escapeText;

    private bool escapePrompt;

    private double timeWhenPrompted;

    // Update is called once per frame
    void Update()
    {
        if (escapePrompt == false && Input.anyKey)
        {
            escapeText.SetActive(true);
            escapePrompt = true;
            timeWhenPrompted = Time.time;
        }
        if (escapePrompt == true && Time.time >= (timeWhenPrompted + 2) && Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
