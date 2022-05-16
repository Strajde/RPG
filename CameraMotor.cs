using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    public void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        // pozycja lookAt(np gracz) - pozycja kamery(centrum kamery domy�lne) - r�nica mi�dzy graczem a kamer�
        float deltaX = lookAt.position.x - transform.position.x;
        // je�li r�znica przekroczy�a granic�
        if (deltaX > boundX || deltaX < -boundX)
        {
            // jesli gracz pooszed� w prawo
            if (transform.position.x < lookAt.position.x)
            {
                // wektor delta.x = od r�nicy pozycji odejmij granic� ; wektor wyr�wnuj�cy
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        // To samo dla osi Y
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }

        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

}
