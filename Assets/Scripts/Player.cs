using System;
using DG.Tweening;
using Dialogues;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public Transform parent;
    public float moveSpeed = 7f;
    public bool enableControl = true;
    public Animator animator;

    public AudioClip[] footsteps;
    public BoxCollider2D coll;
    private bool facingRight = true;
    private Vector3 velocity;

    [Serializable]
    public class PartConfig
    {
        public SpriteRenderer rend;
        public Sprite sprite;
        public Vector3 pos;
    }

    public PartConfig pigHeadPart;
    public PartConfig pigBodyPart;
    public PartConfig pigLHandPart;
    public PartConfig pigRHandPart;
    public PartConfig pigLLegPart;
    public PartConfig pigRLegPart;
    
    public PartConfig pigChemodan;

    public Vector2 colPos, colSize;

    private void Start()
    {
        // Dialoguer.Instance.Show(DialogID.wake_up);
    }

    public void DisableControl()
    {
        enableControl = false;
        velocity = Vector3.zero;
        animator.SetFloat("Velocity", Mathf.Abs(velocity.x));
    }

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
        
        UpdateSwitch();
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Footstep()
    {
        AudioSystem.Instance.PlaySound(footsteps[Random.Range(0, footsteps.Length)]);
    }

    void UpdateSwitch()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     ApplyPart(pigHeadPart);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     ApplyBody();
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     ApplyLeftHand();
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha4))
        // {
        //     ApplyPart(pigRHandPart);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha5))
        // {
        //     ApplyPart(pigLLegPart);
        //     coll.offset = colPos;
        //     coll.size = colSize;
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha6))
        // {
        //     ApplyPart(pigRLegPart);
        //     coll.offset = colPos;
        //     coll.size = colSize;
        // }
        
    }

    public void DoApplyHead()
    {
        ApplyPart(pigHeadPart);
    }
    public void DoApplyBody()
    {
        ApplyBody();
    }
    public void DoApplyLHand()
    {
        ApplyLeftHand();
    }
    public void DoApplyRHand()
    {
        ApplyPart(pigRHandPart);
    }
    public void DoApplyLLeg()
    {
        ApplyPart(pigLLegPart);
        coll.offset = colPos;
        coll.size = colSize;
    }
    public void DoApplyRLeg()
    {
        ApplyPart(pigRLegPart);
        coll.offset = colPos;
        coll.size = colSize;
    }

    void ApplyBody()
    {
        ApplyPart(pigBodyPart);
        pigLLegPart.rend.transform.localPosition = pigLLegPart.pos;
        pigRLegPart.rend.transform.localPosition = pigRLegPart.pos;
        pigLHandPart.rend.transform.localPosition = pigLHandPart.pos;
        pigRHandPart.rend.transform.localPosition = pigRHandPart.pos;

    }

    void ApplyLeftHand()
    {
        ApplyPart(pigLHandPart);
        ApplyPart(pigChemodan);
    }
    
    void ApplyPart(PartConfig part)
    {
        part.rend.sprite = part.sprite;
        part.rend.transform.localPosition = part.pos;
        part.rend.transform.DOPunchScale(Vector3.one * 1.05f, 0.55f, 6);
    }

}
