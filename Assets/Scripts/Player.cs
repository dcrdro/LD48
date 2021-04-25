using System;
using UnityEngine;

    public class Player : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public bool enableControl = true;
        public Animator animator;
        
        private bool facingRight = true;
        private Vector3 velocity;

        void Update()
        {
            if (!enableControl) return;
            
            float hor = Input.GetAxis("Horizontal");

            velocity = Vector3.right * hor;
            animator.SetFloat("Velocity", Mathf.Abs(velocity.x));
            transform.position += velocity * (moveSpeed * Time.deltaTime);

            if (velocity.x < 0 && facingRight)
            {
                facingRight = false;
                Flip();
            }
            else if (velocity.x > 0 && !facingRight)
            {
                facingRight = true;
                Flip();
            }
        }

        private void Flip()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
