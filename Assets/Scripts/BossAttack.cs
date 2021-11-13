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
    [SerializeField] ParticleSystem portal;
    [SerializeField] GameObject bots;
    AudioSource audioSrc;

    public bool inLaser = false;
    public bool inFront = false;
    public bool inBack = false;
    public bool inLeft = false;
    public bool inRight = false;

    

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
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
        else if (attack > 2 && attack < 5 && inFront)
        {
            audioSrc.PlayOneShot(Resources.Load<AudioClip>("lazer"), 0.2f);
            GetComponent<Animator>().SetTrigger("laserattack");
            laser.SetActive(true);
        }
        else if (attack > 2 && attack < 5 && inBack)
        {
            audioSrc.PlayOneShot(Resources.Load<AudioClip>("lazer"), 0.1f);
            GetComponent<Animator>().SetTrigger("spawn");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("powerattack");
        }

    }

    public void IdleReset(){
        laser.SetActive(false);
        audioSrc.Stop();
    }

    public void LaunchLava(bool left){
        audioSrc.PlayOneShot(Resources.Load<AudioClip>("swipe"), 0.4f);
        if (left){
            leftLava.GetComponent<Animator>().SetTrigger("play");
        }
        else{
            rightLava.GetComponent<Animator>().SetTrigger("play");
        }
    }
    public void BossFireEvent()
    {
        audioSrc.PlayOneShot(Resources.Load<AudioClip>("blaster"), 0.1f);
        Instantiate(fireball, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z + 2), new Quaternion(0, 0, 0, 0));
    }

    public void BossLaserHitEvent()
    {
        if (target == null || !inLaser) return;
        target.TakeDamage(5);
    }

    public void BossSpawningEvent()
    {
        portal.Play();
        Instantiate(bots, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z + 4), new Quaternion(0, 0, 0, 0));
        Instantiate(bots, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z + 4), new Quaternion(0, 0, 0, 0));
    }
}
