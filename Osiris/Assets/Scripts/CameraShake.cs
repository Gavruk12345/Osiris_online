using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Параметри трясіння камери
    public float shakeMagnitude = 0.5f; // Магнітуда трясіння

    private Vector3 initialPosition; // Початкова позиція камери

    void Start()
    {
        initialPosition = transform.localPosition; // Зберегти початкову позицію камери
    }

    // Метод для запуску корутини тряски камери
    public void Shake(float duration)
    {
        StartCoroutine(ShakeCoroutine(duration)); // Запустити корутину тряски камери з заданою тривалістю
    }

    // Корутина для тряски камери
    IEnumerator ShakeCoroutine(float duration)
    {
        float timeElapsed = 0f; // Час, що пройшов з початку трясіння

        while (timeElapsed < duration)
        {
            // Згенерувати випадковий зсув позиції камери
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;
            // Змінити позицію камери, додавши зсув
            transform.localPosition = initialPosition + shakeOffset;

            timeElapsed += Time.deltaTime; // Оновити час, що пройшов з початку трясіння
            yield return null; // Почекати один кадр
        }

        // Повернути камеру до початкової позиції після завершення тряски
        transform.localPosition = initialPosition;
    }
}
