using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    Transform[] objectives;

    public bool done = false;

    Animator door;

    // Start is called before the first frame update
    void Start()
    {
        door = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        objectives = gameObject.GetComponentsInChildren<Transform>();

        if (objectives.Length - 1 <= 0)
        {
            done = true;
            door.SetTrigger("ObjectiveDone");
        }
    }
}
