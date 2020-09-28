using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textHover : MonoBehaviour
{
    float upperBound;
    float lowerBound;
    float moveAmount = 1;
    float changeByAmount = .3f;
    // Start is called before the first frame update
    void Start()
    {
        upperBound = GetComponent<RectTransform>().position.y + 1;
        lowerBound = GetComponent<RectTransform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<RectTransform>().position.y);
        //Debug.Log("move amount " + moveAmount);

        if (transform.position.y > upperBound)
        {
            //GetComponent<RectTransform>().position += new Vector3(0, moveAmoucnt * Time.deltaTime, 0);
            moveAmount -= changeByAmount;
        }
        else if (transform.position.y < lowerBound)
        {
            //GetComponent<RectTransform>().position += new Vector3(0, moveAmount * Time.deltaTime, 0);
            moveAmount += changeByAmount;
        }
        //else
        {
            GetComponent<RectTransform>().position += new Vector3(0, moveAmount * Time.deltaTime, 0);
            //moveAmount += 3;
        }

    }
}
