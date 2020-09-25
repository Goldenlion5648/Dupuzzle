using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{

    public Transform connectedTeleporter;
    public float cooldown = 0;
    const float defaultCooldownSeconds = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decCooldown", 0.1f, 1);

    }
    private void OnTriggerEnter(Collider other)
    {
        //if ()
        Debug.Log(other.gameObject.name);

        //robot layer
        if (other.gameObject.layer == 8 && cooldown == 0)
        {
            Debug.Log("Collided");
            if (other.gameObject.GetComponent<playerController>().isMaster)
            {
                other.gameObject.transform.position = connectedTeleporter.position +
                    new Vector3(0, other.gameObject.transform.localScale.y + .5f, 0);
                Debug.Log("Teleported");


                cooldown = defaultCooldownSeconds;
                connectedTeleporter.parent.GetChild(1).GetComponent<teleporter>().cooldown = cooldown;

            }
        }
    }

    void decCooldown()
    {
        cooldown = Mathf.Max(cooldown - 1, 0);
    }

    //private void OnTrigger(Collider other)
    //{

    //}

    // Update is called once per frame
    void Update()
    {

    }
}
