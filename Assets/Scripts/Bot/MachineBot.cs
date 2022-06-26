using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBot : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float delay = 10f;
    private bool _allowMovement;
    void Start()
    {
        StartCoroutine(MoveTimer());
        RoadManager.Instance.OnViolation += StopMove;
        Missions.Instance.OnFinish += StopMove;
    }

    private void OnDisable()
    {
        RoadManager.Instance.OnViolation -= StopMove;
        Missions.Instance.OnFinish -= StopMove;
    }

    void FixedUpdate()
    {
        if (_allowMovement)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }
    }

    void StopMove()
    {
        _allowMovement = false;
        StopAllCoroutines();
    }

    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(delay);
        _allowMovement = true;
    } 
}
