using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurbRule : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RoadManager.Instance.Violation(this);
        Vector3 pos = other.transform.position;
        pos.y = 1.425f;
        other.transform.position = pos;
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 pos = other.transform.position;
        pos.y = 1.08f;
        other.transform.position = pos;
    }
}
