using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BULLETCONTROLLER.CS
 * RODNEY KRISTIAN DICKSON
 * 101068801
 * DATE LAST MODIFIED: OCTOBER 21, 2021
 * PROGRAM DESCRIPTION: GAME 2014 - Mobile Game Development I, Midterm I, Space Shooter Demo
 * REVISION HISTORY: OCTOBER 21, 2021 - CHANGED ORIENTATION OF BULLETS TO GO HORIZONTALLY INSTEAD OF VERTICALLY
 */

public class BulletController : MonoBehaviour, IApplyDamage
{
    [Header("Bullet Settings")]
    public float horizontalSpeed;
    public float horizontalBoundary;
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed, 0.0f, 0.0f) * Time.deltaTime;        // moves bullet by horizontal speed along x
    }

    private void _CheckBounds()     // checks bullets bounds, deletes once past bounds
    {
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)      // triggers when bullet hits something
    {
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()        // applies damage, again, no functionality
    {
        return damage;
    }
}
