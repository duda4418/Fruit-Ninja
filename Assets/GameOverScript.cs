using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
