using UnityEngine;
using System.Collections;

public class AteroideScript : MonoBehaviour
{
    private float speed;
    public GameObject Explosion;
    bool destroyed = false;
    void Start()
    {
        speed = Random.Range(15, 70);
        transform.localScale *= Random.Range(0.6f, 4f);
        Vector3 direction = (new Vector3(Random.Range(30, 150), -150, Random.Range(30, 150)));
        direction.Normalize();
        //Debug.Log("speed: " + speed + " dior: " + direction);
        rigidbody.AddForce(direction * speed, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision col)
    {
        if (!destroyed)
        {
            destroyed = true;
            rigidbody.useGravity = true;
            rigidbody.drag = 0;
            rigidbody.angularDrag = 0;
            if (col.gameObject.tag.Equals("Missile"))
                Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject, Random.Range(0, 2.5f));
        }
    }
}
