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
    public VisualEffect burningVFX;
    public VisualEffect electricityVFX;
    public GameObject BurningFX;
    public GameObject ElectricityFX;
    public Ability abilityAffecting;
    public float Health {get { return health;}}

    private bool isDead;
    private IEnemyState currentState;
    private float health = 100;
    private LevelManager levelManager;
    
    void Start()
    {
        electricityVFX.Stop();
        burningVFX.Stop();
        levelManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isDead = false;
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
        if (health <= 0 && !isDead)
        {
            levelManager.enemiesAlive -= 1;
            AddStaminaToPlayer(2);
            isDead = true;
        }
    }
    
    public void AddStaminaToPlayer(int stamina)
    {
        if (player.Stamina + stamina <= player.MaxStamina) player.Stamina += stamina;
        else player.Stamina = player.MaxStamina;
        player.staminaBar.SetStamina(player.Stamina);
        
    }
    
}
