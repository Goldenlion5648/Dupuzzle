using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    List<(Vector3, Quaternion)> positionRecordings = new List<(Vector3, Quaternion)>();
    // Start is called before the first frame update
    Rigidbody body;
    public GameObject robotPrefab;
    public bool isMaster = true;
    float posRecordFrequency = .1f;
    public int currentFrame = 0;
    float lastFrameTime = 0;

    bool finishedReplaying = false;

    private Animator robotAnimator;
    private Transform robotTransform;
    private Vector3 lastPos;

    private float restartTime = 0;

    private bool hasChangedToTransparent = false;

    void Start()
    {
        body = transform.GetComponent<Rigidbody>();
        InvokeRepeating("trackPos", 0, posRecordFrequency);
        if (isMaster == false)
        {
            transform.position = positionRecordings[0].Item1;
            //changeToTransparent();
            Debug.Log("Some how ran start when not master");

        }


        //Debug.Log("Color: " + this.transform.Find("ToonBot(Free)/robotMesh").GetComponent<Renderer>().material.color);

        //this.get<Renderer>().material.color = skins[globals.robotCount % skins.Length];
        //changeToTransparent();
        //var skins = globals.robotSkins;

        //var render = this.transform.Find("ToonBot(Free)/robotMesh").GetComponent<Renderer>();
        //render.material.color = skins[globals.robotCount % skins.Length];
        //globals.robotCount++;
        //Debug.Log("length of recording: " + positionRecordings.Count);

        robotAnimator = this.gameObject.GetComponentInChildren<Animator>();
        robotTransform = GetComponentInChildren<Transform>();

        lastPos = transform.position;

        globals.curPlayerTransform = transform;

    }

    void changeToTransparent()
    {
        //Debug.Log("changed to transparent");

        var render = this.transform.Find("ToonBot(Free)/robotMesh").GetComponent<Renderer>();
        render.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        render.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        render.material.SetInt("_ZWrite", 0);
        render.material.DisableKeyword("_ALPHATEST_ON");
        render.material.DisableKeyword("_ALPHABLEND_ON");
        render.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        render.material.renderQueue = 3000;
    }

    void movement()
    {
        if (Time.time < .5)
            return;
        //controls for the robot the player is currently controlling
        //var speed = 700.0f * Time.deltaTime;
        var speed = 7.0f;
        body.velocity = new Vector3(0, body.velocity.y, 0);
        //body.velocity = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            body.velocity += new Vector3(0, 0, speed);
            //robotAnimator.SetInteger("Speed", 1);
            robotTransform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            body.velocity += new Vector3(0, 0, -speed);
            //robotAnimator.SetInteger("Speed", 1);
            robotTransform.rotation = Quaternion.Euler(0, 180, 0);
            //Debug.Log(Time.time);

        }
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity += new Vector3(-speed, 0, 0);
            //robotAnimator.SetInteger("Speed", 1);
            robotTransform.rotation = Quaternion.Euler(0, -90, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity += new Vector3(speed, 0, 0);
            //robotAnimator.SetInteger("Speed", 1);
            robotTransform.rotation = Quaternion.Euler(0, 90, 0);

        }

        //extra gravity 
        //body.velocity += new Vector3(0, -1000, 0);
        //Debug.Log("velocity: " + body.velocity);

        //body.velocity = new Vector3(Mathf.Min(body.velocity.x, speed), 0, Mathf.Min(body.velocity.z, speed * 2));

        if (Input.GetKey(KeyCode.R))
        {
            restartTime += Time.deltaTime;
            if (restartTime >= 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                restartTime = 0;
            }

        }
        else
        {
            restartTime = 0;
        }

        //Debug.Log(robotTransform.rotation);

    }

    void trackPos()
    {
        //track the position of the player in case a robot has to copy it
        if (Time.time - lastFrameTime >= posRecordFrequency)
        {
            positionRecordings.Add((body.position, transform.rotation));
            //lastFrameTime = Time.tm
        }

    }

    void makeClone()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            var globalFloor = GameObject.Find("LevelLayout").GetComponentInChildren<globals>();
            if (globalFloor.robotCount + 1 <= globals.robotsPerLevel[globals.currentLevel] &&
                Time.time - globals.lastCloneTime > 1)
            {

                //make a clone of the  player that will replay the movements that were just done
                var newCopy = Instantiate(robotPrefab, positionRecordings[0].Item1, Quaternion.identity);
                this.isMaster = false;
                body.useGravity = false;
                //changeToTransparent();
                body.velocity = Vector3.zero;
                CancelInvoke("trackPos");

                var skins = globals.robotSkins;

                var render = this.transform.Find("ToonBot(Free)/robotMesh").GetComponent<Renderer>();
                render.material.color = skins[globalFloor.robotCount % skins.Length];
                globalFloor.robotCount++;


                //using a for loop because I have been burned in the past from untiy not allowing me to stop a while loop
                //during run time and crashing the program
                for (int i = 0; i < 10; i++)
                {
                    positionRecordings.RemoveAt(positionRecordings.Count - 1);
                    if (positionRecordings[positionRecordings.Count - 1] != positionRecordings[0])
                        break;

                }
                //Debug.Log("length of recording after: " + positionRecordings.Count);

                //reset all of the clones to their starting positions
                var robots = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject r in robots)
                {
                    r.GetComponent<playerController>().currentFrame = 0;
                }

                globals.reactivateObjects();
                globals.lastCloneTime = Time.time;


            }
            else
            {
                //TODO: add way of telling player they can not use any more clones
            }

        }
    }

    void replayMovements()
    {
        //playback movements 
        body.position = this.positionRecordings[currentFrame].Item1;
        body.rotation = this.positionRecordings[currentFrame].Item2;
        if (currentFrame < positionRecordings.Count - 1)
        {
            //Debug.Log("current frame: " + currentFrame + " " + positionRecordings[currentFrame]);
            currentFrame++;

        }
        else
        {
            //debug code
            if (finishedReplaying == false)
            {
                finishedReplaying = true;
                //Debug.Log("printing " + positionRecordings.Count + " things");

                foreach (var item in positionRecordings)
                {
                    //Debug.Log(item);
                }
            }
        }
        //Debug.Log("Frame num: " + currentFrame);
        //Debug.Log("Frame length: " + positionRecordings.Count);
    }

    void playAnimation()
    {
        if (lastPos != transform.position)
        {
            robotAnimator.SetInteger("Speed", 1);

            lastPos = transform.position;
        }
        else
        {
            robotAnimator.SetInteger("Speed", 0);
        }
    }

    void moveCamera()
    {
        Camera.main.transform.position = transform.position + globals.cameraOffset;

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
            moveCamera();
        }
        else
        {
            if (hasChangedToTransparent == false)
            {
                changeToTransparent();
                hasChangedToTransparent = true;
            }
            replayMovements();
        }
        //playAnimation();
        //Debug.Log(name + " is master? " + isMaster);

    }
}
