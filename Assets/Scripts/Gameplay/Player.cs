using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public float groundDistance = 0.3f;
    public TimeManager timeManager;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public AudioMixer audioMixer;
    public GameObject container;
    [SerializeField] public Transform groundCheck;
    public bool isDropping = false;
    public GameObject bulletPrefab;
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public int Health { get { return health; } set{ health = value; } }
    public int Stamina { get { return stamina; } set{ stamina = value; } }
    public int MaxHealth { get { return maxHealth; } }
    public int MaxStamina { get { return maxStamina; } }
    
    private CharacterController characterController;
    private const float gravity = -12f;
    private Vector3 velocity;
    private bool isGrounded;
    private float slowDownLenght = 20f; //Set to 1 for SuperHot bullet time system
    private int health;
    private int maxHealth = 100;
    private int stamina;
    private int maxStamina = 100;



    private void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxStamina);
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (PauseManager.isGamePaused || LevelManager.isGameOver || LevelManager.isGameFinished) return;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) velocity.y = -2f;

        float X = Input.GetAxisRaw("Horizontal");   //Keys A,D
        float Z = Input.GetAxisRaw("Vertical");     //Keys W,S
        
        //Move the payer on the X and Z axes
        Vector3 move = transform.right * X + transform.forward * Z;
        characterController.Move(move * (speed * Time.unscaledDeltaTime)); //Change Time.deltaTime to Time.unscaledDeltaTime for max payne bullet time mechanichs

        //Moves the player on the Y axis
        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        velocity.y += gravity * Time.unscaledDeltaTime;
        characterController.Move(velocity * Time.unscaledDeltaTime);

        
    }

    public void TakeDamage(int damage)
    {
        if(health - damage <= 0)
        {
            health = 0;
            Debug.Log("Game over");
        }
        else health -= damage;
            
        healthBar.SetHealth(health);
    }
    
    IEnumerator Wait(float time)
    {
        //Return to normal speed temporarily
        isDropping = true;
        yield return new WaitForSeconds(time);
        isDropping = false;
    }

    IEnumerator Wait(float time, float prevTimeScale)
    {
        //Return to normal speed temporarily
        Time.timeScale = 1;
        yield return new WaitForSeconds(time);
        Time.timeScale = prevTimeScale;
    }

}
