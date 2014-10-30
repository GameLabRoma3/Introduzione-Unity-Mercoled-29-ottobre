using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ShipLocomotion : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxVelocityChange = 10.0f;
    public float rotationSpeed = 3.0f;
    public Transform explosion;
    bool alive = true;
    void FixedUpdate()
    {
        if (alive)
        {
            Vector3 tergetvelocity = (transform.forward * speed * Input.GetAxis("Vertical")) - rigidbody.velocity;

            tergetvelocity.x = Mathf.Clamp(tergetvelocity.x, -maxVelocityChange, maxVelocityChange);
            tergetvelocity.z = Mathf.Clamp(tergetvelocity.z, -maxVelocityChange, maxVelocityChange);
            rigidbody.AddForce(tergetvelocity, ForceMode.VelocityChange);
            transform.Rotate(0, rotationSpeed * Input.GetAxis("Horizontal"), 0);
            rigidbody.MoveRotation(Quaternion.Euler(0, transform.rotation.eulerAngles.y, -25 * Input.GetAxis("Horizontal")));
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        }
    }
    void OnCollisionEnter(Collision col)
    {
        rigidbody.useGravity = true;
        rigidbody.constraints = RigidbodyConstraints.None;
        explosion.gameObject.SetActive(true);
        alive = false;
    }
}
