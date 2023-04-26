using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProgress : MonoBehaviour
{
    public int health;

    public int coins;

    public GameObject gameOver;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }

    public void HealthCheck()
    {
        switch (health)
        {
            case 0:
                gameOver.SetActive(true);                

                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                
                Invoke("GameOver", 3);
                break;

            case 1:
                heart1.SetActive(true);

                heart2.SetActive(false);
                heart3.SetActive(false);
                break;

            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);

                heart3.SetActive(false);
                break;

            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("HUB");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            health -= 1;
        }
        
    }
}
