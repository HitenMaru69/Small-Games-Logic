using System;
using UnityEngine;


public class EnemyBall : MonoBehaviour
{
    private ColorName enemyColor;

    private SpriteRenderer spriteRenderer;

    public int enemyBallNumber;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetEnemyColor();
    }

    private void SetEnemyColor()
    {
       int ramdomNumber = UnityEngine.Random.Range(0, 4);

       enemyColor = (ColorName)ramdomNumber;

        ChangeColor();
    }

    private void ChangeColor()
    {
        switch (enemyColor) {

            case ColorName.Red:
                spriteRenderer.color = Color.red;
                enemyBallNumber = 1;
                break;

            case ColorName.Yellow:
                spriteRenderer.color = Color.yellow;
                enemyBallNumber = 2;
                break;

            case ColorName.Pink:
                spriteRenderer.color = Color.cyan;
                enemyBallNumber = 3;
                break;

            case ColorName.Blue:
                spriteRenderer.color = Color.blue;
                enemyBallNumber = 4;
                break;
        }

    }
}
