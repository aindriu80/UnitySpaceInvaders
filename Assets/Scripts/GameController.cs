using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MapLimits Limits;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;


	// Use this for initialization
	void Start ()
	{
	    Instantiate(enemy1,
	        new Vector3(Random.Range(Limits.minimumX, Limits.maximumX), 
            Random.Range(Limits.minimumY, Limits.maximumY), 0), enemy1.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
