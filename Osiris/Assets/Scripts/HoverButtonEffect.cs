using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverButtonEffect : MonoBehaviour

{
    public float hoverScale = 1.2f; // Множник масштабування при наведенні
    public float hoverSpeed = 5f; // Швидкість анімації наведення

    private Vector3 originalScale; // Початковий розмір кнопки
    private bool isHovering = false; // Прапорець, що показує, чи наведений курсор на кнопку

    private void Start()
    {
        // Зберегти початковий розмір кнопки
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Перевірка, чи курсор наведений на кнопку
        if (isHovering)
        {
            // Збільшення розміру кнопки
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * hoverScale, Time.deltaTime * hoverSpeed);
        }
        else
        {
            // Зменшення розміру кнопки до початкового розміру
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * hoverSpeed);
        }
    }

    public void OnPointerEnter()
    {
        isHovering = true; // Курсор наведений на кнопку
    }

    public void OnPointerExit()
    {
        isHovering = false; // Курсор покинув кнопку
    }
}
