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
                ProgressLevel.Invoke();
                GoThroughDoor();

            }
        }
    }

    void GoThroughDoor()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject door = GameObject.Find("Door");

        // set player rigidbody type to static
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        // move player to position of door
        player.GetComponent<Transform>().position = door.GetComponent<Transform>().position + new Vector3(0.0f, 0.5f, 0);

        // play animation state of door
        player.GetComponent<Animator>().SetBool("doorway", true);

        // don't allow player to move
        player.GetComponent<Movement>().allowMovement = false;
    }
}
