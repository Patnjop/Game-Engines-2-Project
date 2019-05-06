using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelleBehaviours : MonoBehaviour
{
    public GameObject ship;
    public GameObject target;
    public bool EMPed = false;
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new PursueState());
    }
    void Update()
    {
        //When the EMP goes off the second time
        if (ship.GetComponent<NebuController>().EMPCount == 2)
        {
            EMPed = true;
        }
        //when the sentinelles can reactivate
        if (ship.GetComponent<NebuController>().canActivate == true)
        {
            GetComponent<StateMachine>().ChangeState(new SeekState());
            GetComponent<Seek>().enabled = true;
            GetComponent<Seek>().targetGameObject = target;
            EMPed = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check if it needs to seperate
        if (other.tag == "Enemy")
        {
            GetComponent<Seperate>().avoided = false;
            //Debug.Log("Collision" + gameObject.name + " " + other.gameObject.name);
            GetComponent<StateMachine>().ChangeState(new SeperateState());
        }
    }
}
public class SeperateState : State
{
    public override void Enter()
    {
        owner.GetComponent<Seperate>().enabled = true;
    }
    public override void Think()
    {
        if (owner.GetComponent<Seperate>().avoided == true)
        {
            if (Vector3.Distance(owner.transform.position, owner.GetComponent<SentinelleBehaviours>().ship.transform.position) < 20 && owner.GetComponent<SentinelleBehaviours>().EMPed == false)
            {
                owner.ChangeState(new PursueState());
            }
            else if (Vector3.Distance(owner.transform.position, owner.GetComponent<SentinelleBehaviours>().ship.transform.position) > 100 && owner.GetComponent<SentinelleBehaviours>().EMPed == false)
            {
                owner.ChangeState(new SeekState());
            }
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Seperate>().enabled = false;
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
        if (Time.time >= 40)
        {
            if (Vector3.Distance(owner.transform.position, owner.GetComponent<SentinelleBehaviours>().ship.transform.position) > 100 && owner.GetComponent<SentinelleBehaviours>().EMPed == false)
            {
                owner.ChangeState(new SeekState());
                owner.GetComponent<Boid>().maxSpeed = 155;
                owner.GetComponent<Boid>().maxForce = 30;
            }
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
        if (Vector3.Distance(owner.transform.position, owner.GetComponent<SentinelleBehaviours>().ship.transform.position) < 35 && owner.GetComponent<SentinelleBehaviours>().EMPed == false)
        {
            owner.ChangeState(new PursueState());
            owner.GetComponent<Boid>().maxSpeed = 110;
            owner.GetComponent<Boid>().maxForce = 20;
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}



