using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(0);
        TokenLogic.tokenCount = 0;
        AllTimeTokenCollect.all_time_token_count = 0;
    }
}
