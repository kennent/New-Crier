using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingEntity : MonoBehaviour
{
    public float startingHealth;
    protected float health;
    protected bool dead;
    public float n;

    public virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage)
    {
        health -= damage;
        if (health <= 0 && !dead)
            Die();
    }

    public void Die()
    {
        dead = true;
        Destroy(gameObject);
        if (n == 1)
            SceneManager.LoadScene("GameOver");
        else
            SceneManager.LoadScene("Ending");
    }
}
