using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    public Player player;
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public GameObject VFXContainer;
    public GameObject BurningFX;
    public GameObject ElectricityFX;
    public Ability abilityAffecting;
    
    private IEnemyState currentState;
    private float health = 100;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        ChangeState(new ChasingPlayerState());
    }

    void Update()
    {
        currentState.UpdateState(this);

        if (abilityAffecting != null)
        {
            if (!abilityAffecting.isActive) abilityAffecting = null;
        }
    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        currentState.EnterState(this);
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
