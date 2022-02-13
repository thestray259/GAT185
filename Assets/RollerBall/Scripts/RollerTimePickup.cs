using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerTimePickup : RollerPickup, IDestructable
{
    [SerializeField] float extraTime;

    public void Destroyed()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        go.GetComponent<RollerGameManager>().gameTime += extraTime;
    }
}
