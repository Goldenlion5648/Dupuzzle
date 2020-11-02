﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    Transform visibleButton;
    bool isTriggered = false;

    float pressCooldown = 0;
    float changeAmount = .2f;

    // Start is called before the first frame update
    void Start()
    {
        visibleButton = gameObject.transform.parent.transform.Find("button");
        InvokeRepeating("cooldown", .1f, changeAmount);

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("triggered button");
        //isTriggered = false;

        if (other.gameObject.layer == 8)
        {
            //TODO: go to next level
            Debug.Log("triggered");
            other.gameObject.GetComponent<Rigidbody>().position += new Vector3(0, 50, 0);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.layer == 8)
        //{
        //    Debug.Log("left trigger");

        //    isTriggered = false;
        //    pressCooldown = 1;
        //    foreach (var item in linkedWalls)
        //    {

        //        item.SetActive(true);
        //    }
        //}

    }

    void cooldown()
    {
        pressCooldown = Mathf.Max(pressCooldown - changeAmount, 0);

    }

    void pressAndUnpress()
    {
        var current = visibleButton.localScale;
        if (isTriggered)
        {
            visibleButton.localScale = new Vector3(current.x, Mathf.Max(.01f, current.y - .8f * Time.deltaTime), current.z);
            //visibleButton.position -= new Vector3(0, 1, 0);
        }
        else
        {
            visibleButton.localScale = new Vector3(current.x, Mathf.Min(.5f, current.y + .2f * Time.deltaTime), current.z);

        }

    }


    // Update is called once per frame
    void Update()
    {
        pressAndUnpress();
    }
}
