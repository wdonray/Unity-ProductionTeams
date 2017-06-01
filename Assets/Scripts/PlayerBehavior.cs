using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour, IDamageable, IDamager
{
    
    public int hp = 100;
    private int attackPower = 10;
    public GameObject bottle;
    private GameObject b;
    public void ThrowBottle()
    {
        b = Instantiate(bottle, transform, false);
        b.transform.SetParent(null);
        b.GetComponent<Rigidbody>().velocity += transform.TransformDirection(0, 0, 25);
        Destroy(b, 10);
    }


    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void DoDamage(IDamageable defender)
    {
        throw new System.NotImplementedException();
    }

    public void Dead()
    {
        gameObject.GetComponent<Material>().color = Color.red;
    }

    Ray cameraRay; // The ray that is cast from the camera to the mouse position
    RaycastHit cameraRayHit; //RaycastHit cameraRayHit; // The object that the ray hits

    public float theta;
    public void Update()
    {
       

        //top down only
        var worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 13.5f));
       // transform.LookAt(worldPoint);
        if (Input.GetMouseButtonDown(0))
        {
            var go = Instantiate(prefab, worldPoint, Quaternion.identity);



            Vector3 targetPos = new Vector3(go.transform.position.x, (go.transform.position.y - go.transform.position.y), go.transform.position.z);
            gameObject.transform.LookAt(targetPos);

                  

            //Vector3 dis = transform.position - targetPos;
            //theta = Vector3.Dot(transform.forward, targetPos);
            //transform.Rotate(Vector3.up, Mathf.Abs(theta) * Mathf.Rad2Deg);


            //theta = Vector3.Dot(transform.forward,  go.transform.position);
            //transform.Rotate(Vector3.up, Mathf.Abs(theta) * Mathf.Rad2Deg);
        }

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


    public GameObject prefab;
}
