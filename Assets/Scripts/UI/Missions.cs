using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Missions : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHolder;
    [SerializeField] private GameObject _missionUIholder;
    [SerializeField] private GameObject _finishUI;

    private static Missions instance;
    public static Missions Instance => instance;
    public event Action OnFinish;
    

    private void Awake()
    {
        instance = this;
    }
    public void ShowMissionText(string missionText)
    {
        _missionUIholder.SetActive(true);
        _textHolder.text = missionText;
    }

    public void HideMissionText()
    {
        _missionUIholder.SetActive(false);
    }

    public void ShowFinishMenu()
    {
        HideMissionText();
        OnFinish?.Invoke();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerMovement>().enabled = false;
        _finishUI.SetActive(true);
    }
}
