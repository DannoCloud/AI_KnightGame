using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnSight : MonoBehaviour
{
    public Transform  Enemy_AI;

    public int MoveSpeed = 4;  // original line of sight 
    int Dist = 10;





    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Enemy_AI.position) <= Dist)                     // player is in range and will go after player no matter the derection coming from 
        {
            transform.LookAt(Enemy_AI);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
           
        }

    }



}
