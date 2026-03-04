using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate = 1f;
    public float damage = 2f;

    private float nextTimeToFire;
    private BoxCollider gunTrigger;

    public LayerMask mask;
    public EnemyManager enemyManager;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Damage all enemies in line of sight
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            // Get direction to enemy
            var direction = enemy.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, range + 1.5f, mask))
            {
                if (hit.transform == enemy.transform)
                {
                    // Range check
                    float distance = Vector3.Distance(enemy.transform.position, transform.position);

                    if (distance > range * 0.5f)
                    {
                        enemy.TakeDamage(damage * 0.5f);
                    }
                    else
                    {
                        enemy.TakeDamage(damage);

                    }
                }
            }
        }

        // Reset timer
        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Add potential target
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            // Add here
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove potential target
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            // Remove here
            enemyManager.RemoveEnemy(enemy);
        }

    }
}