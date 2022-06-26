using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsTriggers : MonoBehaviour
{
    [SerializeField] private string _missionText;
    [SerializeField] private bool _hideMission;

    private void OnTriggerEnter(Collider other)
    {
        if (_hideMission)
        {
            Missions.Instance.HideMissionText();
        }
        else
        {
            Missions.Instance.ShowMissionText(_missionText);
        }
    }
}
