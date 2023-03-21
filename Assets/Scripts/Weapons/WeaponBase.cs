using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    
    
    private Vector3 _bulletTargetPosition;
    public float bulletForce = 6f;
    public bool targetNotFound = false;

    protected void InstantiateBullet(GameObject bulletPrefub, Transform bulletStartPosition, Quaternion bulletRotation)
    {
        GameObject bullet = Instantiate(bulletPrefub, bulletStartPosition.position, bulletRotation);
        _bulletTargetPosition = bulletStartPosition.position + bulletStartPosition.forward * 10f;
        StartCoroutine(MoveToTarget(bulletForce, _bulletTargetPosition, bullet));
    }

    protected void InstantiateBullet(GameObject bulletPrefub, Transform bulletStartPosition, Transform bulletTargetPosition, Quaternion bulletRotation)
    {
        GameObject bullet = Instantiate(bulletPrefub, bulletStartPosition.position, bulletRotation);
        StartCoroutine(MoveToTarget(bulletForce, bulletTargetPosition.position,bullet));
    }
   
    private IEnumerator MoveToTarget(float speed, Vector3 bulletTargetPosition, GameObject bullet)
    {
            while(bullet != null && bullet.transform.position != bulletTargetPosition)
            {
                    bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, bulletTargetPosition, speed * Time.deltaTime);
                    yield return null;
            }
    }

    public abstract void Shoot();
}
