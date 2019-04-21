using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float difficultyCode;
    public float characterCode;

    public void Awake()
    {
        FindObjectOfType<AudioManager>().Play("MenuSound");
    }


    public void PlayGame()
    {
        PlayerPreferences.characterCode = this.characterCode;
        PlayerPreferences.difficultyCode = this.difficultyCode;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetDifficulty(float dif)
    {
        this.difficultyCode = dif;
    }

    public void SetPlayer(int characterCode)
    {
        this.characterCode = characterCode;
    }
}
