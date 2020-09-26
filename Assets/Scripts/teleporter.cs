using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class teleporter : MonoBehaviour
{

    public Transform connectedTeleporter;
    public float cooldown = 0;
    public int maxUses = 4;
    const float defaultCooldownSeconds = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decCooldown", 0.1f, 1);

    }
    private void OnTriggerStay(Collider other)
    {
        //if ()
        //Debug.Log(other.gameObject.name);

        //robot layer
        if (other.gameObject.layer == 8 && cooldown == 0 &&
            GetComponent<BoxCollider>().bounds.Contains(other.gameObject.transform.position))
        {
            Debug.Log("Collided");
            if (other.gameObject.GetComponent<playerController>().isMaster)
            {
                other.gameObject.transform.position = connectedTeleporter.position +
                    new Vector3(0, other.gameObject.transform.localScale.y + .5f, 0);
                Debug.Log("Teleported");


                cooldown = defaultCooldownSeconds;
                maxUses -= 1;
                var porters = connectedTeleporter.parent.GetComponentsInChildren<teleporter>();
                foreach (var item in porters)
                {
                    item.cooldown = cooldown;
                    item.maxUses = maxUses;
                }
                var textObjects = transform.parent.GetComponentsInChildren<TextMeshPro>();
                foreach (var item in textObjects)
                {
                    item.text = maxUses.ToString();
                }
                var textScripts = connectedTeleporter.parent.GetComponentsInChildren<TextMeshPro>();
                foreach (var item in textScripts)
                {
                    item.text = maxUses.ToString();
                }
            }
        }
    }

    void decCooldown()
    {
        cooldown = Mathf.Max(cooldown - 1, 0);
        //Debug.Log("cooldown " + cooldown);

    }

    //private void OnTrigger(Collider other)
    //{

    //}

    // Update is called once per frame
    void Update()
    {

    }
}
