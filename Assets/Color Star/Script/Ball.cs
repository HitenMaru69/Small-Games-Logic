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

    private void ChangeColor()
    {
        switch (colorName)
        {
            case ColorName.Red:
                SpriteColor(Color.red);
                colorName = ColorName.Yellow;
                break;

            case ColorName.Yellow:
                SpriteColor(Color.yellow);
                colorName = ColorName.Pink;
                break;

            case ColorName.Pink:
                SpriteColor(Color.cyan);
                colorName = ColorName.Blue;
                break;

            case ColorName.Blue:
                SpriteColor(Color.blue);
                colorName = ColorName.Red;
                break;
        }
    }

    private void SpriteColor(Color col)
    {
        spriteRenderer.color = col;
    }

}
