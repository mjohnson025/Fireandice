using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public GameObject losePanel;
    public Text healthDisplay;
    public float speed;
    private float input;
    [SerializeField]
    private float health = 0f;

    public float startDashTime;
    [SerializeField]
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    Rigidbody2D rb;
    Animator anim; 
    AudioSource source;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        healthDisplay.text = health.ToString();
        
    }

    private void Update()
    {
        if (input != 0) {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        if (input > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //Add dash ability
        if(Input.GetKeyDown(KeyCode.Space) && isDashing == false){
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
            print("Space pressed");
        }
        if(dashTime <= 0 && isDashing == true) {
            isDashing = false;
            speed -= extraSpeed;
        }
        else{
            dashTime -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        print("Velocity: " + rb.velocity);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        source.Play();
        healthDisplay.text = health.ToString();
        if (health <= 0){
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
