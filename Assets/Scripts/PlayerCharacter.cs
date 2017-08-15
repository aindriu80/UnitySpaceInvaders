using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public float movementSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * -movementSpeed * Time.deltaTime);
        }
    }
}
