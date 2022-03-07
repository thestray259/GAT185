using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : CharPickup, IDestructable
{
    [SerializeField] int points;

    public void Destroyed()
    {
        Game.Instance.Score += points; 
    }
}
