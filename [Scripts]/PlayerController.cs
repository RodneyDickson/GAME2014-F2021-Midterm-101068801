using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

/*
 * PLAYERCONTROLLER.CS
 * RODNEY KRISTIAN DICKSON
 * 101068801
 * DATE LAST MODIFIED: OCTOBER 21, 2021
 * PROGRAM DESCRIPTION: GAME 2014 - Mobile Game Development I, Midterm I, Space Shooter Demo
 * REVISION HISTORY: OCTOBER 21, 2021 - MAIN UPDATE, ROTATED SCREEN / SPRITES, LOCKED PLAYER ROTATION / POSITION
 */

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float verticalBoundary;
    public float horizontalBoundary;

    [Header("Player Speed")]
    public float verticalSpeed;
    public float maxSpeed;
    public float verticalTValue;
    public float horizontalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;    // sets up our rigid body for movement and collision
    private Vector3 m_touchesEnded;     // gets when mouse touch or input ends

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3(); // once touch ends, move to vector3
        m_rigidBody = GetComponent<Rigidbody2D>();  // gets ridgidbody for collision
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())     // if frames divisible by 60 and has bullets, fire bullet
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)        // touch moves you along y axis
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f)      // vertical movement instead of horizontal
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_touchesEnded.y, verticalTValue), transform.position.x);     // lerps around x and y axis according to mouse location. moves in a weird S shape
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * verticalSpeed, 0.0f);      // velocity is equal to direction of movement times vertical speed
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.y >= verticalBoundary)       // sets position to boundary so player cant go out of bounds
        {
            transform.position = new Vector2(transform.position.x, verticalBoundary);
        }

        // check left bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector2(transform.position.x, -verticalBoundary);
        }

        // check right bounds
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector2(horizontalBoundary, transform.position.y);
        }

        // check left bounds
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector2(-horizontalBoundary, transform.position.y);
        }

    }
}
