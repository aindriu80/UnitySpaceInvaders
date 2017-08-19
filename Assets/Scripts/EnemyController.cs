using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    public float changeTimer;
    private float maxTimer;
    private bool directionSwitch;

    private Rigidbody rig;

	// Use this for initialization
	void Start ()
	{
	    maxTimer = changeTimer;
	    rig = GetComponent<Rigidbody>();
	    directionSwitch = false;
	}
	
	// Update is called once per frame
	void Update () {
        switchTimer();
		Movement();
	}

    void Movement()
    {
        if (directionSwitch)
        {
            rig.velocity = new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
        }
        else
        {
            rig.velocity = new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
        }
    }

    void switchTimer()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            
                if (directionSwitch) directionSwitch = false;
                else directionSwitch = true;
                changeTimer = maxTimer;

        }
    }
}
