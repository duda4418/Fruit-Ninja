using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreenScript : MonoBehaviour
{
     public void switchScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
