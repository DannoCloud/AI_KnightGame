using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    
    public ChaseState(Transform[] wp)
    {
        waypoints = wp;
        stateID = FSMState.Chasing;

        curRotSpeed = 1.0f;
        curSpeed = 100.0f;

        FindNextPoint();
    }

    public override void Reason(Transform player, Transform npc)
    {
        destPos = player.position;

        float dist = Vector3.Disance(npc.position, destPos);
        if (dist <= 200.0f)
        {
            Debug.Log("Switch to Attack state");
            npc.GetComponent<NPCEnemyController>().SetTransition(Transition.ReachPlayer);
        }
        else if (dist >= 300.0f)
        {
            Debug.Log("Switch to Patrol state");
            npc.GetComponent<NPCEnemyController>().SetTransition(Transition.LostPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        destPos = player.position;

        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }



}
