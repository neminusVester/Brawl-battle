using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 10f;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(TestMove());
        }
    }
    public IEnumerator TestMove()
    {
        while(transform.position != targetPosition.position)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position,speed*Time.deltaTime);
            yield return null;
        }
        
    }
}
