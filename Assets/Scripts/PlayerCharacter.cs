using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public GameObject bullet;

    public MapLimits Limits;
    public float movementSpeed;

    public Transform pos1;

    public Transform posL;

    public Transform posR;
    private int power;
    public float shotPower;

    // Use this for initialization
    private void Start()
    {
        power = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        Shooting();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Limits.minimumX, Limits.maximumX),
            Mathf.Clamp(transform.position.y, Limits.minimumY, Limits.maximumY), 0.0f);
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.right * -movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.up * -movementSpeed * Time.deltaTime);
    }

    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            switch (power)
            {
                case 1:
                    {
                        var newBullet = Instantiate(bullet, pos1.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
                    }
                    break;

                case 2:
                    {
                        var bullet1 = Instantiate(bullet, posL.position, transform.rotation);
                        bullet1.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
                        var bullet2 = Instantiate(bullet, posR.position, transform.rotation);
                        bullet2.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
                    }
                    break;

                case 3:
                    {
                        var bullet1 = Instantiate(bullet, posL.position, transform.rotation);
                        bullet1.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
                        var bullet2 = Instantiate(bullet, posR.position, transform.rotation);
                        bullet2.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
                        var bullet3 = Instantiate(bullet, pos1.position, transform.rotation);
                        bullet3.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
                    }
                    break;

                default:
                    {
                        var newBullet = Instantiate(bullet, pos1.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
                    }
                    break;
            }
    }
}