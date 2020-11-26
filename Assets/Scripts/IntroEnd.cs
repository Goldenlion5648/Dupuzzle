using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEnd : MonoBehaviour
{
    public GameObject[] walls;
    AudioSource intro;

    bool hasLetDownWalls = false;
    public GameObject light;

    private float startIntroTime;


    // Start is called before the first frame update
    void Start()
    {
        intro = GameObject.Find("IntroAudio").GetComponent<AudioSource>();
        var introLength = intro.clip.length;
        Debug.Log("intro length " + introLength);

        startIntroTime = Time.time;
        Debug.Log(startIntroTime);


        //Invoke("startLevel", introLength + 1.5f);

    }

    void startLevel()
    {
        GetComponent<AudioSource>().Play();

        foreach (var item in walls)
        {
            item.SetActive(false);

        }
        light.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("time in audio " + intro.time);
        if (hasLetDownWalls == false && intro.isPlaying == false && Time.time - startIntroTime > 5)
        {
            startLevel();
            hasLetDownWalls = true;
        }
    }
}
