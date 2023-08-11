using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_States : MonoBehaviour
{
    //For arcade machine colour
    public int bossState;

    public void setBossState(int state)
    {
        bossState = state;
    }

    public void bossDefeated()
    {
        SceneManager.LoadScene("Credits");
    }
}
