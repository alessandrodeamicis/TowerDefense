using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField]
    //private float _bulletSpeed = 10f;
    [SerializeField]
    private float _bulletLifeTime = 5f;

    private BaseTowerController _towerController;
    private Rigidbody _rb;

    public void Setup(BaseTowerController towerController)
    {
        _towerController = towerController;
    }
    private void OnCollisionEnter(Collision collision)
    {
        CancelInvoke();
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        _towerController.ReleaseBullet(this);
    }

    public void Shoot(Vector3 direction, float speed)
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();

        _rb.linearVelocity = direction * speed;
        _rb.angularVelocity = Vector3.zero;

        CancelInvoke();
        Invoke("ReturnToPool", _bulletLifeTime);
    }
}
