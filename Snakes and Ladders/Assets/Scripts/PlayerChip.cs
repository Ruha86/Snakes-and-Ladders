using UnityEngine;

public class PlayerChip : MonoBehaviour
{
    // ���� ����� ������������� ������ �����
    public void SetSprite(Sprite sprite)
    {
        // �������� ��������� SpriteRenderer, ������� ���������� ������� �� ������� �����
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // ������������� ������, ���������� � �����, � ��������� SpriteRenderer
        spriteRenderer.sprite = sprite;
    }

    // ������������� ����� ������� �����
    public void SetPosition(Vector2 position)
    {
        // �������� ������� �������, � �������� �������� ���� ������
        transform.position = position;
    }
}
