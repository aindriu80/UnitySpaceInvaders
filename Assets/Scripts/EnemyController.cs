using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float changeTimer;
    public GameObject particleEffect;
    public bool directionSwitch;
    private float maxTimer;
    public float speed;
    public int hitPoints;
    public MapLimits Limits;

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
        if (transform.position.x == Limits.maximumX) switchDir(directionSwitch);
        if (transform.position.x == Limits.minimumX) switchDir(directionSwitch);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Limits.minimumX, Limits.maximumX),
            Mathf.Clamp(transform.position.y, Limits.minimumY, Limits.maximumY), 0.0f);
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
            switchDir(directionSwitch);
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

    private bool switchDir(bool dir)
    {
        if (dir) directionSwitch = false;
        else directionSwitch = true;
        return directionSwitch;
    }
}