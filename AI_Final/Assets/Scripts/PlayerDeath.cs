using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Enemy_AI")
        {
            Destroy(col.gameObject);
        } 

        if (col.gameObject.name == "Player_knight")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
