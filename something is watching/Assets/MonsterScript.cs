using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent monsterAI;
    [SerializeField] Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        monsterAI.SetDestination(player.position);
    }
}
