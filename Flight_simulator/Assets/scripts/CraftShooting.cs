using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShooting : MonoBehaviour
{
    public int _total_bullets;
    public GameObject[] _Right_bullets, _left_bullets1;
    public Transform _position1, _position2;
    public GameObject bullet;
    int remaining_bullets;
    public float NEXT_FIRE = 0;
    int firing_bulletes=0;
    public Camera cam;
    public float bullet_speed=0.01f;


    /// <summary>
    ///singalton
    /// </summary>


    private static CraftShooting instance;

    public static CraftShooting Instance
    {
        get
        {
            return instance;
        }
        
    }
    void Awake()
    {
        if (!Instance || Instance != this) instance = this;

        /////////////////////// instantiating bullets ////////////////////////////

        for (int i = 0; i < _total_bullets - 1; i++)
        {
            _Right_bullets[i] = Instantiate(bullet, _position1.position, _position1.rotation);
            _Right_bullets[i].transform.parent = _position1;
            
            _left_bullets1[i] = Instantiate(bullet, _position2.position, _position2.rotation);
            _left_bullets1[i].transform.parent = _position2;
            
        }
        remaining_bullets = _total_bullets;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if (hit.collider)
            {
                if (remaining_bullets > 0)
                {
                    if (Input.GetMouseButton(0) && Time.time >= NEXT_FIRE)
                    {
                        NEXT_FIRE = Time.time + 1F / 15;
                        shoot(hit.point);
                    }
                }
            }
        }

    }


    void shoot(Vector3 pos)
    {
        
        _Right_bullets[firing_bulletes].transform.position = Vector3.Lerp(_Right_bullets[firing_bulletes].transform.position,pos,10*Time.deltaTime);
        _left_bullets1[firing_bulletes].transform.position = Vector3.Lerp(_left_bullets1[firing_bulletes].transform.position, pos, 10 * Time.deltaTime);
        firing_bulletes++;
        Debug.Log("CraftShooting");
    }

    public Vector3 getrightgunposition()
    {
        return _position1.position;
    }
    public Vector3 getleftgunposition()
    {
        return _position2.position;
    }
}
