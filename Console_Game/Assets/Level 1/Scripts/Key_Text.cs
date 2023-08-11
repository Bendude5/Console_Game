using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Key_Text : MonoBehaviour
{
    public GameObject keyAmountText;
    public int keys = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keys = GameObject.Find("Player").GetComponent<Bens_Movement>().keys;
        keyAmountText.GetComponent<TextMeshProUGUI>().text = keys.ToString(keys + "/5");

        //if (score >= 6)
        //{
        //    SceneManager.LoadScene("Completion");
        //}
    }
}
