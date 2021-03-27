using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public Text gameOverScoreText;
    public Text gameOverHighscoreText;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    public AudioClip explosionSound;
    private AudioSource audioSource;

    private void Awake()
    {
        Advertisement.Initialize("3953271");
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        GetHighscore();
    }

    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Рекорд: " + highscore.ToString();
    }

    public void IncreaseScoreText(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Рекорд: " + score.ToString();
            highscore = score;
        }
    }

    public void BombHit()
    {
        //Advertisement.Show(); // Показ рекламного окна
        Time.timeScale = 0;
        Debug.Log("Bomb hit!!!");

        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Ваш счет: " + score.ToString();

        if(score == highscore)
            gameOverHighscoreText.text = "И это новый рекорд!";
        else
            gameOverHighscoreText.text = "Рекорд: " + highscore.ToString();
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }

    public void PlaySlashSound()
    {
        AudioClip sliceSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(sliceSound);
    }

    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosionSound);
    }
}
