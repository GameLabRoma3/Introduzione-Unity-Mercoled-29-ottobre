using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class ShipLocomotion : MonoBehaviour
{
    public bool Alive = true;
    public bool EngineEnabled = false;
    [SerializeField]
    PCorJoystick ControlsType = PCorJoystick.PC;
    public float Speed = 16.0f;
    public float HorizontalrotationSpeed = 2.3f;
    public float VerticalrotationSpeed = 1.5f;
    public GameObject explosion;
    private bool canChangeEngine = true;


    void FixedUpdate()
    {
        if (Alive)
        {
            switch (ControlsType)
            {
                case PCorJoystick.PC: PCcontrollers();
                    break;
                case PCorJoystick.Joystick: JoypadControls();
                    break;
            }
        }
    }

    void Move(bool changeEngine, float SpeedIncrease)
    {
        audio.enabled = EngineEnabled;
        if (changeEngine)
        {
            EngineEnabled = !EngineEnabled;
            canChangeEngine = false;
            Invoke("enableEngineChange", 0.5f);
        }
        if (EngineEnabled)
        {
            Speed += SpeedIncrease;
            Vector3 tergetvelocity = (transform.forward * Speed) - rigidbody.velocity;
            Vector3 tergetRotation = new Vector3(VerticalrotationSpeed * Input.GetAxis("Vertical"), 0,
                -HorizontalrotationSpeed * Input.GetAxis("Horizontal"));

            transform.Rotate(tergetRotation);
            rigidbody.AddForce(tergetvelocity, ForceMode.Force);
        }
    }

    void PCcontrollers()
    {
        Move((canChangeEngine && Input.GetKeyDown(KeyCode.Return)), Input.GetAxis("Mouse ScrollWheel"));
    }

    void JoypadControls()
    {
        Move((canChangeEngine && Input.GetAxis("Joystick botton 2") != 0), Input.GetAxis("Joypad Throtlle"));
    }

    void enableEngineChange()
    {
        canChangeEngine = true;
    }

    void OnCollisionEnter(Collision col)
    {
        rigidbody.useGravity = true;
        explosion.gameObject.SetActive(true);
        EngineEnabled = false;
        Alive = false;
    }

    public enum PCorJoystick
    {
        PC,
        Joystick
    }

}
