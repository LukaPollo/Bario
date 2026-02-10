using UnityEngine;
using TMPro;

public class TokenLogic : MonoBehaviour
{
    public static int tokenCount = 0;
    public AudioClip tokenClip;
    public TMP_Text tokenText;

    void Start()
    {
        UpdateUI(); // line 12
    }

    void UpdateUI()
    {
        tokenText.text = "Tokens: " + tokenCount; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tokenCount++;
            AllTimeTokenCollect.all_time_token_count++;
            UpdateUI();
            //Debug.Log("Token count: " + tokenCount);

            if (tokenClip != null)
                AudioSource.PlayClipAtPoint(tokenClip, transform.position);
            Destroy(gameObject);
        }
    }
}