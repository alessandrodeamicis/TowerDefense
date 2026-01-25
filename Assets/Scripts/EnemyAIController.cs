using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("WhiteHouse").transform.position);
    }
}
