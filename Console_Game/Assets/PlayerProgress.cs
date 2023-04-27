using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    [SerializeField]
    ThirdPersonController player;

    public int health;
    public float timer = 0;

    public int coins;
    public bool touchingRock;

    public GameObject gameOver;
    public GameObject drowning;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public TMP_Text coinText;

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
        coinText.text = coins.ToString();
        if (gameObject.transform.position.y < -0.45 && health > 0)
        {
            Debug.Log("Drowning");
            drowning.SetActive(true);
            
            timer++;
            if (timer == 500)
            {
                health -= 1;
                timer = 0;
            }
        }
        else { drowning.SetActive(false); }
    }

    public void HealthCheck()
    {
        switch (health)
        {
            case 0:
                gameOver.SetActive(true);
                drowning.SetActive(false);

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

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == "Damage")
        {
            Debug.Log("Damaged");
            health -= 1;
            player.yDir = 5;
        }
        
    }

    public void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Rock":
                touchingRock = true;
                break;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Rock":
                touchingRock = false;
                break;
        }
    }
}
