using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuInfo : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string fistTime = "Начать";
    [SerializeField] private string otherTime = "Начать заново";
    [SerializeField] private bool hide = false;
    private int stage;
    void Awake()
    {
        stage = PlayerPrefs.GetInt("Stage", 1);
        if(stage == 1)
        {
            text.text = fistTime;
            if (hide)
            {
                button.SetActive(false);
            }
        }
        else
        {
            text.text = otherTime;
        }
    }

}
