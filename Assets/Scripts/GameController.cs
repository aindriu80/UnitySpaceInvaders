using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public MapLimits Limits;
    private float maxSpawnTimer;
    public float spawnTimer;

    // Use this for initialization
    private void Start()
    {
        SpawnEnemy();
        spawnTimer = maxSpawnTimer;
    }

    // Update is called once per frame
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = maxSpawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        var randomNumber = Random.Range(0, 2);
        switch (randomNumber)
        {
            case 0:
            {
                Instantiate(enemy1,
                    new Vector3(Random.Range(Limits.minimumX, Limits.maximumX),
                        Random.Range(Limits.minimumY, Limits.maximumY), 0), enemy1.transform.rotation);
            }
                break;

            case 1:
            {
                Instantiate(enemy2,
                    new Vector3(Random.Range(Limits.minimumX, Limits.maximumX),
                        Random.Range(Limits.minimumY, Limits.maximumY), 0), enemy1.transform.rotation);
            }
                break;

            case 2:
            {
                Instantiate(enemy3,
                    new Vector3(Random.Range(Limits.minimumX, Limits.maximumX),
                        Random.Range(Limits.minimumY, Limits.maximumY), 0), enemy1.transform.rotation);
            }
                break;

            default:
            {
                Instantiate(enemy1,
                    new Vector3(Random.Range(Limits.minimumX, Limits.maximumX),
                        Random.Range(Limits.minimumY, Limits.maximumY), 0), enemy1.transform.rotation);
                break;
            }
        }
    }
}