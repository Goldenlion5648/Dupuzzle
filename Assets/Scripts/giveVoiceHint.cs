using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveVoiceHint : MonoBehaviour
{

    AudioSource hint;
    public float hintDelay = 10;
    float startTime;
    public static bool isPlayingHint;

    public bool checkCloneCount;
    // Start is called before the first frame update
    void Start()
    {
        hint = GetComponent<AudioSource>();
        //hint.PlayDelayed(10);
        Debug.Log("hint length " + hint.clip.length);
        startTime = Time.time;
        Debug.Log("start Time " + startTime);

    }

    void giveHint()
    {
        //Debug.Log("hintDelay " + hintDelay);
        var g = GameObject.Find("ExitDoor");

        //Debug.Log("start " + startTime);
        //Debug.Log("Time: " + Time.time);
        //Debug.Log("HintDelay: " + hintDelay);


        //Debug.Log("Check clone count" + checkCloneCount);

        if (Mathf.Abs(Time.time - startTime) > hintDelay && hint.isPlaying == false &&
            globals.isPlayingResetAudio == false)
        {
            if (checkCloneCount && g.GetComponent<levelScript>().robotsSoFar != 1)
            {
                return;
            }
            hint.Play();
            if (hint.clip.length - hint.time < 1)
            {
                startTime = Time.time;
                hintDelay += 5;
            }
        }
        isPlayingHint = hint.isPlaying;
        if (isPlayingHint)
            startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        giveHint();

    }
}
