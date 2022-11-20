using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Initialising variables
    public float speed = 8f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float maxSpeed;
    [SerializeField] float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    public int jumpForce = 2;
    [SerializeField] LayerMask groundMask;

    public GameObject Projectile;
    public GameObject Spawner;
    public bool canShoot = false;
    public bool alive = true;
    UI ui;
    public AudioSource[] sounds;
    public AudioSource noise1;
    public AudioSource noise2;


    private void Start()
    {
        ui = GameObject.FindObjectOfType<UI>();
        sounds = GetComponents<AudioSource>();
        noise1 = sounds[0];
        noise2 = sounds[1];
    }


    void Update()
    {
        //Receives input and converts it to horizontal movement 
        horizontalInput = Input.GetAxis("Horizontal");
        
        //Calls Jump method when up Arrow is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
          Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
          
                Shoot();
        }

        //Restarts the scene and sets score to 0 when R is pressed    
        if (Input.GetKeyDown(KeyCode.R))
        {
            UI.scoreCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        //Calls Die method if the player falls off the platform
        if (transform.position.y < -4)
        {
            Die();
        }

    }

    private void FixedUpdate()
    {
        //If speed isnt at max speed, speed is constantly slowly increased
        if (speed < maxSpeed)
        {
            speed += 0.1f * Time.deltaTime;
        }

        //Calculating forward and horizontal movement and then applying those to the player
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
        //Disables player movement on death
        if (!alive) return;


        ui.JumpUI(this);
        ui.ShootUI(this);


    }

    public void Die()
    {
        //Sets alive boolean to false and loads the death screen
        alive = false;
        SceneManager.LoadScene( sceneName: "Death Screen");
    }

    //Allows the player to jump
    public void Jump()
    {
            //Gets if the player is currently grounded
            float height = GetComponent<Collider>().bounds.size.y;
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        if (isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        else
            return;
    }

    //Allows the player to shoot projectiles
    public void Shoot()
    {
        if (canShoot == true)
        {
            Instantiate(Projectile, Spawner.transform);
            canShoot = false;
        }
        else
            return;
    }

  




}
