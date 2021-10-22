using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BULLETMANAGER.CS
 * RODNEY KRISTIAN DICKSON
 * 101068801
 * DATE LAST MODIFIED: N/A
 * PROGRAM DESCRIPTION: GAME 2014 - Mobile Game Development I, Midterm I, Space Shooter Demo
 * REVISION HISTORY: OCTOBER 21, 2021 - MAIN UPDATE, ROTATED SCREEN / SPRITES, LOCKED PLAYER ROTATION / POSITION
 */

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    [Header("Bullet Stuff")]
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();     // starts our bullet pool
    }

    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBullets; count++)        // if our bullet count is less than our max bullet count, create bullet, add to queue
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)               // gets our bullets position to move along x
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public bool HasBullets()                                    // if you still have bullets, youre above 0
    {
        return m_bulletPool.Count > 0;
    }

    public void ReturnBullet(GameObject returnedBullet)         // returned bullets are no longer active
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
