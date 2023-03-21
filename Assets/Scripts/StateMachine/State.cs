using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    //Спрацьовує один раз, коли ми входимо в якийсь стан
    public virtual void Enter()
    {
    }

    //Спрацьовує коли ми виходимо з якогось стану. Відразу після цього спрацьовує Enter в інший стан
    public virtual void Exit()
    {
    }

    //Використовується всередині якогось стану
    public virtual void Update()
    {
    }
}
