using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float xSpeed = 1.0f;
    protected float ySpeed = 0.75f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset Movedelta - bo x i y i tak s� w inpucie i s� zawsze po framie 0, -1 albo 1. Reset co frame
        moveDelta =  new Vector3(input.x * xSpeed,input.y * ySpeed, 0);

        // Swap sprite direction, wether yo're going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //Je�li ma by� push, to push vector
        moveDelta += pushDirection;

        //Redukcja push force dla kazdego frame'a na podstawie pushRecoverySpeed (fighter)
        // interpoluje mi�dzy "a" i "b"(tu vector3.zero jako nic w sumie) o warto�� "t"
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // Make sure we can move by casting a box. If the box returns 0, we're free to move.
        // 0 to rotacja - w 2d - zerowa
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make this thing move!
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make this thing move!
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
