using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 movementDir;
    void Start()
    {
        Destroy(gameObject, 20f);
    }


    void Update()
    {
        if (movementDir == Vector3.zero) return;

        transform.position += movementDir * Time.deltaTime;

    }

    public void SetMovement(Vector3 direction)
    {
        movementDir = direction;
    }
}
