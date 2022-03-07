using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public StateAgent owner { get; private set; }
    public RatAgent ownerRat { get; private set; }
    public string name { get; private set; }

    public State(StateAgent owner, string name)
    {
        this.owner = owner;
        this.name = name; 
    }

    public State(RatAgent owner, string name)
    {
        this.ownerRat = owner;
        this.name = name;
    }

    public abstract void OnEnter();  
    public abstract void OnExit();  
    public abstract void OnUpdate();  
}
