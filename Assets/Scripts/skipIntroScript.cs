using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipIntroScript : MonoBehaviour
{
    public GameObject introText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && SceneManager.GetActiveScene().name == "Intro")
        {
            var introObject = GameObject.Find("IntroAudio");
            if (introObject.GetComponent<AudioSource>().isPlaying)
            {

                introObject.GetComponent<AudioSource>().Stop();
                introText.SetActive(false);

            }
        }
    }
}
