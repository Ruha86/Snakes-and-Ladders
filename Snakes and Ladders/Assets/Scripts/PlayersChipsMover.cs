using UnityEngine;

public class PlayersChipsMover : MonoBehaviour
{
    // ������ �������� ����
    public GameField GameField;

    // ������ ����� �������
    private PlayerChip[] _playersChips;

    // ������ ������� ������� �����
    private int[] _playersChipsCellsIds;

    // ������ � ����������� ���������
    public TransitionSettings TransitionSettings;

    public void StartGame(PlayerChip[] playersChips)
    {
        // ����������� ������ ����� �������
        _playersChips = playersChips;

        // ������ ������ ��� �������� ������� ������� �����
        _playersChipsCellsIds = new int[playersChips.Length];

        // �������� ����� ��� ���������� ������� ���� �����
        RefreshChipsPositions();
    }

    public void RefreshChipsPositions()
    {
        // �������� � ����� �� ���� ������ �������
        for (int i = 0; i < _playersChips.Length; i++)
        {
            // �������� ����� ��� ���������� ������� ����� � ������� i
            RefreshChipPosition(i);
        }
    }

    public void MoveChip(int playerId, int steps)
    {
        // ����������� ������� ������� ����� �� �������� ����� �����
        _playersChipsCellsIds[playerId] += steps;

        // ���� ������� ������� ����� ��������� ���������� ����� �� ������� ����
        if (_playersChipsCellsIds[playerId] >= GameField.CellsCount)
        {
            // ������������� ����� �� ��������� ������
            _playersChipsCellsIds[playerId] = GameField.CellsCount - 1;
        }
        // �������� ����� ��� ���������� ������� �����
        RefreshChipPosition(playerId);

        // �����: �������� ����� �������� ��������
        TryApplyTransition(playerId);

        RefreshChipPosition(playerId);
    }

    private void RefreshChipPosition(int playerId)
    {
        // �������� ������� ������ �� ������� ����, ������� ������������� ������� ������� �����
        Vector2 chipPosition = GameField.GetCellPosition(_playersChipsCellsIds[playerId]);

        // ������������� ����� �� ���������� �������
        _playersChips[playerId].SetPosition(chipPosition);
    }

    private void TryApplyTransition(int playerId)
    {
        // �������� ����� ����� ������ ����� ���� ������
        int resultCellId = TransitionSettings.GetTransitionResultCellId(_playersChipsCellsIds[playerId]);

        // ���� ����� ������ 0
        if (resultCellId < 0)
        {
            // ������� �� ���� ��� �������� �� �����
            return;
        }

        // ������������� ����� ����� ������
        _playersChipsCellsIds[playerId] = resultCellId;
    }

}
