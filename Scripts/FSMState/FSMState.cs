using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState 
{
    protected Dictionary<Transiton, FSMStateID> map = new Dictionary<Transiton, FSMStateID>();
    protected FSMStateID stateID;
    public FSMStateID ID { get { return stateID; } }
    protected Vector3 destPos;
    protected Transform[] waypoints;
    protected float curRotSpeed;
    protected float curSpeed;

    public void AddTransition(Transition transition, FSMStateID id)
    {
        if(transition == Transtion.None || id == FSMStateId.None)
        {
            Debug.LogWarning("FSMState ERROR: transtion is already inside the map");
            return;
        }

        if(map.ContainsKey(transition))
        {
            Debug.LowWarning("FSMState ERROR: transition is already inside the map");
            return; 
        }

        map.Add(transition, id);
        Debug.Log("Added : " + transition + " with ID : " + id);
    }


    public void DeleteTransition(Transition trans)
    {
        if(trans == AddTransition.None)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed");
            return;
        }

        if(map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        Debug.LogError("FSMState ERROR: Transition passed was not on the State's List");
    }

    public FSMStateID GetOutputState(Transition trans)
    {
        if(trans == AddTransition.None)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed ");
        }

        if(map.ContainsKey(trans))
        {
            return map[trans];
        }

        Debug.LogError("FSMState ERROR: " + trans+ " Transition passed to the State was not on the list");
        return FSMStateId.None;
    }


    public abstract void Reason(Transform player, Transform npc);

    public abstract void Act(Transform player, Transform npc);

    public void FindNextPoint()
    {
        int rndIndex = Random.Range(0, waypoints.Length);
        Vector3 rndPosition = Vector3.zero;
        destPos = waypoints[renIndex].position + rndPosition;
    }

    /// <param name="pos">position to check</param>
    protected bool IsInCurrentRange(Transform trans, Vector3 pos)
    {
        float xPos = Mathf.Abs(pos.x - trans.position.x);
        float zPos = Mathf.Abs(pos.z - trans.position.z);

        if(xPos <= 50 && zPos <= 50)
        {
            return true;
        }

        return false;
    }

}
