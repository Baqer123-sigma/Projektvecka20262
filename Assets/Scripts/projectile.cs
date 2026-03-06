using UnityEngine;

public class projectile : MonoBehaviour
{
    //Alex B.T
    private void Awake()
    {
        Destroy(gameObject, 5); // Destroys projectile after X seconds to prevent lag
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Playerhealth>().TakeDamage(30);
        }
    }
}
