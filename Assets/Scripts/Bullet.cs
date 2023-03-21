using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    
    [SerializeField, Range(100,500)] private int _damage = 150;
    private Vector3 _currentPos;
    private Vector3 _prevPos;

    
    /* public void Init(WeaponBase weaponBase)
    {
        this.weaponBase1 = weaponBase;
    } */
    private void Update()
    {
       _prevPos = _currentPos;
       _currentPos = transform.position;
       if(_currentPos == _prevPos)
       Destroy(gameObject);
    }
    
    private void OnCollisionEnter (Collision collision)
    {
        //якщо на об'єкті, з яким відбулась колізія є написаний інтерфейс
        if(collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
        Destroy(this.gameObject);
    }

}
