using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ShipLocomotion : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxVelocityChange = 10.0f;
    public float rotationSpeed = 3.0f;
    public Transform explosion;
    public AudioSource ExplosionSound;
    bool alive = true;
    void FixedUpdate()
    {
        if (alive)
        {
            Vector3 tergetvelocity = (transform.forward * speed * Input.GetAxis("Jump")) - rigidbody.velocity;
            Vector3 tergetRotation = new Vector3(-(rotationSpeed / 2) * Input.GetAxis("Vertical"), 0, -rotationSpeed * Input.GetAxis("Horizontal"));

            tergetvelocity.x = Mathf.Clamp(tergetvelocity.x, -maxVelocityChange, maxVelocityChange);
            tergetvelocity.z = Mathf.Clamp(tergetvelocity.z, -maxVelocityChange, maxVelocityChange);

            transform.Rotate(tergetRotation);
            rigidbody.AddForce(tergetvelocity, ForceMode.Force);

            //rigidbody.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -25 * Input.GetAxis("Horizontal")));
        }
    }
    void OnCollisionEnter(Collision col)
    {
        rigidbody.useGravity = true;
        rigidbody.constraints = RigidbodyConstraints.None;
        explosion.gameObject.SetActive(true);
        alive = false;
        ExplosionSound.Play();
    }
}
