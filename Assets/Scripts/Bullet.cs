using Assets.Scripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed = 20f;
    [SerializeField]
    private float _bulletLifeTime = 5f;
    [SerializeField]
    private int _bulletDamage = 2;

    private BaseTowerController _towerController;
    private Rigidbody _rb;

    public int GetDamage() => _bulletDamage;

    public void Setup(BaseTowerController towerController)
    {
        _towerController = towerController;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            LifeController lifeController = collision.collider.gameObject.GetComponent<LifeController>();
            lifeController.AddHp(-GetDamage());
        }
        CancelInvoke();
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        _towerController.ReleaseBullet(this);
    }

    public void Shoot(Vector3 direction)
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();

        _rb.linearVelocity = direction * _bulletSpeed;
        _rb.angularVelocity = Vector3.zero;

        CancelInvoke();
        Invoke("ReturnToPool", _bulletLifeTime);
    }
}
