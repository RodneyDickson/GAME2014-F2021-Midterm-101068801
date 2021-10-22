using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BACKGROUNDCONTROLLER.CS
 * RODNEY KRISTIAN DICKSON
 * 101068801
 * DATE LAST MODIFIED: OCTOBER 21, 2021
 * PROGRAM DESCRIPTION: GAME 2014 - Mobile Game Development I, Midterm I, Space Shooter Demo
 * REVISION HISTORY: OCTOBER 21, 2021 - CHANGED BACKGROUND TO SCROLL HORIZONTALLY INSTEAD OF VERTICALLY
 */

public class BackgroundController : MonoBehaviour
{
    [Header("Background Settings")]
    public float horizontalSpeed;
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 0.0f);     // moves background along x axis
    }

    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;      // moves background by horizontal speed by delta time
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
