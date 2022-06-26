using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private GameObject _loseMenu;

    private static RoadManager instance;
    public static RoadManager Instance => instance;

    private int _side;
    private Vector3 _position;
    private Vector3 _rightVec;
    private bool _violation;

    public event Action OnViolation;

    private void Awake()
    {
        instance = this;
    }

    public void ExitFromRoad(int side,Vector3 position, Vector3 rightVec)
    {
        _side = side;
        _position = position;
        _rightVec = rightVec;
    }

    public void EnterToRoad(Vector3 position)
    {

        float offset = Vector3.Dot(_position - position, _rightVec);
        Debug.Log(offset);
        if (GetRotationSide(offset) != 0)
        {
            
            if(_side == GetRotationSide(offset) && _side!=2)
            {
                //SendMessageToPlayer("Correct");
            }
            else
            {
                SendMessageToPlayer("ѕеред поворотом направо, налево или разворотом водитель об€зан заблаговременно зан€ть соответствующее крайнее положение на проезжей части, предназначенной дл€ движени€ в данном направлении, кроме случаев, когда совершаетс€ поворот при въезде на перекресток, где организовано круговое движение.");
            }
        }
    }

    private int GetRotationSide(float offset)
    {
        if (offset < -16)
        {
            return 1;
        }
        if (offset > 15)
        {
            return -1;
        }
        return 0;
    }

    public void SendMessageToPlayer(string message)
    {
        if(!_violation)
        {
            _violation = true;
            OnViolation?.Invoke();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<PlayerMovement>().enabled = false;
            Missions.Instance.HideMissionText();
            _loseMenu.SetActive(true);
            _textMeshPro.text = message;
        }
    }

    public void Violation(CurbRule curb)
    {
        SendMessageToPlayer("«аезд на тротуар");
    }

    public void Violation(DoubleSolidLine line)
    {
        SendMessageToPlayer("ѕересечение двойной сплошной");
    }

    public void Violation(SolidLine line)
    {
        SendMessageToPlayer("ѕересечение сплошной");
    }

    public void Violation(WrongWay way, string Violation)
    {
        SendMessageToPlayer(Violation);
    }

    public void Violation(ObstacleTrigger obstacle)
    {
        SendMessageToPlayer("—толкновение с транспортным средством");
    }
}
