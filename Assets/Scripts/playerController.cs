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
    int currentFrame = 0;
    float lastFrameTime = 0;
    void Start()
    {
        body = transform.GetComponent<Rigidbody>();
        InvokeRepeating("trackPos", 0, posRecordFrequency);
    }

    void movement()
    {
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
        positionRecordings.Add(body.position);

    }
    void makeClone()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            var newCopy = Instantiate(robotPrefab);
            var script = newCopy.GetComponent<playerController>();
            script.isMaster = true;
            this.isMaster = false;
            transform.position = positionRecordings[0];
        }
    }

    void replayMovements()
    {
        if (Time.time - lastFrameTime >= posRecordFrequency)
        {
            lastFrameTime = Time.time;
            body.position = positionRecordings[currentFrame];
            currentFrame++;
            Debug.Log("Frame num: " + currentFrame);
            Debug.Log("Frame length: " + positionRecordings.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
