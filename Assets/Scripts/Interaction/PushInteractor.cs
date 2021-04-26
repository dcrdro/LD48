using UnityEngine;
using DG.Tweening;

    public class PushInteractor : InteractorBase
    {
        public float force;
        
        public override void OnInteract()
        {
            GetComponent<Rigidbody2D>().isKinematic = false;

            var player = FindObjectOfType<Player>();
            var dist = player.transform.position - transform.position;
            dist.y = Mathf.Abs(dist.y);
            GetComponent<Rigidbody2D>().AddForce(-dist.normalized * force);
            GetComponent<Rigidbody2D>().AddTorque(Mathf.Sign(-dist.sqrMagnitude) * force * 0.5f);
        }

        public override string Name => "";
    }
