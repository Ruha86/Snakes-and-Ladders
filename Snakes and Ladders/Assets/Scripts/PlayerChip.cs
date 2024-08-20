using UnityEngine;

public class PlayerChip : MonoBehaviour
{
    // Этот метод устанавливает спрайт фишки
    public void SetSprite(Sprite sprite)
    {
        // Получаем компонент SpriteRenderer, который отображает спрайты на игровой сцене
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Устанавливаем спрайт, переданный в метод, в компонент SpriteRenderer
        spriteRenderer.sprite = sprite;
    }

    // Устанавливаем новую позицию фишки
    public void SetPosition(Vector2 position)
    {
        // Изменяем позицию объекта, к которому привязан этот скрипт
        transform.position = position;
    }
}
