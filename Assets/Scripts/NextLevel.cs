using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NextLevel : MonoBehaviour
{
    public UnityEvent ProgressLevel;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.GetComponentInChildren<Objective>().done)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                Debug.Log("Hellooo?>");
                ProgressLevel.Invoke();
            }
        }
    }
}
