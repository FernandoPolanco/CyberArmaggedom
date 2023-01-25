using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isPaused;

    //[SerializeField]private TextMeshProUGUI ammoText;
    [SerializeField]private TextMeshProUGUI healthText;
    [SerializeField]private TextMeshProUGUI WaveText;
    public static GameManager Instance { get; private set; }

    //public int gunAmmo = 10;
    public int health = 100;
    private int healthEnemy = 100;
    private int wave = 0;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateGameState();
            ShowPausePanel();
        }
        //ammoText.text=gunAmmo.ToString();
        healthText.text=health.ToString();
        WaveText.text=wave.ToString();
    }
    
    private void UpdateGameState()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1f;
        }
    }

    private void ShowPausePanel()
    {
        if (isPaused)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }


    public void LostHealt(int valueToLost)
    {
        health -= valueToLost;
        RestarLevel();

    }
    public void RestarLevel()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void nextWave(int _wave)
    {
        wave +=_wave;
       

    }

    public void LostHealtEnemy(int valueToLostEnemy)
    {
        healthEnemy -= valueToLostEnemy;

        if (healthEnemy<=0)
        {
            Destroy(FindObjectOfType<EnemyInterations>().transform.parent.gameObject);
        }

    }
}


