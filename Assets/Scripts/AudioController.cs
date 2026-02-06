using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] tracks;

    private int currentTrackIndex = 0; 

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        if (tracks.Length == 0) return;
        {
            PlayTrack();
        }
    }
    void Update()
    {
        if (!audiosource.isPlaying && audiosource.time == 0f)
        {
            NextTrack();
        }
    }
    void PlayTrack()
    {
        audiosource.clip = tracks[currentTrackIndex];
        audiosource.Play();
    }
    void NextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % tracks.Length;
        PlayTrack();
    }
}
