using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWay : MonoBehaviour
{
    [SerializeField] private string _violation = "�������� �� �� ��������";
    private void OnTriggerEnter(Collider other)
    {
        RoadManager.Instance.Violation(this, _violation);
    }
}
