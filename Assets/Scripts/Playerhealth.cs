using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    MeshRenderer playerModel;
    Gun gun;
    PlayerMovement movement;
    MouseLook look;
    int health = 300;

    private void Start()
    {
        playerModel = GetComponentInChildren<MeshRenderer>();
        gun = GetComponentInChildren<Gun>();
        movement = GetComponent<PlayerMovement>();
        look = GetComponent<MouseLook>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            print("Aj jag dog");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            gun.gameObject.SetActive(false);
            playerModel.gameObject.SetActive(false);
            movement.enabled = false;
            look.enabled = false;
            loseScreen.SetActive(true);
        }
    }
}
