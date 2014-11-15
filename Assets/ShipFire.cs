using UnityEngine;
using System.Collections;

public class ShipFire : MonoBehaviour
{
    public GameObject Missile;
    public Transform LeftMissilePosition, RightMissilePosition;
    public float FireSpeed = 14f;
    [Range(0.5f, 10)]
    public float FireRate = 1f;

    private bool canFire = true;
    private bool leftSpawn = true;

    private ShipLocomotion shipLocomotion;
    void Start()
    {
        shipLocomotion = gameObject.GetComponent<ShipLocomotion>();
    }
    void Update()
    {
        if (shipLocomotion.Alive)
        {
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
