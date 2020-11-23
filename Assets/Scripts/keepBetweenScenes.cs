using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepBetweenScenes : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audio = GetComponent<AudioSource>();

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
