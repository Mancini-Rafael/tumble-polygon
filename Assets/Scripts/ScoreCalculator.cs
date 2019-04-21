using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Transform Player;
    public Text Score;
    public int numberOfHits = 0;
    public int numberOfPowerUps = 0;

    public void UpdateScore()
    {
        int ScoreValue = GetCurrentScore();
        Score.text = ScoreValue.ToString("0");
    }

    public int GetCurrentScore()
    {
        float ScoreValue = (Player.position.z - (numberOfHits * 5) + (numberOfPowerUps * 50));
        return (int)ScoreValue;
    }

}
