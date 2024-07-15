using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class ActivateLightOnCollision : MonoBehaviour
{
    public Light2D lightSpriteRenderer; // Посилання на SpriteRenderer для світла, яке потрібно активувати

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Перевіряємо, чи торкнулись ми колізії типу Tilemap
        if (collision.gameObject.GetComponent<Tilemap>() != null)
        {
            // Активуємо SpriteRenderer світла
            lightSpriteRenderer.enabled = true;
        }
    }
}
