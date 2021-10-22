using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BULLETFACTORY.CS
 * RODNEY KRISTIAN DICKSON
 * 101068801
 * DATE LAST MODIFIED: N/A
 * PROGRAM DESCRIPTION: GAME 2014 - Mobile Game Development I, Midterm I, Space Shooter Demo
 * REVISION HISTORY: OCTOBER 21, 2021 - MAIN UPDATE, ROTATED SCREEN / SPRITES, LOCKED PLAYER ROTATION / POSITION
 */

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject regularBullet;
    public GameObject fatBullet;
    public GameObject pulsingBullet;

    public GameObject createBullet(BulletType type = BulletType.RANDOM)     // creates random bullet type
    {
        if (type == BulletType.RANDOM)
        {
            var randomBullet = Random.Range(0, 3);
            type = (BulletType) randomBullet;
        }

        GameObject tempBullet = null;
        switch (type)                                                       // Each bullet does different damages, right now no functionality
        {
            case BulletType.REGULAR:
                tempBullet = Instantiate(regularBullet);
                tempBullet.GetComponent<BulletController>().damage = 10;
                break;
            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                tempBullet.GetComponent<BulletController>().damage = 20;
                break;
            case BulletType.PULSING:
                tempBullet = Instantiate(pulsingBullet);
                tempBullet.GetComponent<BulletController>().damage = 30;
                break;
        }

        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);

        return tempBullet;
    }
}
