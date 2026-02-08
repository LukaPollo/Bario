using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] tracks;

    private bool stopAllMusic = false;
    private int currentTrackIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        if (tracks.Length == 0) return;
        {
            PlayTrack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopAllMusic) return;
        if (!audiosource.isPlaying && audiosource.time == 0f)
        {
            NextTrack();
        }
    }
    void PlayTrack()
    {
        currentTrackIndex = Random.Range(0, tracks.Length);
        stopAllMusic = false;
        audiosource.clip = tracks[currentTrackIndex];
        audiosource.Play();
    }
    void NextTrack()
    {
        currentTrackIndex = Random.Range(0, tracks.Length);
        PlayTrack();
    }
    public void StopMusic()
    {
        audiosource.Stop();
        stopAllMusic = true;
    }
}
