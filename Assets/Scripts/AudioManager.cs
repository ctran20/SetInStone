using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip pistol, blaster, zapper, explosion, win, lose;
    static AudioSource audioSrc;

    private void Start()
    {
        pistol = Resources.Load<AudioClip>("pistol");
        blaster = Resources.Load<AudioClip>("blaster");
        zapper = Resources.Load<AudioClip>("zapper");
        lose = Resources.Load<AudioClip>("lose");
        win = Resources.Load<AudioClip>("win");
        explosion = Resources.Load<AudioClip>("explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip, float vol)
    {
        switch (clip)
        {
            case "pistol":
                audioSrc.PlayOneShot(pistol, vol);
                break;
            case "blaster":
                audioSrc.PlayOneShot(blaster, vol);
                break;
            case "zapper":
                audioSrc.PlayOneShot(zapper, vol);
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
