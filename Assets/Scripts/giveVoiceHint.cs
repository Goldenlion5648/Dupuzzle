using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveVoiceHint : MonoBehaviour
{

    public AudioSource hint;
    // Start is called before the first frame update
    void Start()
    {
        hint.PlayDelayed(10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
