using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] GameObject fireball;
    [SerializeField] GameObject laser;
    public bool inLaser = false;
    public bool inFront = false;
    public bool inBack = false;
    public bool inLeft = false;
    public bool inRight = false;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    void Attack(){
        int attack = Random.Range(1, 6);

        if (attack == 5)
        {
            if (inLeft) GetComponent<Animator>().SetTrigger("swipeleft");
            if (inRight) GetComponent<Animator>().SetTrigger("swiperight");
        }
        else if (attack > 2 && attack < 5)
        {
            if (inFront) GetComponent<Animator>().SetTrigger("laserattack");
            laser.SetActive(true);
        }
        else
        {
            GetComponent<Animator>().SetTrigger("powerattack");
        }

    }

    public void BossFireEvent()
    {
        Instantiate(fireball, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z + 2), new Quaternion(0, 0, 0, 0));
    }

    public void BossLaserHitEvent()
    {
        if (target == null || !inLaser) return;
        target.TakeDamage(5);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
