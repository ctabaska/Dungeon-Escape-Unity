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
                GoThroughDoor();

            }
        }
    }

    void GoThroughDoor()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject door = GameObject.Find("Door");

        // move player to position of door
        player.GetComponent<Transform>().position = door.GetComponent<Transform>().position;

        // play animation state of door
        player.GetComponent<Animator>().SetTrigger("doorway");

        // set player velocity to 0
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);

    }
}
