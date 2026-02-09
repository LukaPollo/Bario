using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VictoryZone : MonoBehaviour
{
    public AudioController audioController;
    public AudioSource audioSource;
    public AudioClip victoryMusic;
    public PlayerController2D player;
    public Rigidbody2D rb;

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
            rb = other.GetComponent<Rigidbody2D>();
            player.canMove = false;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("Player touched Winning Pole!");

            audioController.StopMusic();
            audioSource.clip = victoryMusic;
            audioSource.Play();

            StartCoroutine(DelayBetweenScene());
        }
    }
    IEnumerator DelayBetweenScene()
    {
        yield return new WaitForSeconds(5f);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex < 5) 
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        if (currentIndex == 5)
        {
            SceneManager.LoadScene(6);
        }
    }
}