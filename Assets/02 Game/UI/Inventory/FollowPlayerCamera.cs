using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform Player; // Przypisz obiekt gracza w inspektorze Unity
    public Vector3 Offset; // Dystans mi�dzy graczem a kamer�
    public float SmoothSpeed = 0.125f; // Szybko��, z jak� kamera pod��a za graczem

    void Start()
    {
        // Sprawd�, czy obiekt gracza zosta� przypisany
        if (Player == null)
        {
            Debug.LogError("Obiekt Player nie jest przypisany. Przypisz obiekt gracza w inspektorze Unity.");
        }
    }

    void LateUpdate()
    {
        // Je�li obiekt gracza nie jest przypisany, nie aktualizuj pozycji kamery
        if (Player == null)
        {
            return;
        }

        // Oblicz now� pozycj� kamery
        Vector3 desiredPosition = Player.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = smoothedPosition;

        // Skieruj kamer� ku przodowi gracza
        transform.LookAt(Player);
    }
}

