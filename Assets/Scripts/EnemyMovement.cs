using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _maxDistanceToEnemy = 3f;
    [SerializeField] private Transform _target;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!EnemyIsClose())
            Move();
    }

    private void Move()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * _speed * Time.deltaTime);
    }

    private bool EnemyIsClose()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _target.position);
        return distanceToTarget <= _maxDistanceToEnemy;
    }
}
