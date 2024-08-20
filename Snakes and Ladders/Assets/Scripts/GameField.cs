using UnityEngine;

public class GameField : MonoBehaviour
{
    // Позиция первой ячейки
    public Transform FirstCellPoint;

    // Размер ячейки (по X и Y)
    public Vector2 CellSize;

    // Общее количество ячеек на игровом поле
    public int CellsCount = 100;

    // Количество ячеек в одном ряду
    public int CellsInRow = 10;

    // Массив из позиций каждой ячейки
    private Vector2[] _cellsPositions;

    public void FillCellsPositions()
    {
        // Создаём массив с размером, равным общему количеству ячеек
        _cellsPositions = new Vector2[CellsCount];

        // Заводим переменную, которая отслеживает, где создаются новые ячейки (они будут добавляться вправо и влево)
        bool right = true;

        // Делаем позицию первой ячейки в массиве равной заданной позиции первой ячейки
        _cellsPositions[0] = FirstCellPoint.position;

        // Проходим по каждой ячейке, начиная со второй
        for (int i = 1; i < _cellsPositions.Length; i++)
        {
            // Узнаём, нужно ли подниматься на новый ряд ячеек
            bool needUp = i % CellsInRow == 0;

            // Если нужно подниматься на новый ряд:
            if (needUp)
            {
                // Меняем направление движения на противоположное
                right = !right;

                // Позиция ячейки получается путём смещения на высоту одной ячейки вверх
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.up * CellSize.y;
            }

            // Если не нужно подниматься на новый ряд:
            else
            {
                // Определяем знак смещения по горизонтали в зависимости от направления движения
                float xSign = right ? 1 : -1;

                // Смещение по горизонтали равно ширине одной клетки, умноженной на знак смещения
                float deltaX = xSign * CellSize.x;

                // Позиция ячейки определяется, когда мы смещаем её на указанное значение по горизонтали
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.right * deltaX;
            }
        }
    }

    public Vector2 GetCellPosition(int id)
    {
        // Если номер ячейки некорректный
        if (id < 0 || id >= _cellsPositions.Length)
        {
            // Возвращаем нулевые значения (0, 0)
            return Vector2.zero;
        }
        // Иначе возвращаем позицию ячейки
        return _cellsPositions[id];
    }
}
