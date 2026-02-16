using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private int _distanceFromDestination = 10;



    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(GameObject.FindGameObjectWithTag("WhiteHouse").transform.position);
    }
    private void Update()
    {
        if (agent.remainingDistance <= _distanceFromDestination) agent.isStopped = true;
    }
}
