using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingEntity
{

    NavMeshAgent pathfinder;
    public Transform player;
    Transform enemy;
    
    float damage = 100.0f;
    float bossHelath = 100.0f;

    public override void Start()
    {
        base.Start();
        enemy = GetComponent<Transform>();
        pathfinder = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdatePath());
        n = 1;
    }

    IEnumerator UpdatePath()
    {
        float refreshPosition = 0.25f;

        while (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, 0, player.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshPosition);
        }
    }
}
