using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float enemySpeed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject firePos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    private void Awake()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        MoveToPlayer();

        if (Input.GetKeyDown(KeyCode.Space)) { ShootBullet(); }

    }
    private void MoveToPlayer()
    {
        Vector3 direction = (transform.position - playerMovement.transform.position).normalized;
        transform.Translate(-direction * enemySpeed * Time.deltaTime);
       
 
    }

    private void ShootBullet()
    {
        GameObject newSpwabObject = Instantiate(bullet,firePos.transform.position,Quaternion.LookRotation(firePos.transform.forward));
        Rigidbody2D rigidbody2D = newSpwabObject.GetComponent<Rigidbody2D>();

        rigidbody2D.linearVelocity = firePos.transform.forward * bulletSpeed * Time.deltaTime;

    }



}
