using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TriggerBox
{
    Front,
    Back,
    Left,
    Right
};

public class BossTriggerZone : MonoBehaviour
{
    [SerializeField] TriggerBox zone;
    [SerializeField] GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(zone == TriggerBox.Front)
            {
                boss.GetComponent<BossAttack>().inFront = true;
            }
            else if (zone == TriggerBox.Left)
            {
                boss.GetComponent<BossAttack>().inLeft = true;
            }
            else if (zone == TriggerBox.Right)
            {
                boss.GetComponent<BossAttack>().inRight = true;
            }
            else
            {
                boss.GetComponent<BossAttack>().inBack = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zone == TriggerBox.Front)
            {
                boss.GetComponent<BossAttack>().inFront = false;
            }
            else if (zone == TriggerBox.Left)
            {
                boss.GetComponent<BossAttack>().inLeft = false;
            }
            else if (zone == TriggerBox.Right)
            {
                boss.GetComponent<BossAttack>().inRight = false;
            }
            else
            {
                boss.GetComponent<BossAttack>().inBack = false;
            }
        }
    }


}
