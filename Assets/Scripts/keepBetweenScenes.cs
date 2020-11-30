using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keepBetweenScenes : MonoBehaviour
{
    private AudioSource _audio;
    static bool isRunning = false;

    public bool playMusicFromScript;

    void Start()
    {
        //if (SceneManager.GetActiveScene().)
        if (isRunning == false)
        {

            DontDestroyOnLoad(transform.gameObject);
            _audio = GetComponent<AudioSource>();
            if (playMusicFromScript)
                playMusic();
            isRunning = true;
        }
    }

    public void playMusic()
    {
        if (_audio.isPlaying)
            return;
        _audio.Play();
    }

    public void pauseMusic()
    {
        if (_audio.isPlaying)
        {
            _audio.Pause();
        }
        else
        {
            _audio.UnPause();
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMusic();
        }

        //if (SceneManager.GetActiveScene().name == "EndScreen")
        //{
        //    Destroy(transform.gameObject);

        //}
    }
}
