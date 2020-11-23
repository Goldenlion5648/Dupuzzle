using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globals : MonoBehaviour
{

    //***transparency is adjusted in function below****
    public static Color[] robotSkins = { Color.red, Color.blue, Color.green, new Color(.5f, 0, .5f) };

    public int robotCount = 1;
    public static int currentLevel = 1;
    public static Vector3 cameraOffset = new Vector3(0.8f, 7.2f, -10.6f);
    public static Transform curPlayerTransform;

    public static float lastCloneTime = -1;
    public static int timeOnLevel = 0;


    public static List<GameObject> objectsToActive = new List<GameObject>();

    public static List<(float, int)> teleporterUseTime = new List<(float, int)>();

    public static List<string> levelOrder = new List<string>();

    AudioSource shouldResetAudioSource;

    public static bool isPlayingResetAudio;

    //public static Dictionary<int, int> robotsPerLevel = new Dictionary<int, int>()
    //{
    //    { 1,4 },
    //    { 2,3 },
    //    { 3,4 },
    //};
    // Start is called before the first frame update
    void Start()
    {
        //this is the order that the levels will be played
        levelOrder.Add("ButtonTutorial");
        levelOrder.Add("TeleporterTutorial");
        levelOrder.Add("BridgeGaps");
        InvokeRepeating("addToTimeOnLevel", 1, 1);

        shouldResetAudioSource = GetComponent<AudioSource>();




        //robotSkins[1].a = 3;
        //Debug.Log("ran");
        for (int i = 0; i < robotSkins.Length; i++)
        {
            robotSkins[i].a = .4f;
        }

        var camPos = Camera.main.transform.position;
        curPlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        var curPlayerPos = curPlayerTransform.position;

        //tweak this if the camera angle wants to be adjusted from within the editor
        //cameraOffset = new Vector3(camPos.x - curPlayerPos.x, camPos.y - curPlayerPos.y, camPos.z - curPlayerPos.z);
        //cameraOffset 


        Debug.Log("cameraOffset " + cameraOffset);
        //Debug.Log("cameraRotation " + Camera.main.transform.rotation);
        //Camera.main.transform.LookAt(GameObject.Find("Robot").transform);
        Camera.main.transform.rotation = Quaternion.Euler(33, 0, 0);


        //Debug.Log(cameraOffset);
        //good offset is (0.9, 9.3, -11.3)

    }

    void addToTimeOnLevel()
    {
        timeOnLevel += 1;
        if (timeOnLevel % 5 == 0 && timeOnLevel != 0 && shouldResetAudioSource.isPlaying == false &&
            GetComponent<levelScript>().robotsSoFar == GetComponent<levelScript>().totalRobotsAllowed &&
            Time.time - lastCloneTime > 15)
        {
            shouldResetAudioSource.Play();

        }
        isPlayingResetAudio = shouldResetAudioSource.isPlaying;
    }

    void trackTeleporterUseTime()
    {

    }

    public static void reactivateObjects()
    {
        foreach (var item in objectsToActive)
        {
            if (item != null)
                item.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
