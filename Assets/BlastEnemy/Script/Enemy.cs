using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject firePos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    private float storeEnemySpeed;

    private void Awake()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();

    }

    private void Start()
    {
        InvokeRepeating(nameof(ShootBullet), 1f, 2f);
        storeEnemySpeed = enemySpeed;

    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector3 direction = (transform.position - playerMovement.transform.position).normalized;
        transform.Translate(-direction * enemySpeed * Time.deltaTime);
        CheckDistance();
    }

    private void CheckDistance()
    {

        float distance = Vector3.Distance(transform.position, playerMovement.transform.position);
        {
            if (distance <= 3f)
            {
                enemySpeed = 0;
            }
            else
            {
                enemySpeed = storeEnemySpeed;
            }
        }
    }

    private void ShootBullet()
    {
        GameObject newSpwabObject = Instantiate(bullet, firePos.transform.position, Quaternion.identity);
        Vector3 dir = (playerMovement.transform.position - firePos.transform.position).normalized;
        Bullet bullets = newSpwabObject.GetComponent<Bullet>();
        bullets.direction = dir;

    }



}
