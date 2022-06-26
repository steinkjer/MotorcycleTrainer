using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadRule : MonoBehaviour
{
    private DebugExtensions _vecDebug;

    private void Awake()
    {
        _vecDebug = new DebugExtensions(transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        CalculateRule(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CalculateRule(other);
    }

    private void CalculateRule(Collider other)
    {
        Vector3 relativePos = other.transform.position - transform.position;
        float offset = Vector3.Dot(relativePos, transform.right);
        float side = Vector3.Dot(relativePos.normalized, transform.forward);
        side /= Mathf.Abs(side);
        float motorcycleSide = Vector3.Dot(other.transform.forward, -transform.forward);
        motorcycleSide /= Mathf.Abs(motorcycleSide);
        _vecDebug.DrawVector(relativePos, Color.blue, 0.1f);
        switch (motorcycleSide)
        {
            case 1:
                //Debug.Log("Enter");
                RoadManager.Instance.EnterToRoad(other.transform.position);
                break;
            case -1:
                //Debug.Log("Exit" + GetRotationSide(offset));
                RoadManager.Instance.ExitFromRoad(GetRotationSide(offset), transform.position, transform.right);
                break;
        }
        //Debug.Log($"offset{offset}/side{side}/motoside{motorcycleSide}");
    }

    private int GetRotationSide(float offset)
    {
        if (offset < 0)
        {
            return 0;
        }
        if (offset < 2.05f)
        {
            return -1;
        }
        if (offset > 7.15f)
        {
            return 1;
        }
        return 2;
    }
}
