using UnityEngine;

public class Music : MonoBehaviour
{
    private static GameObject instance;

    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
            _audioSource = GetComponent<AudioSource>();
        }else{
            Destroy(gameObject);
        }
        
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        Destroy(gameObject);
    }
}
