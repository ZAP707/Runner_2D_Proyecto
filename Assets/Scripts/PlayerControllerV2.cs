using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed = 10;
    public float jumpForce = 5;
    public bool isOnGround = true;
    
    
    Rigidbody2D rb;
    public int heal = 3;

    [SerializeField] private Vector2 _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
        
        // Limite de jugador en patalla
        if (transform.position.x > 2.284f) // Borde Derecha
        {
            transform.position = new Vector3(2.284f, transform.position.y, 0);
        }
        else if (transform.position.x < -1.038f) // Borde Izquierda
        {
            transform.position = new Vector3(-1.038f, transform.position.y, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isOnGround = true; 
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(speed * horizontalInput, _rb.velocity.y);
    }

    bool isGround()
    {
        return Physics2D.OverlapCircle(_groundCheck, 0.3f,_groundLayer);
    }
/*
    void Flip()
    {
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            
        }
    }
*/
}

