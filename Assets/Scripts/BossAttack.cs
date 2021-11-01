using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] GameObject fireball;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject leftLava;
    [SerializeField] GameObject rightLava;

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
        int attack = Random.Range(1, 7);

        if (attack >= 5)
        {
            if (inLeft)
            {
                LaunchLava(true);
                GetComponent<Animator>().SetTrigger("swipeleft");
            }

            if (inRight)
            {
                LaunchLava(false);
                GetComponent<Animator>().SetTrigger("swiperight");
            }
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

    public void IdleReset(){
        laser.SetActive(false);
    }

    public void LaunchLava(bool left){
        if(left){
            leftLava.GetComponent<Animator>().SetTrigger("play");
        }
        else{
            rightLava.GetComponent<Animator>().SetTrigger("play");
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
