using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;  // Cantidad de daño que inflige el enemigo

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Llama al método TakeDamage en el jugador, este método debe estar en tu PlayerController
            PlayerMOVE player = collision.GetComponent<PlayerMOVE>();
            if (player != null)
            {
                player.TakeDamage(damage);  // Llama al método TakeDamage en el script del jugador
            }

            // Destruye el enemigo después de la colisión (opcional)
            Destroy(gameObject);
        }
    }
}
