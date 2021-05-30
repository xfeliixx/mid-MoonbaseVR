using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidCollision : MonoBehaviour
{

    [SerializeField] private GameObject asteroidExplosionGO;

    [Header("The Canvas shown when asteroid destroyed")]
    public GameObject pointsCanvas;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            //Destroy the Asteroid
            Destroy(collision.gameObject);

            Instantiate(asteroidExplosionGO, collision.transform.position, collision.transform.rotation);

            float distanceFromPlayer = Vector3.Distance(transform.position, new Vector3(104f, 1.186f, 88.1f));
            int extraPoints = (int)distanceFromPlayer;

            int scoreToDisplay = 10 * extraPoints;

            if (GameManager.eGameStatus == GameManager.GameState.Playing)
            {
                //create the canvas
                GameObject displayAsteroidScore = Instantiate(pointsCanvas, transform.position, Quaternion.identity);

                //assign the text or score to the created text box
                displayAsteroidScore.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = scoreToDisplay.ToString();

                displayAsteroidScore.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10),
                                                                        transform.localScale.y * (distanceFromPlayer / 10),
                                                                        transform.localScale.z * (distanceFromPlayer / 10));
            }
         
            //Send notification to game manager that we hit an asteroid
            GameManager.AsteroidHit(extraPoints);

            //Laser is destroyed
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
