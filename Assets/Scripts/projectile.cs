using UnityEngine;

public class projectile : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Playerhealth>().TakeDamage(30);
        }
    }
}
