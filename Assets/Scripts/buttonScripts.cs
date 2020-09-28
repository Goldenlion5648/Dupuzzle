using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScripts : MonoBehaviour
{
    public GameObject linkedWall;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("triggered button");

        if (other.gameObject.layer == 8)
        {
            if (linkedWall != null)
                Destroy(linkedWall);
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
