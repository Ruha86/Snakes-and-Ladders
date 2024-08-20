using UnityEngine;

public class GameCubeThrower : MonoBehaviour
{
    // Скрипт изменения состояния игры
    public GameStateChanger GameStateChanger;

    // Префаб для создания кубика
    public GameCube GameCubePrefab;

    // Точка, где будет появляться кубик
    public Transform GameCubePoint;

    // Созданный объект кубика
    private GameCube _gameCube;

    public void ThrowCube()
    {
        // Получаем случайное значение броска кубика
        int cubeValue = _gameCube.ThrowCube();

        // Вызываем метод изменения состояния игры и передаём значение броска кубика
        GameStateChanger.DoPlayerTurn(cubeValue);
    }

    private void Start()
    {
        // Создаём новый кубик при запуске игры
        CreateGameCube();
    }

    private void CreateGameCube()
    {
        // Создаём новый кубик в указанной позиции и с указанным углом вращения
        _gameCube = Instantiate(GameCubePrefab, GameCubePoint.position, GameCubePoint.rotation);

        // Скрываем кубик, чтобы его не было видно в начале игры
        _gameCube.HideCube();
    }
}
