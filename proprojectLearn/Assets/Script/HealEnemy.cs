using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float heal = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    protected override void Die()
    {
        base.Die();
        HealPlayer();
    }
    private void HealPlayer()
    {
        if (player != null)
        {
            player.Heal(heal);
        }
    }
}