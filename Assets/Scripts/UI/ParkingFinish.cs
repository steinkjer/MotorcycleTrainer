using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingFinish : MonoBehaviour
{

    private Coroutine _corutine;
    private bool _timerStarted;

    private void Start()
    {
        RoadManager.Instance.OnViolation += StopTrigger;
    }

    private void OnDisable()
    {
        RoadManager.Instance.OnViolation -= StopTrigger;
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody player = other.GetComponent<Rigidbody>();
        if(!_timerStarted)
        {
        _corutine = StartCoroutine(FinishTimer());
        _timerStarted = true;
        }
        if (player.velocity.sqrMagnitude > 0.5f)
        {
            StopCoroutine(_corutine);
            _timerStarted = false;
        }
    }

    private void StopTrigger()
    {
        StopAllCoroutines();
        Destroy(this);
    }

    private IEnumerator FinishTimer()
    {
        yield return new WaitForSeconds(3);
        Missions.Instance.ShowFinishMenu();
        Destroy(this);
    }
}
