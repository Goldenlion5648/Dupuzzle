using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    List<Vector3> positionRecordings = new List<Vector3>();
    // Start is called before the first frame update
    Rigidbody body;
    public GameObject robotPrefab;
    public bool isMaster = true;
    float posRecordFrequency = .2f;
    public int currentFrame = 0;
    float lastFrameTime = 0;

    bool finishedReplaying = false;

    void Start()
    {
        body = transform.GetComponent<Rigidbody>();
        InvokeRepeating("trackPos", 0, posRecordFrequency);
        if (isMaster == false)
            transform.position = positionRecordings[0];

        //Debug.Log("length of recording: " + positionRecordings.Count);

    }

    void movement()
    {
        //controls for the robot the player is currently controlling
        var speed = 3.0f;
        body.velocity = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            body.velocity += new Vector3(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.velocity += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity += new Vector3(speed, 0, 0);
        }
    }

    void trackPos()
    {
        //track the position of the player in case a robot has to copy it
        positionRecordings.Add(body.position);

    }
    void makeClone()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //make a clone of the  player that will replay the movements that were just done
            var newCopy = Instantiate(robotPrefab, positionRecordings[0], Quaternion.identity);
            //newCopy.GetComponent<playerController>().isMaster = true;
            this.isMaster = false;
            body.velocity = Vector3.zero;

            //using a for loop because I have been burned in the past from untiy not allowing me to stop a while loop
            //during run time and crashing the program
            for (int i = 0; i < 10; i++)
            {
                positionRecordings.RemoveAt(positionRecordings.Count - 1);
                if (positionRecordings[positionRecordings.Count - 1] != positionRecordings[0])
                    break;

            }
            Debug.Log("length of recording after: " + positionRecordings.Count);

            //reset all of the clones to their starting positions
            var robots = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject r in robots)
            {
                r.GetComponent<playerController>().currentFrame = 0;
            }


        }
    }

    void replayMovements()
    {
        //playback movements 
        if (currentFrame < positionRecordings.Count)
        {
            body.position = this.positionRecordings[currentFrame];
            Debug.Log("current frame: " + currentFrame + " " + positionRecordings[currentFrame]);
            currentFrame++;



        }
        else
        {
            //debug code
            if (finishedReplaying == false)
            {
                finishedReplaying = true;
                Debug.Log("printing " + positionRecordings.Count + " things");

                foreach (var item in positionRecordings)
                {
                    Debug.Log(item);
                }
            }
        }
        //Debug.Log("Frame num: " + currentFrame);
        //Debug.Log("Frame length: " + positionRecordings.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.name + " is master? " + isMaster);
        if (isMaster)
        {
            movement();
            trackPos();
            makeClone();
        }
        else
        {
            replayMovements();
        }
        //Debug.Log(name + " is master? " + isMaster);

    }
}
