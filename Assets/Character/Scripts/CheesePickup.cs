using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : CharPickup, IDestructable
{
    [SerializeField] int points;
    GameData gameData;

    public void Destroyed()
    {
        //Game.Instance.Score += points; 

        //gameData.intData["Score"] += points;

        Game.Instance.OnCheeseFound(); 
    }
}
