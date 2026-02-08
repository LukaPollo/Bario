using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    public AudioController audioController;
    public AudioSource audioSource;
    public AudioClip victoryMusic;
    public PlayerController2D player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.canMove = false;
            Debug.Log("Player touched Winning Pole!");

            audioController.StopMusic();
            audioSource.clip = victoryMusic;
            audioSource.Play();
        }
    }
}