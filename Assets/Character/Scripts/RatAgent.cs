using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAgent : Agent
{
    [SerializeField] public Perception perception;

    public StateMachine stateMachine = new StateMachine();

    public BoolRef enemySeen;
    public FloatRef enemyDistance;
    public FloatRef health;
    public FloatRef timer;
    public BoolRef atDestination;

    public GameObject enemy { get; set; }

    void Start()
    {
        // adding states
        stateMachine.AddState(new IdleState(this, typeof(IdleState).Name));
        stateMachine.AddState(new DeathState(this, typeof(DeathState).Name));
        stateMachine.AddState(new EvadeState(this, typeof(EvadeState).Name));
        stateMachine.AddState(new RoamState(this, typeof(RoamState).Name));

        // transitions
        stateMachine.AddTransition(typeof(IdleState).Name, new Transition(new Condition[] { new BoolCondition(enemySeen, true) }), typeof(EvadeState).Name);
        stateMachine.AddTransition(typeof(IdleState).Name, new Transition(new Condition[] { new FloatCondition(timer, Condition.Predicate.LESS, 0) }), typeof(RoamState).Name);
        stateMachine.AddTransition(typeof(IdleState).Name, new Transition(new Condition[] { new FloatCondition(health, Condition.Predicate.LESS_EQUAL, 0) }), typeof(DeathState).Name);

        stateMachine.AddTransition(typeof(EvadeState).Name, new Transition(new Condition[] { new BoolCondition(enemySeen, false) }), typeof(IdleState).Name);
        stateMachine.AddTransition(typeof(EvadeState).Name, new Transition(new Condition[] { new FloatCondition(health, Condition.Predicate.LESS_EQUAL, 0) }), typeof(DeathState).Name);

        stateMachine.AddTransition(typeof(RoamState).Name, new Transition(new Condition[] { new BoolCondition(atDestination, true) }), typeof(IdleState).Name);

        stateMachine.SetState(stateMachine.StateFromName(typeof(IdleState).Name));
    }

    // Update is called once per frame
    void Update()
    {
        // enemy
        var enemies = perception.GetGameObjects();
        enemySeen.value = (enemies.Length != 0);
        enemy = (enemies.Length != 0) ? enemies[0] : null;
        enemyDistance.value = (enemy != null) ? (Vector3.Distance(transform.position, enemy.transform.position)) : float.MaxValue;

        timer.value -= Time.deltaTime;

        stateMachine.Update();

        animator.SetFloat("speed", movement.velocity.magnitude);
    }
}
