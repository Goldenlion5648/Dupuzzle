using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class giveVoiceHint : MonoBehaviour
{

    AudioSource hint;
    float hintDelay = 1;
    float startTime;
    public static bool isPlayingHint;

    public bool checkCloneCount;
    bool hasPlayedHint = false;
    // Start is called before the first frame update
    void Start()
    {
        hint = GetComponent<AudioSource>();
        //hint.PlayDelayed(10);
        Debug.Log("hint length " + hint.clip.length);
        startTime = Time.time;
        Debug.Log("start Time " + startTime);

    }

    public void justPlayHint()
    {
        hasPlayedHint = false;
        if (hint.isPlaying == false)
        {
            hint.Play();
        }

        hasPlayedHint = true;
    }

    void hintCheck()
    {

        if (giveHintGlobal.giveHintsMenuChoice == true)
        {

            if (Time.time - startTime > hintDelay && hasPlayedHint == false && hint.isPlaying == false)
            {
                justPlayHint();
            }

        }
        else
        {
            hasPlayedHint = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hintCheck();

    }
}
