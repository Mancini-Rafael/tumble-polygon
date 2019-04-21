using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using EZCameraShake;

public class PlayerCollision : MonoBehaviour
{
    public ScoreCalculator scoreCalculator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacles")
        {
            scoreCalculator.numberOfHits += 1;
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
            
            FindObjectOfType<AudioManager>().Play("PlayerHit");

            StartControllerVibration();
            Invoke("EndControllerVibration", .5f);
        }

        if (collision.collider.tag == "PowerUp")
        {
            Debug.Log("Hit a powerup");
            scoreCalculator.numberOfPowerUps += 1;
            CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .1f);
            FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PowerUp")
        {
            Debug.Log("Hit a powerup");
            scoreCalculator.numberOfPowerUps += 1;
            CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .1f);
            FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }

    private void StartControllerVibration()
    {
        GamePad.SetVibration(0, 1f, 1f);
    }
    private void EndControllerVibration()
    {
        GamePad.SetVibration(0, 0f, 0f);
    }

}
