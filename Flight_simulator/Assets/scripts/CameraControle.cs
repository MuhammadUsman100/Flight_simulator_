using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControle : MonoBehaviour
{
    public Transform target;
    public Transform camera;

    private static CameraControle instance;

    public static CameraControle Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {

        if (!Instance || Instance != this) instance = this;


    }

   
    void Update()
    {
        camera.transform.position = target.position - new Vector3(0,-20,30);
    }
}
