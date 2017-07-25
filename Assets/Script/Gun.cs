﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Transform muzzle;
    public Projectile projectile;
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35;
    public GameObject obj;

    float nextShootTime;

    void Start()
    {
        muzzle = transform;
    }
    public void Shoot()
    {
        if (Time.time > nextShootTime)
        {
            nextShootTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(muzzleVelocity);
        }
    }
}
