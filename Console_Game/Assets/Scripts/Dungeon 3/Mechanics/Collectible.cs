using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    PlayerProgress progressPlayer;

    [SerializeField]
    ProgressManager progressGame;

    public GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Coin")
        {
            Destroy(gameObject);
            progressPlayer.coins += 1;
        }
        else if (gameObject.tag == "Goal")
        {
            winScreen.SetActive(true);
            Invoke("WinScreen", 3);
        }
    }

    public void WinScreen()
    {
        progressGame.level2Complete= true;
        SceneManager.LoadScene("HUB");
        //saves player coin progress to scriptable object
        progressGame.coins += progressPlayer.coins;
    }
}
