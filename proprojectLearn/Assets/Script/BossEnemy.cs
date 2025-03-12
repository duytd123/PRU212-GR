using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 20f;
    [SerializeField] private float fireRateVongTron = 10f;
    [SerializeField] private float mxHp = 20f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillColldown = 2f;
    private float nextSkillTime = 1f;
    [SerializeField] private GameObject usbPrefabs;
    protected override void Update()
    {
        base.Update();
        // kiem tra xem co the dung skill chua
        // neu thoi gian hien tai lon hon thoi gian tiep theo co the dung skill
        if (Time.time >= nextSkillTime)
        {
            UsingSkill();
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    BanDanThuong();
        //    HoiMau(mxHp);
        //}
    }

    protected override void Die()
    {
        Instantiate(usbPrefabs, transform.position, Quaternion.identity);
        base.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
    }

    public void BanDanThuong()
    {
        if (player != null)
        {
            // tinh toan huong vien dan den player
            Vector3 fireDir = player.transform.position - firePoint.position;
            fireDir.Normalize();

            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovement(fireDir * fireRate);
        }
    }

    private void BanDanVongTron()
    {
        const int bulletCount = 10; // so luong vien dan
        float angleStep = 360f / bulletCount; // goc giua cac vien dan
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = angleStep * i;
            
            Vector3 fireDir = new Vector3(Mathf.Cos(Mathf.Deg2Rad*angle), Mathf.Sin(Mathf.Deg2Rad * angle),0);
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);

            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovement(fireDir * fireRateVongTron);
        }
    }

    private void HoiMau(float hpAmount)
    {
        currentHp = Mathf.Max(currentHp + hpAmount, mxHp);
        UpdateHpBar();
    }

    private void SinhMiniEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }

    private void DichChuyen()
    {
        if(player != null)
        {
            transform.position = player.transform.position;

        }
    }

    private void ChooseRandomSkill()
    {
        int randomSkill = Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                HoiMau(mxHp);
                break;
            case 3:
                SinhMiniEnemy();
                break;
            case 4:
                DichChuyen();
                break;          
        }
    }

    private void UsingSkill()
    {
        nextSkillTime = Time.time + skillColldown;
        ChooseRandomSkill();
    }
}
