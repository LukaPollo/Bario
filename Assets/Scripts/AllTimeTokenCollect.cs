using UnityEngine;
using TMPro;

public class AllTimeTokenCollect : MonoBehaviour
{
    public static int all_time_token_count = 0;
    public TMP_Text alltimetokentext;

    public void AllTokenCollected()
    {
        alltimetokentext.text = "All Time Token Count: " + all_time_token_count;
    }
    void Start()
    {
        AllTokenCollected();
    }
}
