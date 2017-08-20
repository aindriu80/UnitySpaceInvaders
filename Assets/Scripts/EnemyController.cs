using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public bool canShoot;
    public float changeTimer;
    public bool directionSwitch;
    public int hitPoints;
    public int scoreReward;
    public MapLimits Limits;
    private float maxShootTimer;
    private float maxTimer;
    public GameObject particleEffect;
    private Rigidbody rig;
    public Transform shootingPosition;
    public float shootPower;
    private float shootTimer;
    public float speed;


    // Use this for initialization
    private void Start()
    {
        shootTimer = Random.Range(1f, 5f);
        maxShootTimer = shootTimer;
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
        shootTimer -= Time.deltaTime;
        if (canShoot)
            if (shootTimer <= 0)
            {
                var newBullet = Instantiate(bullet, shootingPosition.transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * -shootPower;
                shootTimer = maxShootTimer;
            }
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
        if (col.gameObject.tag == "enemyBullet")
            return;
        if (col.gameObject.tag == "friendlyBullet")
        {
            Destroy(col.gameObject);
            Instantiate(particleEffect, transform.position, transform.rotation);
            hitPoints--;
            if (hitPoints <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>().score += scoreReward;
                Destroy(gameObject);
            }
        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerCharacter>().healthPoint--;
            Instantiate(particleEffect, transform.position, transform.rotation);
            hitPoints--;
            if (hitPoints <= 0)
            {
                col.gameObject.GetComponent<PlayerCharacter>().score += scoreReward;
                Destroy(gameObject);
            }
        }
    }

    private bool switchDir(bool dir)
    {
        if (dir) directionSwitch = false;
        else directionSwitch = true;
        return directionSwitch;
    }

    
}