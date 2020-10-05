using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globals : MonoBehaviour
{

    public static Color[] robotSkins = { Color.red, Color.blue, Color.green, new Color(128, 0, 128) };
    public static int robotCount = 0;
    public static int currentLevel = 1;

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

    }

    void trackTeleporterUseTime()
    {

    }

    public static void reactivateObjects()
    {
        foreach (var item in objectsToActive)
        {
            item.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
