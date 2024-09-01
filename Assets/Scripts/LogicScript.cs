using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public Image fadeImage;
    public Text scoreText;
    private BladeScript blade;
    private SpawnerScript spawner;
    private int score;

    private void Awake()
    {
        blade = FindObjectOfType<BladeScript>();
        spawner = FindObjectOfType<SpawnerScript>();
    }
    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();

        ClearScene();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void ClearScene()
    {
        FruitScript[] fruits = FindObjectsOfType<FruitScript>();

        foreach (FruitScript fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        BombScript[] bombs = FindObjectsOfType<BombScript>();

        foreach (BombScript bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 2f;

        while(elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            // Time.timeScale = 1f - t;    
            elapsed += Time.deltaTime;

            yield return null;
        }

        SceneManager.LoadScene("GameOverScene");

        // NewGame();

        // elapsed = 0f;

        //  while(elapsed < duration)
        // {
        //     float t = Mathf.Clamp01(elapsed / duration);
        //     fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

        //     Time.timeScale = 1f - t;    
        //     elapsed += Time.deltaTime;

        //     yield return null;
        // }
    }   
}
