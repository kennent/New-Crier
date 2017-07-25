using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Chest : MonoBehaviour
{
    public Projectile projectile;
    public Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
    }
}
