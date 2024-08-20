using UnityEngine;

public class PlayersChipsMover : MonoBehaviour
{
    // Скрипт игрового поля
    public GameField GameField;

    // Массив фишек игроков
    private PlayerChip[] _playersChips;

    // Массив текущих позиций фишек
    private int[] _playersChipsCellsIds;

    // Скрипт с настройками переходов
    public TransitionSettings TransitionSettings;

    public void StartGame(PlayerChip[] playersChips)
    {
        // Присваиваем массив фишек игроков
        _playersChips = playersChips;

        // Создаём массив для хранения текущих позиций фишек
        _playersChipsCellsIds = new int[playersChips.Length];

        // Вызываем метод для обновления позиций всех фишек
        RefreshChipsPositions();
    }

    public void RefreshChipsPositions()
    {
        // Проходим в цикле по всем фишкам игроков
        for (int i = 0; i < _playersChips.Length; i++)
        {
            // Вызываем метод для обновления позиции фишки с номером i
            RefreshChipPosition(i);
        }
    }

    public void MoveChip(int playerId, int steps)
    {
        // Увеличиваем текущую позицию фишки на заданное число шагов
        _playersChipsCellsIds[playerId] += steps;

        // Если текущая позиция фишки превышает количество ячеек на игровом поле
        if (_playersChipsCellsIds[playerId] >= GameField.CellsCount)
        {
            // Устанавливаем фишку на последнюю ячейку
            _playersChipsCellsIds[playerId] = GameField.CellsCount - 1;
        }
        // Вызываем метод для обновления позиции фишки
        RefreshChipPosition(playerId);

        // НОВОЕ: Вызываем метод проверки перехода
        TryApplyTransition(playerId);

        RefreshChipPosition(playerId);
    }

    private void RefreshChipPosition(int playerId)
    {
        // Получаем позицию ячейки на игровом поле, которая соответствует текущей позиции фишки
        Vector2 chipPosition = GameField.GetCellPosition(_playersChipsCellsIds[playerId]);

        // Устанавливаем фишку на полученную позицию
        _playersChips[playerId].SetPosition(chipPosition);
    }

    private void TryApplyTransition(int playerId)
    {
        // Получаем новый номер ячейки после хода игрока
        int resultCellId = TransitionSettings.GetTransitionResultCellId(_playersChipsCellsIds[playerId]);

        // Если номер меньше 0
        if (resultCellId < 0)
        {
            // Переход по змее или лестнице не нужен
            return;
        }

        // Устанавливаем новый номер ячейки
        _playersChipsCellsIds[playerId] = resultCellId;
    }

}
