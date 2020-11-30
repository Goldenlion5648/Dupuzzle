using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textHover : MonoBehaviour
{
    float upperBound;
    float lowerBound;
    public float moveAmount = 1;
    public float changeByAmount = .2f;
    public float zMoveAmount = 0;
    public float zMoveBound = 0;
    // Start is called before the first frame update
    void Start()
    {
        upperBound = GetComponent<RectTransform>().position.y + .5f;
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

        if (zMoveAmount != 0)
        {
            if (transform.position.z + zMoveAmount > zMoveBound)
            {

                GetComponent<RectTransform>().position += new Vector3(0, 0, zMoveAmount * Time.deltaTime);
            }
        }
        //else
        //Debug.Log("Move amount " + moveAmount);

        GetComponent<RectTransform>().position += new Vector3(0, moveAmount * Time.deltaTime, 0);
        //moveAmount += 3;

    }
}
