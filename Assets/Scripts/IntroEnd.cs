using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEnd : MonoBehaviour
{
    public GameObject[] walls;
    AudioSource intro;

    bool hasLetDownWalls = false;


    // Start is called before the first frame update
    void Start()
    {
        intro = GameObject.Find("IntroAudio").GetComponent<AudioSource>();
        var introLength = intro.clip.length;
        Debug.Log("intro length " + introLength);


        //Invoke("startLevel", introLength + 1.5f);

    }

    void startLevel()
    {
        GetComponent<AudioSource>().Play();

        foreach (var item in walls)
        {
            item.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("time in audio " + intro.time);
        if (hasLetDownWalls == false && intro.isPlaying == false)
        {
            startLevel();
            hasLetDownWalls = true;
        }
    }
}
