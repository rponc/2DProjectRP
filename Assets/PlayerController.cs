using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    float horizontalDir;

    private Rigidbody2D rb;

    [SerializeField]
    public float jump;



    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(x: horizontalDir * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        float inputX = inputDir.x;

        horizontalDir = inputX;
    }

    void OnJump(InputValue value)
    {
        Debug.Log("Jumping!");

        Vector2 inputDir = value.Get<Vector2>();
       
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump)* jumpSpeed);
        }
        

        if (!onGround)
        {
            return;
        }
    
    }


    public float jumpSpeed = 100.0f;
    private bool onGround = false;
    private float movementSpeed;

    void OnCollisionStay()
    {
        onGround = true;
    }
}

