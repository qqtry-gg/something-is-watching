using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent monsterAI;
    [SerializeField] Transform player;
    [SerializeField] SC_FPSController fpsController;
    [SerializeField] AudioSource bite;
    [SerializeField] AudioSource monsterGrowl;
    public float chaseRange = 30f;
    private Vector3 patrolTarget;
    private bool playerInSafeZone = false;
    bool used = false;
    Animator animator;

    private enum State {Patrol, Chase}
    private State currentState = State.Patrol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        SetNewPatrolPoint();
        StartCoroutine(growlPlay());
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !used)
        {
            Debug.Log("Dotykam playera");
            fpsController.enabled = false;
            monsterAI.enabled = false;
            Vector3 lookTarget = transform.position + Vector3.up * 2f; // 2 jednostki wy¿ej
            Camera.main.transform.LookAt(lookTarget);
            StartCoroutine(biteCooldown());
            used = true;
            animator.SetTrigger("Attacking");
        }
    }
    IEnumerator biteCooldown()
    {
        for (int i = 0; i < 3; i++)
        {
            bite.Play();
            yield return new WaitForSeconds(bite.clip.length);
        }
    }
    IEnumerator growlPlay()
    {
        while (true)
        {
            int time = Random.Range(20, 60);
            monsterGrowl.Play();
            yield return new WaitForSeconds(time);
        }
    }
}
