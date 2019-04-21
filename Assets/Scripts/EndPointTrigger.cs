using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointTrigger : MonoBehaviour
{
    public GameManager GameManager;
    private void OnTriggerEnter(Collider other)
    {
        int score = FindObjectOfType<ScoreCalculator>().GetCurrentScore();
        PlayerPreferences.finalScore = score;
        GameManager.LevelComplete();
    }
}
