using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globals : MonoBehaviour
{

    //***transparency is adjusted in function below****
    public static Color[] robotSkins = { Color.red, Color.blue, Color.green, new Color(.5f, 0, .5f) };

    public int robotCount = 1;
    public static int currentLevel = 1;
    public static Vector3 cameraOffset;
    public static Transform curPlayerTransform;

    public static float lastCloneTime = -1;

    public static List<GameObject> objectsToActive = new List<GameObject>();

    public static List<(float, int)> teleporterUseTime = new List<(float, int)>();

    public static Dictionary<int, int> robotsPerLevel = new Dictionary<int, int>()
    {
        { 1,4 },
        { 2,3 },
        { 3,4 },
    };
    // Start is called before the first frame update
    void Start()
    {
        //robotSkins[1].a = 3;
        //Debug.Log("ran");
        for (int i = 0; i < robotSkins.Length; i++)
        {
            robotSkins[i].a = .4f;
        }

        var camPos = Camera.main.transform.position;
        curPlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        var curPlayerPos = curPlayerTransform.position;
        cameraOffset = new Vector3(camPos.x - curPlayerPos.x, camPos.y - curPlayerPos.y, camPos.z - curPlayerPos.z);

        //Debug.Log(cameraOffset);
        //good offset is (0.9, 9.3, -11.3)

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
