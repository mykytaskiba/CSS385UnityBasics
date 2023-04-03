using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMode : MovementMode
{
    Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float acceleration;

    Vector2 lastInput;
    Vector2 currentInput;



    public override void Move(Vector2 direction)
    {
        currentInput = direction.normalized;
    }

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        lastInput = Vector2.zero;
        currentInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        lastInput = Vector2.Lerp(lastInput, currentInput, acceleration * Time.deltaTime);
        rb.velocity = lastInput * speed;
    }
}
