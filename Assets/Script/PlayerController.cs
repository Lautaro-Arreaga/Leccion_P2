using UnityEngine;


public class PlayerMOVE : MonoBehaviour
{
    public float playerJumpForce = 10f;
    public float playerSpeed = 5f;
    private Rigidbody2D myRigidbody2D;
    private int currentHealth;  // Salud actual del jugador
    public int maxHealth = 3;   // Salud máxima del jugador

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;  // Inicializa la salud del jugador
    }

    void Update()
    {
        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, playerJumpForce);  // Salto
        }

        // Movimiento hacia la derecha con la tecla 'D'
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody2D.linearVelocity = new Vector2(playerSpeed, myRigidbody2D.linearVelocity.y);  // Movimiento hacia la derecha
        }
    }

    public void TakeDamage(int damage)
    {
        // Reducir la salud del jugador
        currentHealth -= damage;
        Debug.Log("Salud del jugador: " + currentHealth);

        // Verifica si el jugador está muerto
        if (currentHealth <= 0)
        {
            PlayerDeath();  // Llama al método para manejar la muerte del jugador
        }
    }

    void PlayerDeath()
    {
        Debug.Log("El jugador ha muerto");
        // Aquí puedes agregar la lógica para matar al jugador, como desactivar el objeto o reiniciar el juego.
        gameObject.SetActive(false);  // Desactiva el jugador (opcional)
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Llama al método TakeDamage cuando el jugador colisiona con un enemigo (ItemBad)
            TakeDamage(1);  // Suponiendo que el daño es 1, ajusta según sea necesario
        }
    }
}
