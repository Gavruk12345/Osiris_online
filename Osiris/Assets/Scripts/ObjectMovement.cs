using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5.0f; // Швидкість руху об'єктів
    public float distance = 10.0f; // Дальність руху об'єктів
    public float frequency = 2.0f; // Частота циклічності

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float time = Time.time;
        float newPosition = Mathf.PingPong(time * frequency * speed, distance);

        transform.position = initialPosition + new Vector3(newPosition, 0f, 0f);
    }
}
