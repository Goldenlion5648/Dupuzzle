using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keepBetweenScenes : MonoBehaviour
{
    private AudioSource _audio;
    static bool isRunning = false;

    public bool playMusicFromScript;

    private void Awake()
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
