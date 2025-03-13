
using System.Collections;
using UnityEngine;

public class IceEnemy1 : Enemy
{
    public Animator anim;
    private bool isKicking = false;
    private bool isDead = false; // Biến kiểm soát trạng thái chết

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            StartCoroutine(resetAttack());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(stayDamage);

            if (!isKicking)
            {
                anim.ResetTrigger("Wait");
                anim.SetTrigger("Kick");
                isKicking = true;
            }
            StartCoroutine(resetAttack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Player"))
        {
            anim.ResetTrigger("Kick");
            anim.SetTrigger("Wait");
            isKicking = false;
        }
    }

    protected override void Die()
    {
        if (isDead) return; // Tránh gọi lại nhiều lần
        isDead = true;

        anim.SetTrigger("Die"); // Kích hoạt animation chết
        GetComponent<Collider2D>().enabled = false; // Tắt va chạm
        enemyMoveSpeed = 0; // Ngăn kẻ địch di chuyển

        // Gọi Die() của lớp cha sau 1 giây để chờ animation hoàn thành
        Invoke(nameof(ExecuteBaseDie), 1.5f);
    }

    private void ExecuteBaseDie()
    {
        base.Die(); // Gọi Die() của Enemy để hủy object
    }

    //reset attack
    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(3.5f);
    }
}
