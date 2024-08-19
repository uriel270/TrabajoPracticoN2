using System;
using UnityEngine;

namespace Clase1
{
    public class Movement : MonoBehaviour
    {
        public float movementSpeed = 0.01f;
        [SerializeField] private KeyCode keyUp = KeyCode.W;
        [SerializeField] private KeyCode keyLeft = KeyCode.A;
        [SerializeField] private KeyCode keyDown = KeyCode.S;
        [SerializeField] private KeyCode keyRight = KeyCode.D;
        [SerializeField] private float rotation = 10f;

         void Update()
         { 
            Vector3 pos = transform.position;


             if (Input.GetKey(keyUp)) 
            {
                pos.y += movementSpeed;

                Debug.Log("W");
            }

            if (Input.GetKey(keyLeft))
            {
                pos.x -= movementSpeed;

                Debug.Log("A");
            }

            if (Input.GetKey(keyDown))
            {
                pos.y -= movementSpeed;
            
                Debug.Log("S");
            }

            if (Input.GetKey(keyRight))
            {
                pos.x += movementSpeed;

                Debug.Log("D");
            }

                 transform.position = pos;
       
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.Rotate(Vector3.forward, rotation);

                Debug.Log("Q");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(Vector3.forward, -rotation);

                Debug.Log("E");
            }

         }

        public void setMovementSpeed(float newSpeed)
        {
            if (newSpeed > 1)
                return;
            movementSpeed += newSpeed;
        }

    }
}

