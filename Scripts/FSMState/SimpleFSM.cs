using System.Collections;
using UnityEngine;

public class SimpleFSM : FSM
{
    public enum FSMState
    {
        Patrol,
        Chase,
        Attack,
        Dead,
    }

    public FSMState curState;

    private float curSpeed;

    private float curRotSpeed;

    public GameObject Steel_Dagger; //Will have to give it to them 

    private bool isDead;
    private int health;

    new private Rigidbody rigidbody;



    protected override void Initialize()
    {
        curState = FSMState.Patrol;
        curSpeed = 150.0f;
        curRotSpeed = 2.0f;
        isDead = false;
        elapsedTime = 0.0f;
        shootRate = 3.0f;
        health = 100;

        pointList = GameObject.FindGameObjectsWithTag("Walkingpoint");

        FindNextPoint();

        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        playerTransform = objPlayer.transform;

        rigidbody = GetComponent<Rigidbody>();

        if(!playerTransform)
        {
            print("Player doesn't exist... Please add one with Tag named 'Player'");
        }

        //Steel_Dagger = gameObject.transform.Getchild(0).transform;     //Need to get this working 
        //bulletSpawnPoint = turret.GetChild(0).transform;                 // figuer What needs to go here or if it is even needed

    }
    


    protected override void FSMUpdate()
    {
        switch(curState)
        {
            case FSMState.Patrol: UpdatePatrolState();break;
            case FSMState.Chase: UpdateChaseState();break;
            case FSMState.Attack: UpdateAttackState();break;
            case FSMState.Dead: UpdateDeadState();break;
        }

        elapsedTime += Time.deltaTime;

        if(health <= 0)
        {
            curState = FSMState.Dead;
        }
    }





}
