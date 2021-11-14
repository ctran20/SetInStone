using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    GameObject player;
    bool coolDown = false;
    bool entered = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            entered = false;
        }
    }

    private void Update()
    {
        if (!coolDown && entered)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(5f);
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage(){
        coolDown = true;
        yield return new WaitForSeconds(0.5f);
        coolDown = false;
    }
}
