using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] float _shootPower = 10f;

    float shootTimer;

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
        GameObject sphere = Instantiate(_spherePrefab, _shootingPoint.position, Quaternion.identity);
        Rigidbody sphereRb = sphere.GetComponent<Rigidbody>();
        sphereRb.AddForce(new Vector3(_shootPower, 0), ForceMode.Impulse);
    }
}
