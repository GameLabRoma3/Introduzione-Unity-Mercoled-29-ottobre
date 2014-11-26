using UnityEngine;
using System.Collections;

public class MissileDirectionScript : MonoBehaviour
{
    public GameObject Explosion;
    public float RotationSpeed = 6.5f;
    public Transform Target = null;
    bool Alive = true;
    float speed;

    public void ActiveMissile(float speed, Vector3 direction)
    {
        rigidbody.AddForce(direction, ForceMode.Impulse);
        this.speed = speed;
        Invoke("Explode", 13);
    }
    void Update()
    {
        if (Alive)
        {
            if (Target != null)
            {
                //Debug.Log(rigidbody.velocity);
                rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position),
                   RotationSpeed * Time.deltaTime));
                Vector3 tergetvelocity = (transform.forward * speed) - rigidbody.velocity;
                rigidbody.AddForce(tergetvelocity, ForceMode.VelocityChange);
            }
        }
    }
    void Explode()
    {
        if (Alive)
        {
            Explosion.SetActive(true);
            Destroy(rigidbody);
            Destroy(gameObject, 2.5f);
            Alive = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().Points += Random.Range(1, 5);
        }
        Explode();
    }

    void OnTriggerEnter(Collider col)
    {
        if (Target == null)
            if (col.gameObject.tag.Equals("Enemy"))
                Target = col.gameObject.transform;
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == Target)
            Target = null;
    }
}
