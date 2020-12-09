using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class giveHintGlobal : MonoBehaviour
{

    public static bool giveHintsMenuChoice = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HintToggle").GetComponent<Toggle>().isOn = giveHintsMenuChoice;
    }

    public void flipChoice()
    {
        giveHintsMenuChoice = !giveHintsMenuChoice;
        Debug.Log("new value of give hints " + giveHintsMenuChoice);
        GameObject.Find("HintToggle").GetComponent<Toggle>().isOn = giveHintsMenuChoice;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
