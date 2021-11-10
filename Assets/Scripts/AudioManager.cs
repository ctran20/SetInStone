using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip empty_ammo, blaster, zapper, explosion, win, lose, hurt, swipe, lazer;
    static AudioSource audioSrc;

    private void Start()
    {
        swipe = Resources.Load<AudioClip>("swipe");
        lazer = Resources.Load<AudioClip>("lazer");
        hurt = Resources.Load<AudioClip>("hurt");
        empty_ammo = Resources.Load<AudioClip>("empty_ammo");
        blaster = Resources.Load<AudioClip>("blaster");
        zapper = Resources.Load<AudioClip>("zapper");
        lose = Resources.Load<AudioClip>("lose");
        win = Resources.Load<AudioClip>("win");
        explosion = Resources.Load<AudioClip>("explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip, float vol, float pitch)
    {
        audioSrc.pitch = pitch;
        switch (clip)
        {
            case "swipe":
                audioSrc.PlayOneShot(swipe, vol);
                break;
            case "lazer":
                audioSrc.PlayOneShot(lazer, vol);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurt, vol);
                break;
            case "empty_ammo":
                audioSrc.PlayOneShot(empty_ammo, vol);
                break;
            case "blaster":
                audioSrc.PlayOneShot(blaster, vol);
                break;
            case "lose":
                audioSrc.PlayOneShot(lose, vol);
                break;
            case "win":
                audioSrc.PlayOneShot(win, vol);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosion, vol);
                break;
        }
    }
}
