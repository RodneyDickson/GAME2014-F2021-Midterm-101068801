using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ENEMYCONTROLLER.CS
 * RODNEY KRISTIAN DICKSON
 * 101068801
 * DATE LAST MODIFIED: OCTOBER 21, 2021
 * PROGRAM DESCRIPTION: GAME 2014 - Mobile Game Development I, Midterm I, Space Shooter Demo
 * REVISION HISTORY: OCTOBER 21, 2021 - CHANGED ENEMY ROTATION FROM HORIZONTAL TO VERTICAL TO MATCH REQUIREMENTS, ENEMIES BOUNCE ON WALL HIT
 */

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Movement")]
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);      // enemy moves along y axis only by direction times vertical speed times delta time
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)       // stops enemy from leaving bounds
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
