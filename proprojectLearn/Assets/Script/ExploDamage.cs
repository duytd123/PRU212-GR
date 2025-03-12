using UnityEngine;

public class ExploDamage : MonoBehaviour
{
    [SerializeField] private float damage = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // gay dame len ca player va enemy goi tham chieu tu collision
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(damage);

        }
        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }
    }

    public void DestroyExplo()
    {
        Destroy(gameObject);
    }
}
