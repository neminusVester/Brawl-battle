using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private void Awake()
    {
        // singltone
        if(Instance == null)
        {
            Instance = this;
        }

        //death, idle, walk
    }
}
