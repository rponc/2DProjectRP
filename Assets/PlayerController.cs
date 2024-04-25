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
    float jumpForce = 400f;

    bool onGround = false;
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(x: horizontalDir * speed, rb.velocity.y);

    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        float inputX = inputDir.x;

        horizontalDir = inputX;
    }

    void OnJump()
    {
        Debug.Log("Jumping!");

        if (!onGround)
        {
            return;
        }
        Vector3 jumpVector = new Vector3(0, jumpForce, 0);
        rb.AddForce(jumpVector);

    }
}