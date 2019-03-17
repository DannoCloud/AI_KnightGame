using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    public PatrolState(Transform[] wp)
    {
        waypoints = wp;
        stateID = FSMStateID.Patrolling;

        curRotSpeed = 1.0f;
        curSpeed = 100.0f;
    }

    public override void Reason(Transform player, Transform npc)
    {
        if(Vector3.Distance(npc.position, player.position) <= 300.0f)
        {
            Debug.Log("Switch to Chase State");
            npc.GetComponent<NPCEnemyController>().SetTransition(Transition.SawPlayer);
        }

        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }

  




}
