using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlMovement : MonoBehaviour
{
    public float speedMove = 2.0f;

    public float initialEnergy = 100.0f;

    private float currentEnergy;

    private Vector2 positionToMove;

    public float viewRange = 5.0f;

    private bool isChasing = false;

    private Vector2 initialPosition;

    void Start()
    {

        currentEnergy = initialEnergy;

        positionToMove = transform.position;

        initialPosition = transform.position;
    }

    void Update()
    {

        if (IsPlayerInViewRange())
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }

        if (currentEnergy <= 0)
        {
            StopMoving();
        }
    }

    bool IsPlayerInViewRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(transform.position, player.transform.position);

        return distance < viewRange;
    }

    void ChasePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        positionToMove = player.transform.position;

        transform.position = Vector2.MoveTowards(transform.position, positionToMove, speedMove * Time.deltaTime);

        currentEnergy -= Time.deltaTime * 10;
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, positionToMove, speedMove * Time.deltaTime);

        if (Vector2.Distance(transform.position, positionToMove) < 0.1f)
        {
            positionToMove = initialPosition + new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
        }
    }

    void StopMoving()
    {
        speedMove = 0;
    }

    public void SetNewPosition(Vector2 newPosition)
    {
        positionToMove = newPosition;
    }
}