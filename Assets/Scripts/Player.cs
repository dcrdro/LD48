using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
    {
        public Transform parent;
        public float moveSpeed = 7f;
        public bool enableControl = true;
        public Animator animator;

        public AudioClip[] footsteps;
        
        private bool facingRight = true;
        private Vector3 velocity;
        
        void Update()
        {
            if (!enableControl) return;
            
            float hor = Input.GetAxis("Horizontal");

            velocity = Vector3.right * hor;
            animator.SetFloat("Velocity", Mathf.Abs(velocity.x));
            parent.position += velocity * (moveSpeed * Time.deltaTime);

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

        private void Footstep()
        {
            AudioSystem.Instance.PlaySound(footsteps[Random.Range(0, 2)]);
        }
    }
