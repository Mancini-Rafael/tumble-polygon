using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Player;
    public float ForwardMovementSpeed = 100f;
    bool hasFallen = false;


    public void StartMovement()
    {
        Debug.Log("Setting mass and color based on configurations");
        Player.mass = PlayerPreferences.characterMass;
        if (PlayerPreferences.characterColor == (float)0 )
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
        if (PlayerPreferences.characterColor == (float)1 )
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
        if (PlayerPreferences.characterColor == (float)2 )
        {
            transform.GetComponent<Renderer>().material.color = Color.blue;
        }        
    }

    void FixedUpdate()
    {
        Player.AddForce(0, 0, ForwardMovementSpeed * Time.deltaTime);
        ForwardMovementSpeed += 0.5f ;

        float moveX = Input.GetAxis("MovementX");

        float moveForce = moveX * PlayerPreferences.characterSpeedIncrement;

        Player.AddForce(moveForce * Time.deltaTime, 0, 0 , ForceMode.VelocityChange);
        FindObjectOfType<ScoreCalculator>().UpdateScore();


        if (Player.position.y < -1f && !hasFallen) {
            FindObjectOfType<AudioManager>().Play("GameOver");
            hasFallen = true;
            int score = FindObjectOfType<ScoreCalculator>().GetCurrentScore();
            PlayerPreferences.finalScore = score;
            FindObjectOfType<GameManager>().Restart();
        }
    }
}
