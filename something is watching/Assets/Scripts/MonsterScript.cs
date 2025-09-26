using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent monsterAI;
    [SerializeField] Transform player;
    public float chaseRange = 10f;
    private Vector3 patrolTarget;
    private bool playerInSafeZone = false;

    private enum State {Patrol, Chase}
    private State currentState = State.Patrol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNewPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInSafeZone && Vector3.Distance(transform.position, player.position) < chaseRange)
        {
            currentState = State.Chase;
        }
        else
        {
            currentState = State.Patrol;
        }
        if (currentState == State.Chase)
        {
            monsterAI.SetDestination(player.position);
        }
        else if (currentState == State.Patrol)
        {
            if (Vector3.Distance(transform.position, patrolTarget) < 1f)
            {
                SetNewPatrolPoint();
            }
            monsterAI.SetDestination(patrolTarget);
        }
    }
    void SetNewPatrolPoint()
    {
        Vector3 randomDir = Random.insideUnitSphere * 10f;
        randomDir += transform.position;
        NavMeshHit hit;

        NavMesh.SamplePosition(randomDir, out hit, 10f, NavMesh.AllAreas);
        patrolTarget = hit.position;
    }
    public void SetSafeZone(bool isInSafeZone)
    {
        playerInSafeZone = isInSafeZone;
    }
}
