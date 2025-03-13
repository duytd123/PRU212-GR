using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rb; // thao tac voi cac thanh phan vat ly trong game

    private SpriteRenderer rbSprite;

    private Animator animator;

    [SerializeField] private float maxHp = 100f;
    public static float currentHp;
    [SerializeField] private Image hpBar;
    private void Awake()// goi phuong thuc Awake lay tham chieu den thanh phan Rigidbody2D
    {
        rb = GetComponent<Rigidbody2D>(); // thanh phan vat ly
        rbSprite = GetComponent<SpriteRenderer>(); // phai gan component de xu ly 
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }


    void Update()
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {
        // tao mot bien co kieu du lieu vector 2
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // lay tri cho vector playerInput 
        rb.linearVelocity = playerInput.normalized * moveSpeed;// dat cai van toc duoc huan hoa 
        // * bien movespeed de kiem soat duoc toc do cua player
        if (playerInput.x < 0) // gia tri cua hoz -1 la di chuyen sang trai
        {
            rbSprite.flipX = true;
        }
        else if (playerInput.x > 0)
        {
            rbSprite.flipX = false;
        }

        if (playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    public void TakeDamage( float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }
    public void Heal(float healAmount)
    {
        if (currentHp < maxHp)
        {
            currentHp += healAmount;
            currentHp = Mathf.Min(currentHp, maxHp);
            UpdateHpBar();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    protected void UpdateHpBar()
    {
        hpBar.fillAmount = currentHp / maxHp;
    }
}
