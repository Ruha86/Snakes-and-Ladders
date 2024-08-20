using TMPro;
using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    // Количество игроков
    public int PlayersCount = 2;

    // Скрипт создания фишек
    public PlayersChipsCreator PlayersChipsCreator;

    // Скрипт смены хода игроков
    public PlayersTurnChanger PlayersTurnChanger;

    // Скрипт перемещения фишек
    public PlayersChipsMover PlayersChipsMover;

    // Скрипт игрового поля
    public GameField GameField;

    // Экран игры
    public GameObject GameScreenGO;

    // Экран конца игры
    public GameObject GameEndScreenGO;

    // Надпись о победе
    public TextMeshProUGUI WinText;

    public void DoPlayerTurn(int steps)
    {
        // Этот код уже был
        int currentPlayerId = PlayersTurnChanger.GetCurrentPlayerId();
        PlayersChipsMover.MoveChip(currentPlayerId, steps);

        // Отсюда начинается новый код
        // Проверяем, достиг ли игрок финиша
        bool isPlayerFinished = PlayersChipsMover.CheckPlayerFinished(currentPlayerId);

        // Если игрок на финише
        if (isPlayerFinished)
        {
            // Устанавливаем надпись о победе
            SetWinText(currentPlayerId);

            // Переходим к экрану конца игры
            EndGame();
        }
        // Иначе
        else
        {
            // Передаём ход следующему игроку
            PlayersTurnChanger.MovePlayerTurn();
        }
    }

    // Метод для начала новой игры
    private void StartGame()
    {
        // Создаём фишки игроков и сохраняем их в массиве
        PlayerChip[] playersChips = PlayersChipsCreator.SpawnPlayersChips(PlayersCount);

        // Передаём массив фишек в скрипт PlayersTurnChanger
        PlayersTurnChanger.StartGame(playersChips);

        // Передаём массив фишек в скрипт PlayersChipsMover
        PlayersChipsMover.StartGame(playersChips);

        // Показываем экран игры
        SetScreens(true);
    }

    // Метод для перезапуска по кнопке
    public void RestartGame()
    {
        // Удаляем фишки игроков
        PlayersChipsCreator.Clear();

        // Начинаем новую игру
        StartGame();
    }

    // Вызывается при запуске игры
    private void Start()
    {
        // Делаем первичную настройку игры
        FirstStartGame();
    }

    // Метод для первого запуска игры 
    private void FirstStartGame()
    {
        // Заполняем позиции клеток на игровом поле
        GameField.FillCellsPositions();

        // Начинаем новую игру 
        StartGame();
    }

    // Метод для завершения игры
    private void EndGame()
    {
        // Показываем экран конца игры
        SetScreens(false);
    }

    // Метод для установки видимости игровых экранов
    private void SetScreens(bool inGame)
    {
        // Если игра в процессе, показываем экран игры и скрываем экран конца игры
        GameScreenGO.SetActive(inGame);

        // Иначе скрываем экран игры и показываем экран конца игры 
        GameEndScreenGO.SetActive(!inGame);
    }

    // Метод для установки надписи о победе
    private void SetWinText(int playerId)
    {
        // Отображаем текст с номером победившего игрока
        WinText.text = $"Игрок {playerId + 1} победил!";
    }
}