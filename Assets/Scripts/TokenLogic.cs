using UnityEngine;

public class TokenLogic : MonoBehaviour
{
    public static int tokenCount = 0;
    public AudioClip tokenClip;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tokenCount++;
            Debug.Log("Token count: " + tokenCount);

            if (tokenClip != null)
                AudioSource.PlayClipAtPoint(tokenClip, transform.position);
            Destroy(gameObject);
        }
    }
}