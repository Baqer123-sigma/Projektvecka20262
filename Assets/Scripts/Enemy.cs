using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHealth = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}