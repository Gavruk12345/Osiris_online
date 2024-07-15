using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule : MonoBehaviour
{ 
    public float distanceToMove = 5f;  // Відстань, на яку буде пересуватися об'єкт
    public float moveSpeed = 2f;        // Швидкість руху

    private bool isMoving = false;      // Флаг, що показує, чи об'єкт в русі

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (!isMoving)
            {
                // Визначаємо нову кінцеву позицію на відстані distanceToMove вздовж осі X
                Vector3 startPosition = transform.position;
                Vector3 targetPosition = new Vector3(startPosition.x + distanceToMove, startPosition.y, startPosition.z);

                // Запускаємо рух об'єкта в напрямку кінцевої позиції
                StartCoroutine(MoveObject(targetPosition));
            }
        }
    }

    IEnumerator MoveObject(Vector3 targetPosition)
    {
        isMoving = true;

        while (transform.position != targetPosition)
        {
            // Плавно рухаємо об'єкт в напрямку кінцевої позиції з вказаною швидкістю
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            yield return null;
        }

        isMoving = false;
    }
}
