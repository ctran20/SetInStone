using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            StartCoroutine(JumpOff());
        }
    }

    IEnumerator JumpOff()
    {
        yield return new WaitForSeconds(0.6f);
        Player.transform.parent = null;
    }
}
