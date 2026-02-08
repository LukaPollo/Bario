using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] tracks;

    private bool stopAllMusic = false;
    private int currentTrackIndex = -1;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        if (tracks == null || tracks.Length == 0)
        {
            Debug.LogWarning("AudioController: No tracks assigned!");
            return;
        }

        PlayTrack();
    }

    void Update()
    {
        if (stopAllMusic) return;
        if (tracks == null || tracks.Length == 0) return;

        if (!audiosource.isPlaying)
        {
            NextTrack();
        }
    }

    void PlayTrack()
    {
        if (tracks == null || tracks.Length == 0) return;

        currentTrackIndex = Random.Range(0, tracks.Length);
        audiosource.clip = tracks[currentTrackIndex];
        audiosource.Play();
    }

    void NextTrack()
    {
        if (tracks == null || tracks.Length == 0) return;

        PlayTrack();
    }

    public void StopMusic()
    {
        audiosource.Stop();
        stopAllMusic = true;
    }
}