using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float enemyMoveSpeed = 1f;

    protected Player player;

    [SerializeField]
    protected float maxHp = 50f;
    protected float currentHp;

    [SerializeField] private Image hpBar;

    [SerializeField] protected float damage = 20f;
    [SerializeField] protected float stayDamage = 1f;
    // de cho nhung thanh con co them nhung cau lenh rieng trong phan start
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        UpdateHpBar();
    }

    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }

    protected void FlipEnemy()
    {
        if (player != null)
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
    }

    public virtual void TakeDamage(float damage)
    {

        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
        
    protected void UpdateHpBar()
    {
        hpBar.fillAmount = currentHp / maxHp;
    }
}
