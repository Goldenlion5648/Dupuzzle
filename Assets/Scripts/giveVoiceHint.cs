using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveVoiceHint : MonoBehaviour
{

    AudioSource hint;
    int hintDelay = 5;
    float startTime;
    public static bool isPlayingHint;
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

        if (Time.time - startTime > hintDelay && hint.isPlaying == false &&
            globals.isPlayingResetAudio == false && g.GetComponent<levelScript>().robotsSoFar == 1)
        {
            hint.Play();
            if (hint.clip.length - hint.time < 1)
            {
                startTime = Time.time;
                hintDelay += 5;
            }
        }
        isPlayingHint = hint.isPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        giveHint();

    }
}
