using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform Player; // Przypisz obiekt gracza w inspektorze Unity
    public Vector3 Offset; // Dystans miêdzy graczem a kamer¹
    public float SmoothSpeed = 0.125f; // Szybkoœæ, z jak¹ kamera pod¹¿a za graczem

    void Start()
    {
        // SprawdŸ, czy obiekt gracza zosta³ przypisany
        if (Player == null)
        {
            Debug.LogError("Obiekt Player nie jest przypisany. Przypisz obiekt gracza w inspektorze Unity.");
        }
    }

    void LateUpdate()
    {
        // Jeœli obiekt gracza nie jest przypisany, nie aktualizuj pozycji kamery
        if (Player == null)
        {
            return;
        }

        // Oblicz now¹ pozycjê kamery
        Vector3 desiredPosition = Player.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = smoothedPosition;

        // Skieruj kamerê ku przodowi gracza
        transform.LookAt(Player);
    }
}

