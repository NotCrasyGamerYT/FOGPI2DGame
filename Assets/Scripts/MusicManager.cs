using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        musicSource.loop = true;
        musicSource.Play();
    }
}
