using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    //public GameObject Player_knight;       camera will follow player when camera not attached to player
    //private Vector3 offset;                camera will follow player when camera not attached to player

    private Vector2 mD;

    private Transform myBody;




    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - Player_knight.transform.position;      camera will follow player when camera not attached to player

        myBody = this.transform.parent.transform;





    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Player_knight.transform.position + offset;       camera will follow player when camera not attached to player

        //Vector2 mC = Input.GetAxisRaw("Mouse X");
        Vector2 mC = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));




        mD += mC;

        //this.transform.localRotation = Quaternion.AngleAxis(-mD.y, Vector3.right);

        myBody.localRotation = Quaternion.AngleAxis(mD.x, Vector3.up); // moves the body with the camera 


    }
}
