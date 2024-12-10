using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    //This script is attached to the "StatsMenu" game object and it is used to show stats data
    [SerializeField]
    private Text lastScore = null;
    [SerializeField]
    private Text bestScore = null;
    [SerializeField]
    private Text droppedBoxes = null;
    [SerializeField]
    private Text gamesPlayed = null;

    void OnEnable() {
        lastScore.text = "LAST SCORE: " + PlayerPrefs.GetFloat("LastScore").ToString("F1") + "m";
        bestScore.text = "BEST SCORE: " + PlayerPrefs.GetFloat("BestScore").ToString("F1") + "m";
        droppedBoxes.text = "DROPPED BOXES: " + PlayerPrefs.GetInt("DroppedBoxes");
        gamesPlayed.text = "GAMES PLAYED: " + PlayerPrefs.GetInt("GamesPlayed");
    }
    
}
