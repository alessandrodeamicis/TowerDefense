using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] float _shootPower = 10f;

    private float shootTimer;
    private Queue<Bullet> _bulletPool = new Queue<Bullet>();

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= 1f)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        Bullet b = GetBullet();
        b.transform.position = _shootingPoint.position;
        b.Shoot(_shootingPoint.forward);
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
}
