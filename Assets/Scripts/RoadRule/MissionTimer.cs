using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTimer : MonoBehaviour
{
    [SerializeField] private float _timeForMission = 30f;
    [SerializeField] private string _missionName = "Время на упражнение вышло";
    private void Start()
    {
        Missions.Instance.OnFinish += StopTimer;
        RoadManager.Instance.OnViolation += StopTimer;
        StartCoroutine(Timer());
    }

    private void OnDisable()
    {
        Missions.Instance.OnFinish -= StopTimer;
        RoadManager.Instance.OnViolation -= StopTimer;
    }

    private void StopTimer()
    {
        StopAllCoroutines();
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timeForMission);
        RoadManager.Instance.SendMessageToPlayer(_missionName);
    }
}
