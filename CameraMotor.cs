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
        // pozycja lookAt(np gracz) - pozycja kamery(centrum kamery domyœlne) - ró¿nica miêdzy graczem a kamer¹
        float deltaX = lookAt.position.x - transform.position.x;
        // jeœli róznica przekroczy³a granicê
        if (deltaX > boundX || deltaX < -boundX)
        {
            // jesli gracz pooszed³ w prawo
            if (transform.position.x < lookAt.position.x)
            {
                // wektor delta.x = od ró¿nicy pozycji odejmij granicê ; wektor wyrównuj¹cy
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
