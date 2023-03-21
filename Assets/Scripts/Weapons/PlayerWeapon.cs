using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : WeaponBase
{
    private Vector3 targetPosition;
    [SerializeField] private GameObject _bulletPrefub;
    [SerializeField] public Transform _bulletStartPosition;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private LineRenderer _lr;
    [SerializeField] private Transform _lrStartPoint;
    [SerializeField] private FixedJoystick _fireJoystick;
    private Quaternion _bulletRotation;
    Rigidbody rb;
    [SerializeField] PlayerMovement playerMovement;
    public float trailDistance = 10f;

    private RaycastHit hit;
    public Vector3 _fireDirection;
    bool isShoot;
    private Coroutine _shootCoroutine;
    [SerializeField] private float rotationSpeed = 0.025f;



    void Update()
    {
        FireJoystickCheck(); 
    }
   
    private void FireJoystickCheck()
    {
        if (Mathf.Abs(_fireJoystick.Horizontal) >= 0.5f ||  Mathf.Abs(_fireJoystick.Vertical) >= 0.5f)
        {
            if(_lr.gameObject.activeInHierarchy == false)
            {
                _lr.gameObject.SetActive(true);
            }
            _fireDirection = new Vector3(_fireJoystick.Horizontal, 0.0f, _fireJoystick.Vertical);
            _bulletRotation = Quaternion.LookRotation(_fireDirection);
            Aiming();
            if(isShoot == false)
            {
                isShoot = true;
            }
        }
        else CheckShotCondition();
    }

    private IEnumerator RotateAndShoot()
    {
        var startRot = playerMovement.transform.rotation;
        for(float t = 0; t < 1; t += Time.deltaTime/rotationSpeed)
        {
            // playerMovement.transform.rotation = Quaternion.Lerp(startRot, Quaternion.LookRotation(_fireDirection), t);
            playerMovement.RotationToFire(startRot, _fireDirection, t);
            yield return null;
        }
        Shoot();
        _shootCoroutine = null;
    }
    
    private void CheckShotCondition()
    {
        if(isShoot && Input.GetMouseButtonUp(0))
        {
            if(_shootCoroutine == null)
            _shootCoroutine = StartCoroutine(RotateAndShoot());

            isShoot = false;
        }
        else if(Mathf.Abs(_fireJoystick.Horizontal) < 0.4f ||  Mathf.Abs(_fireJoystick.Vertical) < 0.4f)
        {
            _lr.gameObject.SetActive(false);
            
            isShoot = false;
        }
    }
    private void Aiming()
    {
        _lrStartPoint.rotation = Quaternion.LookRotation(_fireDirection);
        _lr.SetPosition(0, _lrStartPoint.position);
        if(Physics.Raycast(_lrStartPoint.position, _lrStartPoint.forward, out hit, trailDistance))
        {
            _lr.SetPosition(1, hit.point);
        }
        else
        {
            _lr.SetPosition(1, _lrStartPoint.position + _lrStartPoint.forward * trailDistance);
            
        }
    }
    public override void Shoot()
    {   
        
        InstantiateBullet(_bulletPrefub, _bulletStartPosition, _bulletRotation);
    }


}
