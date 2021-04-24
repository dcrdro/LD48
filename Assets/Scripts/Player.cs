using System;
using UnityEngine;

    public class Player : MonoBehaviour
    {
        public float moveSpeed = 1f;
        
        void Update()
        {
            float hor = Input.GetAxis("Horizontal");

            transform.position += Vector3.right * hor * moveSpeed * Time.deltaTime;
        }
    }
