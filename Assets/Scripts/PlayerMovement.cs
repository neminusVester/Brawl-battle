using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private Rigidbody _rb;
   [SerializeField] private FixedJoystick _moveJoystick;
   [SerializeField] private float _speed;
   public PlayerWeapon playerWeapon;
   


//через state machine переписать
   private void Update()
   {
          MoveJoystickCheck();
   }

   private void MoveJoystickCheck()
   {
    if (Mathf.Abs(_moveJoystick.Horizontal) >= 0.5f ||  Mathf.Abs(_moveJoystick.Vertical) >= 0.5f)
    {
        _rb.velocity = new Vector3(_moveJoystick.Horizontal * _speed, 0.0f, _moveJoystick.Vertical * _speed);
        // PlayerRotation(_rb.velocity);
        transform.rotation = Quaternion.LookRotation(_rb.velocity);
    }
    else _rb.velocity = new Vector3(0, 0, 0);
   }

   public void RotationToFire(Quaternion startRot, Vector3 fireDirection, float t)
   {
        // transform.rotation = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(startRot, Quaternion.LookRotation(fireDirection), t);
   }
}
