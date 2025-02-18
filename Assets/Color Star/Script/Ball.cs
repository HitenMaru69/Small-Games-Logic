using UnityEngine;

public enum ColorName
{
    Red = 0,
    Yellow = 1,
    Pink = 2,
    Blue = 3
}

public class Ball : MonoBehaviour
{
    [SerializeField]private ColorName colorName = ColorName.Red;
    private SpriteRenderer spriteRenderer;
    private int currentPlayerNumber = 1;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeColor();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            EnemyBall enemyBall = collision.gameObject.GetComponent<EnemyBall>();

            if (enemyBall.enemyBallNumber == currentPlayerNumber) 
            {
                Destroy(collision.gameObject);
                SpwanManager.instance.RemoveTotalBall();
            }
            else
            {
                Destroy(this.gameObject);
                // Lose Game
            }


        }
    }

    private void ChangeColor()
    {
        switch (colorName)
        {
            case ColorName.Red:
                SpriteColor(Color.red);
                currentPlayerNumber = 1;
                colorName = ColorName.Yellow;
                break;

            case ColorName.Yellow:
                SpriteColor(Color.yellow);
                currentPlayerNumber = 2;
                colorName = ColorName.Pink;
                break;

            case ColorName.Pink:
                SpriteColor(Color.cyan);
                currentPlayerNumber = 3;
                colorName = ColorName.Blue;
                break;

            case ColorName.Blue:
                SpriteColor(Color.blue);
                currentPlayerNumber = 4;
                colorName = ColorName.Red;
                break;
        }
    }

    private void SpriteColor(Color col)
    {
        spriteRenderer.color = col;
    }

}
