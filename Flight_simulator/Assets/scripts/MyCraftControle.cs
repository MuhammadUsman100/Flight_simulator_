using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCraftControle : MonoBehaviour
{
    [SerializeField]
    public Transform WORLD;
    public float horizontal_speed, vertical_speed, forward_speed;
    public Transform craft;
    public float distance_from_earth;
    Transform pivot;



    // Update is called once per frame
    void Update()
    {
       

        float h = horizontal_speed * Input.GetAxis("Mouse X");
        float v = vertical_speed * Input.GetAxis("Vertical");

        ///////////////rotating wrld////////////////////////////////
        pivot = craft;
        //WORLD.Rotate(0,h,0);
        WORLD.transform.RotateAround(pivot.position, Vector3.up,h);


         
         

        ///////////////////////positioning word/////////////////////
        
           WORLD.position += new Vector3(0, 0, v);



    }
}
