using UnityEngine;

public class EnemyEnergy : Enemy
{
    // bat dau khoi tao cac bien
    [SerializeField] private GameObject energryObject;
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

    // enemy se tan cong player khi player cham vao enemy
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
        if (energryObject != null)
        {
            // truoc khi enemy chet se tao ra mot doi tuong energy
            GameObject energy = Instantiate(energryObject, transform.position, Quaternion.identity);
            // sau 3s se huy doi tuong energy
            Destroy(energy, 6f);
        }
        base.Die();
    }

}
