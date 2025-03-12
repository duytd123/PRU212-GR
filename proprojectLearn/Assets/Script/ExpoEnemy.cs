using UnityEngine;

public class ExpoEnemy : Enemy

{
    [SerializeField] private GameObject exploPrefabs;

    //  bat dau tao ra 1 doi tuong

    private void CreateExplosion()
    {
        if (exploPrefabs != null)
        {
            // tao ra 1 doi tuong explosion
            Instantiate(exploPrefabs, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CreateExplosion();
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        if (player != null)
    //        {
    //            player.TakeDamage(damage);
    //            Die();
    //        }
    //    }
    //}

    protected override void Die()
    {
        CreateExplosion();
        base.Die();

    }
}

