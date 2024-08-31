using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
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
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;
    }
}
