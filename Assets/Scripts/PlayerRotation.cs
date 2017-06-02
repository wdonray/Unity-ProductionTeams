using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {



    Ray cameraRay; // The ray that is cast from the camera to the mouse position
    RaycastHit cameraRayHit; //RaycastHit cameraRayHit; // The object that the ray hits

    public float theta;
    public void Update()
    {


        //top down only
        //var worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y ));
        Vector3 pos = Input.mousePosition;
        // transform.LookAt(worldPoint);
        //if (Input.GetMouseButtonDown(0))
        //{
        //var go = Instantiate(prefab, worldPoint, Quaternion.identity);


        //var rotation = new Quaternion(0,Mathf.Sin());
        //this.transform.LookAt(new Vector3(0,0,0));
        //Vector3 targetPos = new Vector3(pos.x, 1, pos.y);
        //Quaternion toRotate = new Quaternion(targetPos.x, targetPos.y, targetPos.z, 1);
        //toRotate = toRotate * new Quaternion(0, Mathf.Sin((45f / 180f) * Mathf.PI) / 2, 0,
        //               Mathf.Cos((45f / 180f) * Mathf.PI) / 2);
        //targetPos = new Vector3(toRotate.x, toRotate.y, toRotate.z).normalized;
        //float angle = Mathf.Deg2Rad * Vector3.Angle(this.transform.forward, targetPos);

        //Debug.Log(angle);
        //this.transform.rotation = this.transform.rotation *
        //                          new Quaternion(0, Mathf.Sin(angle) / 2, 0, Mathf.Cos(angle) / 2);


        //gameObject.transform.LookAt();


        Vector3 targetPos = new Vector3(Input.mousePosition.x, (Input.mousePosition.y - Input.mousePosition.y), Input.mousePosition.z);
        Vector3 dis = transform.position - targetPos;
        theta = Vector3.Dot(transform.forward, targetPos);
        transform.Rotate(Vector3.up, Mathf.Abs(theta) * Mathf.Rad2Deg);


        //theta = Vector3.Dot(transform.forward,  go.transform.position);
        //transform.Rotate(Vector3.up, Mathf.Abs(theta) * Mathf.Rad2Deg);
        //}

        //// Cast a ray from the camera to the mouse cursor
        //cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //// If the ray strikes an object...  
        //if (Physics.Raycast(cameraRay, out cameraRayHit))
        //{
        //    // ...and if that object is the ground...
        //    if (cameraRayHit.transform.tag == "Ground")
        //    {
        //        // ...make the cube rotate (only on the Y axis) to face the ray hit's position 
        //        Vector3 targetposition = new Vector3(Input.mousePosition.x, this.transform.position.y, Input.mousePosition.z);
        //        this.transform.LookAt(targetposition);
        //  }
        // }




    }

}
