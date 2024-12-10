using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuUI = null;
    [SerializeField]
    private Image soundButtonImage = null;
    [SerializeField]
    private Sprite soundOnSprite = null;
    [SerializeField]
    private Sprite soundOffSprite = null;
    [SerializeField]
    private GameObject statsMenu = null;
    [SerializeField]
    private GameObject gameplayUI = null;
    [SerializeField]
    private GameObject gameUI = null;
    [SerializeField]
    private GameObject pauseButton = null;
    [SerializeField]
    private GameObject pauseMenuUI = null;
    [SerializeField]
    
    public GameObject gameOverUI = null;
    [SerializeField]
    private Text score = null;
    [SerializeField]
    private Text bestScore = null;
    [SerializeField]
    private GameObject bottomPlatform = null;
    [SerializeField]
    private Text stackMeasurement = null;
    private AudioSource buttonSound;
    private bool isGameOver = false;

    void Start() {
        buttonSound = GameObject.Find("ButtonSound").GetComponent<AudioSource> ();
    }

    public void Play() //This method is called when player clicks on the play button
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        bottomPlatform.SetActive(true);
        GetComponent<CreateNewSquare> ().enabled = true;
        isGameOver = false;
        buttonSound.Play();
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
    }

    public void ShowStatsMenu() {
        statsMenu.SetActive(true);
        buttonSound.Play();
    }

    public void HideStatsMenu() {
        statsMenu.SetActive(false);
        buttonSound.Play();
    }

    public void SoundOnOff() //Used to turn the sound on and off when user presses the sound button in the main menu
    {
        if(AudioListener.volume == 1) 
        {
            AudioListener.volume = 0f;
            soundButtonImage.sprite = soundOffSprite;
        }else 
        {
            AudioListener.volume = 1f;
            soundButtonImage.sprite = soundOnSprite;
        }
        buttonSound.Play();
    }
    public void StackMeasurement() //It will show the ruller and the height of the stack on UI
    {    
        stackMeasurement.text = "HEIGHT: " + Vars.stackHeight.ToString("F1") + "m";
    }

    public void ShowPauseMenu() 
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
        buttonSound.Play();
    }

    public void HidePauseMenu() 
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
        buttonSound.Play();
    }

    public void Replay() //This method is called when player clicks on the replay button
    {
        gameOverUI.SetActive(false);
        gameUI.SetActive(true);
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Square");
        foreach (GameObject square in squares)
        {
            Destroy(square);
        }
        Vars.stackHeight = 0;
        GetComponent<CreateNewSquare> ().numberOfSquares = 0;
        GetComponent<CreateNewSquare> ().NewSquare();
        stackMeasurement.text = "HEIGHT: 0m";
        isGameOver = false;
        HidePauseMenu();
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
    }

    public void ExitToMainMenu() //This method is called when player clicks on the exit button
    {
        mainMenuUI.SetActive(true);
        gameplayUI.SetActive(false);
        bottomPlatform.SetActive(false);
        Vars.stackHeight = 0;
        GetComponent<CreateNewSquare> ().enabled = false;
        gameOverUI.SetActive(false);
        gameUI.SetActive(true);
        stackMeasurement.text = "HEIGHT: 0m";
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Square");
        foreach (GameObject square in squares)
        {
            Destroy(square);
        }
        HidePauseMenu();
    }
    public void GameOver()//This method is called when square falls of the stack
    {
        if(isGameOver) return;
        isGameOver = true;
        Invoke("ShowGameOverMenu", 0.5f);
        GameObject.Find("GameOverSound").GetComponent<AudioSource> ().Play();
    }

    public void ShowGameOverMenu() 
    {
        gameOverUI.SetActive(true);
        gameUI.SetActive(false);
        score.text = "SCORE: " + Vars.stackHeight.ToString("F1") + "m";
        PlayerPrefs.SetFloat("LastScore", Vars.stackHeight);
        if(PlayerPrefs.GetFloat("BestScore") < Vars.stackHeight)
        {
            PlayerPrefs.SetFloat("BestScore", Vars.stackHeight);
        }
        bestScore.text = "BEST: " + PlayerPrefs.GetFloat("BestScore").ToString("F1") + "m";
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Square");
        foreach (GameObject square in squares)
        {
            Destroy(square.GetComponent<SquarePositioned> ());
        }
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
