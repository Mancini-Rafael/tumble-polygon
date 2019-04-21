using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool GameOver = false;

    public GameObject LevelCompleteScreen;
    public GameObject GameOverScreen;
    public Transform LongBlock;
    public Transform SmallBlock;
    public Transform PowerUp;
    public Text FinalScore;
    public Text LevelScore;


    public void Start()
    {
        Debug.Log("Started game on Game Manager");
        CreateGamePrefsBasedOnChoiceList();
        Debug.Log("Created the Game Prefs");
        SpawnBasedOnDifficulty();
        Debug.Log("Spawned Objects");
        Debug.Log("Calling player movement");
        Debug.Log("Player Preferences:");
        Debug.Log(string.Format("difficultyCode {0}", PlayerPreferences.difficultyCode));
        Debug.Log(string.Format("characterCode {0}", PlayerPreferences.characterCode));
        Debug.Log(string.Format("sizeOfLevel1 {0}", PlayerPreferences.sizeOfLevel1));
        Debug.Log(string.Format("distanceBetweenLongBlocks1 {0}", PlayerPreferences.distanceBetweenLongBlocks1));
        Debug.Log(string.Format("distanceBetweenSmallBlocks1 {0}", PlayerPreferences.distanceBetweenSmallBlocks1));
        Debug.Log(string.Format("levelDropThreshold1 {0}", PlayerPreferences.levelDropThreshold1));
        Debug.Log(string.Format("characterColor {0}", PlayerPreferences.characterColor));
        Debug.Log(string.Format("characterMass {0}", PlayerPreferences.characterMass));
        Debug.Log(string.Format("characterSpeedIncrement {0}", PlayerPreferences.characterSpeedIncrement));
        Debug.Log(string.Format("characterDropTime {0}", PlayerPreferences.characterDropTime));
        Debug.Log(string.Format("finalScore {0}", PlayerPreferences.finalScore));
        FindObjectOfType<AudioManager>().Play("MainTheme");
        FindObjectOfType<PlayerMovement>().StartMovement();
    }

    public void EndGame()
    {
        if (GameOver == false)
        {
            GameOver = true;
            SceneManager.LoadScene("lvl0");
        }
        
    }

    public void LevelComplete()
    {
        Debug.Log("Finished the level");
        LevelScore.text = string.Format("Score: {0}", PlayerPreferences.finalScore);
        LevelCompleteScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("LevelComplete");
        Invoke("EndGame", 2);
    }

    public void Restart()
    {
        Debug.Log("Restarting the game");
        FinalScore.text = string.Format("Score: {0}", PlayerPreferences.finalScore);
        GameOverScreen.SetActive(true);
        Invoke("RestartLevel", 2);
        
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CreateGamePrefsBasedOnChoiceList()
    {
        //             Speedy                ||     Lucky                       ||       Moody
        // Red Color                         || White Color                     || Blue Color
        // Code 0                            || Code 1                          || Code 2
        // Low Mass (0.5)                    || Normal Mass (1.0)               || Large Mass (2.0)
        // Larger speed increments (50)      || Regular speed increments (30)   || Low speed increments (15)
        // Time between drops (50)           || Time between drops (20)         || Time between drops (35)

        // Level 1                          || Level 2                          || Level 3
        // Code 0                           || Code 1                           || Code 2
        // Maximum distance  250            || Maximum distance  350            || Maximum distance  550                    
        // Minimum distance longblocks   20 || Minimum distance longblocks   25 || Minimum distance longblocks   30 
        // Minimum distance smallblocks  10 || Minimum distance smallblocks  15 || Minimum distance smallblocks  10 
        // DropThreshold                 20 || DropThreshold                 30 || DropThreshold                 50


        // Easy                               || Medium                           || Hard
        // Code 0                             || Code 1                           || Code 2
        // Maximum distance  *0.8             || Maximum distance  *1             || Maximum distance  *1.5                    
        // Minimum distance longblocks   *1.2 || Minimum distance longblocks   *1 || Minimum distance longblocks   *0.8 
        // Minimum distance smallblocks  *1.2 || Minimum distance smallblocks  *1 || Minimum distance smallblocks  *0.8 
        // DropThreshold                 *1.3 || DropThreshold                 *1 || DropThreshold                 *0.7

        int difficultySelected = (int)PlayerPreferences.difficultyCode;

        switch (difficultySelected)
        { 
            case 0:
                PlayerPreferences.sizeOfLevel1 = (float)0.8 * 250;
                PlayerPreferences.distanceBetweenLongBlocks1 = (float)1.2 * 20;
                PlayerPreferences.distanceBetweenSmallBlocks1 =(float)1.2 * 10;
                PlayerPreferences.levelDropThreshold1 = (float)1.3 * 20;
                //PlayerPreferences.sizeOfLevel2 = (float)0.8 * 350;
                //PlayerPreferences.distanceBetweenLongBlocks2 = (float)1.2 * 25;
                //PlayerPreferences.distanceBetweenSmallBlocks2 = (float)1.2 * 15;
                //PlayerPreferences.levelDropThreshold2 = (float)1.3 * 30;
                //PlayerPreferences.sizeOfLevel3 = (float)0.8 * 550;
                //PlayerPreferences.distanceBetweenLongBlocks3 = (float)1.2 * 30;
                //PlayerPreferences.distanceBetweenSmallBlocks3 = (float)1.2 * 10;
                //PlayerPreferences.levelDropThreshold3 = (float)1.3 * 50;
                break;
            case 1:
                PlayerPreferences.sizeOfLevel1 = (float)1 * 250;
                PlayerPreferences.distanceBetweenLongBlocks1 = (float)1 * 20;
                PlayerPreferences.distanceBetweenSmallBlocks1 = (float)1 * 10;
                PlayerPreferences.levelDropThreshold1 = (float)1 * 20;
                //PlayerPreferences.sizeOfLevel2 = (float)1 * 350;
                //PlayerPreferences.distanceBetweenLongBlocks2 = (float)1 * 25;
                //PlayerPreferences.distanceBetweenSmallBlocks2 = (float)1 * 15;
                //PlayerPreferences.levelDropThreshold2 = (float)1 * 30;
                //PlayerPreferences.sizeOfLevel3 = (float)1 * 550;
                //PlayerPreferences.distanceBetweenLongBlocks3 = (float)1 * 30;
                //PlayerPreferences.distanceBetweenSmallBlocks3 = (float)1 * 10;
                //PlayerPreferences.levelDropThreshold3 = (float)1 * 50;
                break;
            case 2:
                PlayerPreferences.sizeOfLevel1 = (float)1.5 * 250;
                PlayerPreferences.distanceBetweenLongBlocks1 = (float)0.8 * 20;
                PlayerPreferences.distanceBetweenSmallBlocks1 = (float)0.8 * 10;
                PlayerPreferences.levelDropThreshold1 = (float)0.7 * 20;
                //PlayerPreferences.sizeOfLevel2 = (float)1.5 * 350;
                //PlayerPreferences.distanceBetweenLongBlocks2 = (float)0.8 * 25;
                //PlayerPreferences.distanceBetweenSmallBlocks2 = (float)0.8 * 15;
                //PlayerPreferences.levelDropThreshold2 = (float)0.7 * 30;
                //PlayerPreferences.sizeOfLevel3 = (float)1.5 * 550;
                //PlayerPreferences.distanceBetweenLongBlocks3 = (float)0.8 * 30;
                //PlayerPreferences.distanceBetweenSmallBlocks3 = (float)0.8 * 10;
                //PlayerPreferences.levelDropThreshold3 = (float)0.7 * 50;
                break;
            default:
                PlayerPreferences.sizeOfLevel1 = (float)0.8 * 250;
                PlayerPreferences.distanceBetweenLongBlocks1 = (float)1.2 * 20;
                PlayerPreferences.distanceBetweenSmallBlocks1 = (float)1.2 * 10;
                PlayerPreferences.levelDropThreshold1 = (float)1.3 * 20;
                //PlayerPreferences.sizeOfLevel2 = (float)0.8 * 350;
                //PlayerPreferences.distanceBetweenLongBlocks2 = (float)1.2 * 25;
                //PlayerPreferences.distanceBetweenSmallBlocks2 = (float)1.2 * 15;
                //PlayerPreferences.levelDropThreshold2 = (float)1.3 * 30;
                //PlayerPreferences.sizeOfLevel3 = (float)0.8 * 550;
                //PlayerPreferences.distanceBetweenLongBlocks3 = (float)1.2 * 30;
                //PlayerPreferences.distanceBetweenSmallBlocks3 = (float)1.2 * 10;
                //PlayerPreferences.levelDropThreshold3 = (float)1.3 * 50;
                break;
        }

        int characterSelected = (int)PlayerPreferences.characterCode;

        switch (characterSelected)
        {
            case 0:
                PlayerPreferences.characterColor = (float)0;
                PlayerPreferences.characterMass = (float)0.5;
                PlayerPreferences.characterSpeedIncrement = (float)50;
                PlayerPreferences.characterDropTime = (float)50;
                break;
            case 1:
                PlayerPreferences.characterColor = (float)1;
                PlayerPreferences.characterMass = (float)1;
                PlayerPreferences.characterSpeedIncrement = (float)30;
                PlayerPreferences.characterDropTime = (float)20;
                break;
            case 2:
                PlayerPreferences.characterColor = (float)2;
                PlayerPreferences.characterMass = (float)2;
                PlayerPreferences.characterSpeedIncrement = (float)15;
                PlayerPreferences.characterDropTime = (float)35;
                break;
            default:
                PlayerPreferences.characterColor = (float)0;
                PlayerPreferences.characterMass = (float)0.5;
                PlayerPreferences.characterSpeedIncrement = (float)50;
                PlayerPreferences.characterDropTime = (float)50;
                break;
        }
    }

    public void SpawnBasedOnDifficulty()
    {
        string temp = SceneManager.GetActiveScene().name;
        string sceneIndex = temp.Substring(temp.Length - 1, 1);

        for (int z = 10; z < PlayerPreferences.sizeOfLevel1; z += (int)PlayerPreferences.distanceBetweenLongBlocks1)
        {
            float random = Random.Range(-4.5f, 4.5f);
            Vector3 position = new Vector3(Random.Range(-2.5f, 2.5f), 1, z);
            Instantiate(LongBlock, position, Quaternion.identity);
        }
        for (int z = 15; z < PlayerPreferences.sizeOfLevel1; z += (int)PlayerPreferences.distanceBetweenSmallBlocks1)
        {
            Vector3 position = new Vector3(Random.Range(-4.5f, 4.5f), 1, z);
            Instantiate(SmallBlock, position, Quaternion.identity);
        }
        for (int z = 0; z < PlayerPreferences.sizeOfLevel1; z += (int)PlayerPreferences.characterDropTime)
        {
            if (Random.Range(0f, 100f) < PlayerPreferences.levelDropThreshold1)
            {
                Vector3 position = new Vector3(Random.Range(-4.5f, 4.5f), 1, z);
                Instantiate(PowerUp, position, Quaternion.identity);
            }
        }

    }
}
