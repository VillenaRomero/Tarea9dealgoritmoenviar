using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Vector2 positionToMove;
    public float speedMove;
    void Start()
    {
        transform.position = Vector2.MoveTowards(transform.position, positionToMove, speedMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetNewPosition(Vector2 newPosition) {
        positionToMove = newPosition;
    }
}
