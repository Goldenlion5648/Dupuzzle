using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioOnDelay : MonoBehaviour
{

    AudioSource soundToDelay;
    public int secondsToDelayBy = 2;
    // Start is called before the first frame update
    void Start()
    {
        soundToDelay = GetComponent<AudioSource>();
        soundToDelay.PlayDelayed(secondsToDelayBy);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
