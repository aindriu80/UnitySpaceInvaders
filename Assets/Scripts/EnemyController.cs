﻿using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float changeTimer;
    public GameObject particleEffect;
    public bool directionSwitch;
    private float maxTimer;
    public float speed;
    public int hitPoints;

    private Rigidbody rig;

    // Use this for initialization
    private void Start()
    {
        maxTimer = changeTimer;
        rig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        switchTimer();
        Movement();
    }

    private void Movement()
    {
        if (directionSwitch)
            rig.velocity = new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
        else
            rig.velocity = new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
    }

    private void switchTimer()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            if (directionSwitch) directionSwitch = false;
            else directionSwitch = true;
            changeTimer = maxTimer;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "friendlyBullet")
        {
            Destroy(col.gameObject);
            Instantiate(particleEffect, transform.position, transform.rotation);
            hitPoints--;
            if(hitPoints<=0)
                Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerCharacter>().healthPoint--;
            Instantiate(particleEffect, transform.position, transform.rotation);
            hitPoints--;
            if(hitPoints <=0)
                Destroy(gameObject);
        }
    }
}