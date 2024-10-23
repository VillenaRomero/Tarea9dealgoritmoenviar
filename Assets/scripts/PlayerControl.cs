/*using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector2 positionToMove;
    public float speedMove;
    public float enemyEnergy;  // Energía del enemigo
    public float restTime;     // Tiempo de descanso
    private bool resting = false;
    private float restTimer = 0f;

    // Grafo del nivel
    private Node currentNode;
    private Node targetNode;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos la energía del enemigo
        enemyEnergy = 100f;  // Por ejemplo, 100 de energía
    }

    // Update is called once per frame
    void Update()
    {
        if (resting)
        {
            restTimer -= Time.deltaTime;
            if (restTimer <= 0)
            {
                resting = false;  // El descanso ha terminado
            }
            return;
        }

        if (targetNode != null)
        {
            // Mover al enemigo hacia el nodo objetivo
            transform.position = Vector2.MoveTowards(transform.position, targetNode.Position, speedMove * Time.deltaTime);

            // Si ha alcanzado el nodo objetivo
            if (Vector2.Distance(transform.position, targetNode.Position) < 0.1f)
            {
                ReachTargetNode();
            }
        }
    }

    // Método para cambiar la posición del enemigo y restar energía
    public void SetNewTarget(Node newTarget)
    {
        Edge edgeToTarget = GetEdgeToTarget(newTarget);
        if (edgeToTarget != null && enemyEnergy >= edgeToTarget.weight)
        {
            targetNode = newTarget;
            enemyEnergy -= edgeToTarget.weight;
        }
        else
        {
            if (enemyEnergy < edgeToTarget.weight)
            {
                // El enemigo necesita descansar
                StartResting();
            }
        }
    }

    private Edge GetEdgeToTarget(Node target)
    {
        for (int i = 0; i < currentNode.edges.Count(); i++)
        {
            Edge edge = currentNode.edges.GetEdge(i);
            if (edge.destination == target)
            {
                return edge;
            }
        }
        return null;
    }

    // Cuando el enemigo alcanza el nodo objetivo
    private void ReachTargetNode()
    {
        currentNode = targetNode;
        targetNode = null;
    }

    private void StartResting()
    {
        resting = true;
        restTimer = restTime;
    }
}
*/