using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWay : MonoBehaviour
{
    [SerializeField] private string _violation = "Движение не по маршруту";
    private void OnTriggerEnter(Collider other)
    {
        RoadManager.Instance.Violation(this, _violation);
    }
}
