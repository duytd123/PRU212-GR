using UnityEngine;
using TMPro;
public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shotDelay = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmmo = 25;
    private int currentAmmo;
    [SerializeField] private TextMeshProUGUI ammoText;
    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        RoteGun();
        Shoot();
        Reload();
    }

    void RoteGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // tinh toa do khoang cach giua vi tri cua chuot va vi tri cua sung
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        // lay gia tri cua antan imple x, y de tinh goc quay cua sung
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        if(angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmoText();
        }
    }
    void Reload()
    {
        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            UpdateAmmoText();
        }
    }
    private void UpdateAmmoText()
    {
        if(ammoText != null)
        {
            if(currentAmmo > 0)
            {
                ammoText.text = currentAmmo.ToString();
            }
            else
            {
                ammoText.text = "Empty";
            }
        }
    }
}
