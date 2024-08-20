using UnityEngine;

public class GameCube : MonoBehaviour
{
    // Массив с разными углами для каждой стороны кубика
    public Vector3[] CubeSidesEulers;

    public void ShowCube()
    {
        // Делаем кубик видимым
        SetActiveCube(true);
    }

    public void HideCube()
    {
        // Делаем кубик невидимым
        SetActiveCube(false);
    }

    private void SetActiveCube(bool value)
    {
        // Включаем или выключаем отображение кубика в зависимости от переданного значения
        gameObject.SetActive(value);
    }

    public int ThrowCube()
    {
        // Показываем кубик
        ShowCube();

        // Задаём случайное значение для выбора стороны кубика
        int randomCubeValue = Random.Range(0, CubeSidesEulers.Length);

        // Поворачиваем кубик и задаём угол для выбранной стороны
        RotateCube(CubeSidesEulers[randomCubeValue]);

        // Возвращаем в методе значение броска + 1
        return randomCubeValue + 1;
    }

    private void RotateCube(Vector3 cubeEuler)
    {
        // Устанавливаем угол поворота кубика
        transform.eulerAngles = cubeEuler;
    }
}
