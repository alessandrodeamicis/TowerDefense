using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] float _shootArea = 10f;

    private float shootTimer;
    private Queue<Bullet> _bulletPool = new Queue<Bullet>();

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= 1f)
        {
            CheckIfEnemyIsInRange();
            shootTimer = 0f;
        }
    }

    private void Shoot(Vector3 direction, float shootPower)
    {
        Bullet b = GetBullet();
        b.transform.position = _shootingPoint.position;
        b.Shoot(direction, shootPower);
    }

    public Bullet GetBullet()
    {
        Bullet bullet = null;
        if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate(_bulletPrefab).GetComponent<Bullet>();
            bullet.Setup(this);
        }
        return bullet;
    }

    public void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }

    private void CheckIfEnemyIsInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _shootArea);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Vector3 direction = (hitCollider.transform.position - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(direction);
                _shootingPoint.localPosition = rotation * Vector3.forward;
                _shootingPoint.rotation = rotation;
                Shoot(direction, Vector3.Distance(transform.position, hitCollider.transform.position) * 2);
            }
        }
    }
}
