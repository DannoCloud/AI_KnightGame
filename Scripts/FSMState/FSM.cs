using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    protected TransForm playerTransform;

    protected Vector3 destPos;

    protected GameObject[] pointList;

    protected float swingRate;
    protected float elapsedTime;

    public Transform enemy { get; set; }
    public Transform swingSpawnPoint { get; set; }

    protected virtual void Initialize() { }
    protected virtual void FSMUpdate() { }
    protected virtual void FSMFixedUpdate() { }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        FSMUpdate();
    }

    void FixedUpdate()
    {
        FSMFixedUpdate();
    }
}
