using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranManager : MonoBehaviour
{
    /*
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;

    private void Start()
    {
        _startingSceneTransition.SetActive(true);
        FunctionTimer.Create(DisableStartingSceneTransition, timer: 5);
    }

    private void DisableStartingSceneTransition()
    {
        _startingSceneTransition.SetActive(false);
    }

    // Метод, який буде викликатися при натисканні на кнопку
    public void ButtonPressed()
    {
        // Викликаємо метод для переходу на нову сцену
        StartCoroutine(TransitionToNextScene());
    }

    // Корутин для здійснення плавного переходу між сценами
    private IEnumerator TransitionToNextScene()
    {
        // Активуємо ефект переходу до наступної сцени
        _endingSceneTransition.SetActive(true);

        // Очікуємо короткий проміжок часу перед переходом на нову сцену
        yield return new WaitForSeconds(2f);

        // Завантажуємо наступну сцену (замініть "NextScene" із назвою вашої сцени)
        SceneManager.LoadScene("NextScene");

        // Після завантаження нової сцени, деактивуємо ефект переходу
        _endingSceneTransition.SetActive(false);
    }*/
}
