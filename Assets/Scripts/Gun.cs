using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate = 1f;

    private float nextTimeToFire;
    private BoxCollider gunTrigger;

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
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            // damage enemies

        }

        // reset timer
        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        // add potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            // add here
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // remove potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            // remove here
            enemyManager.RemoveEnemy(enemy);
        }

    }
}