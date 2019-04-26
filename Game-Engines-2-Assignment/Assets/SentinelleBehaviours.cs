using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelleBehaviours : MonoBehaviour
{
    public GameObject ship;
    public bool EMPed = false;
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new PursueState());
    }
}
public class PursueState : State
{
    public override void Enter()
    {
        owner.GetComponent<OffsetPursue>().enabled = true;
    }
    public override void Think()
    {
        if (Vector3.Distance(owner.transform.position, owner.GetComponent<SentinelleBehaviours>().ship.transform.position) < 100 && owner.GetComponent<SentinelleBehaviours>().EMPed == false)
        {
            owner.ChangeState(new SeekState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<OffsetPursue>().enabled = false;
    }
}
public class SeekState : State
{
    public override void Enter()
    {
        owner.GetComponent<Seek>().targetGameObject = owner.GetComponent<SentinelleBehaviours>().ship;
        owner.GetComponent<Seek>().enabled = true;
    }
    public override void Think()
    {
        if (Vector3.Distance(owner.transform.position, owner.GetComponent<SentinelleBehaviours>().ship.transform.position) < 20 && owner.GetComponent<SentinelleBehaviours>().EMPed == false)
        {
            owner.ChangeState(new PursueState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}



