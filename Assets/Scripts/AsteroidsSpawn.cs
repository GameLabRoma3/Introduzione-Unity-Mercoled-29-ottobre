using UnityEngine;
using System.Collections;

public class AsteroidsSpawn : MonoBehaviour
{
    public GameObject[] Asteroids;
    public Transform AreaRange;
    private float height;
    void Start()
    {
        height = transform.position.y;
        InvokeRepeating("Spawn", 1, 2.5f);
    }

    void Spawn()
    {
        int tot = Random.Range(1, 4);
        for (int i = 0; i < tot; i++)
        {
            Instantiate(Asteroids[Random.Range(0, 2)], //quale asteroide 
                new Vector3(Random.Range(-AreaRange.localScale.x, AreaRange.localScale.x), height, Random.Range(-AreaRange.localScale.z, AreaRange.localScale.z)), //la posizione
                Quaternion.identity);
        }
    }
}
