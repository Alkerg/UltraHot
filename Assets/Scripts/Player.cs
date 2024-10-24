using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float groundDistance = 0.3f;
    public TimeManager timeManager;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public AudioMixer audioMixer;
    public GameObject weaponContainer;
    public GameObject container;
    [SerializeField] public Transform groundCheck;

    private CharacterController characterController;
    private const float gravity = -12f;
    private Vector3 velocity;
    private bool isGrounded;
    private float slowDownLenght = 20f;
    

    public bool isDropping = false;
    public GameObject bulletPrefab;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) velocity.y = -2f;

        float X = Input.GetAxisRaw("Horizontal");   //Keys A,D
        float Z = Input.GetAxisRaw("Vertical");     //Keys W,S

        /*if(X != 0 || Z != 0)    //If player moves, then the game returns to normal speed
        {
            if (isDropping)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale += (1 / slowDownLenght) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
                audioMixer.SetFloat("Pitch", 1f);
            }
        }
        else        //If player doesn't move, then the game runs in bullet time
        {
            if (isDropping)
            {
                Time.timeScale = 1;
            }
            else
            {
                timeManager.ActivateBulletTime();
                audioMixer.SetFloat("Pitch", 0.8f);
            }

        }*/

        if (Input.GetKeyDown(KeyCode.T))
        {
            if(!timeManager.isBulletTime)
            {
                timeManager.ActivateBulletTime();
                Debug.Log("activado");
            }
            else
            {
                timeManager.DeactivateBulletTime();
                Debug.Log("desactivado");
            }

        }


        Time.timeScale += (1 / slowDownLenght) * Time.deltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
        

        //Debug.Log(Time.timeScale);

        //Shoot bullets
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = BulletPool.Instance.getBullet();
            bullet.transform.position = Camera.main.transform.position;
            bullet.transform.rotation = Camera.main.transform.rotation;
            //GameObject bullet = Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
        }

        //Move the payer on the X and Z axes
        Vector3 move = transform.right * X + transform.forward * Z;
        characterController.Move(move * speed * Time.unscaledDeltaTime); //Change Time.deltaTime to Time.unscaledDeltaTime for max payne bullet time mechanichs

        //Moves the player on the Y axis
        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        velocity.y += gravity * Time.unscaledDeltaTime;
        characterController.Move(velocity * Time.unscaledDeltaTime);


        if (Input.GetKey(KeyCode.F))
        {
            //weaponContainer.GetComponentInChildren<Weapon>().Pull();
            //container.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
            Weapon weapon = weaponContainer.GetComponentInChildren<Weapon>();
            if (weapon)
            {
                weapon.Drop();
                StartCoroutine(Wait(.04f));
            }

        }


    }

    IEnumerator Wait(float time)
    {
        //Return to normal speed temporarily
        isDropping = true;
        yield return new WaitForSeconds(time);
        isDropping = false;
    }

}
