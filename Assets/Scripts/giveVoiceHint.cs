using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveVoiceHint : MonoBehaviour
{

    AudioSource hint;
    // Start is called before the first frame update
    void Start()
    {
        hint = GetComponent<AudioSource>();
        hint.PlayDelayed(10);
        Debug.Log("hint length " + hint.clip.length);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
