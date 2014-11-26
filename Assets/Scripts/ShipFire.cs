using UnityEngine;
using System.Collections;

public class ShipFire : MonoBehaviour
{
    public GameObject Missile;
    public Transform LeftMissilePosition, RightMissilePosition;
    public float FireSpeed = 85f;
    [Range(0.1f, 10)]
    public float FireRate = 0.5f;

    private bool canFire = true;
    private bool leftSpawn = true;

    private ShipLocomotion shipLocomotion;
    Camera current;
    void Start()
    {
        shipLocomotion = gameObject.GetComponent<ShipLocomotion>();
        current = Camera.main;
    }
    void Update()
    {
        if (shipLocomotion.Alive)
        {
            if (Input.GetAxis("MouseRight") != 0 || Input.GetAxis("Joystick button 3") != 0)
                current.fieldOfView = 30;
            else
                current.fieldOfView = 60;

            if (canFire && Input.GetAxis("Fire1") > 0)
            {
                canFire = false;
                Invoke("EnableFire", FireRate);
                MissileDirectionScript tmpMissile = (Instantiate(Missile,
                                        leftSpawn ? LeftMissilePosition.position : RightMissilePosition.position,
                                        transform.rotation) as GameObject).GetComponent<MissileDirectionScript>();
                leftSpawn = !leftSpawn;
                tmpMissile.ActiveMissile(FireSpeed, rigidbody.velocity + transform.forward * FireSpeed);

            }
        }
    }
    void EnableFire()
    { canFire = true; }
}