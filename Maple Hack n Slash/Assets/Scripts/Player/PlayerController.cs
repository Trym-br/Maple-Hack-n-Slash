using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public float Score = 0f;
    private bool Alive = true;
    public float moveSpeed = 5f;
    public float jumpSpeed = 4f;
    public float attackSpeed = 0.2f;

    private float attackTimer = 0;

    public UIController healthUI;
    
    private InputActions _input;
    private Rigidbody2D _rigidbody2D;
    private Health _health;
    private Animator _animator;
    
    private GameObject _axe;
    private Animator _axeAnimator;
    private BoxCollider2D _axeHitbox;

    private void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        
        _axe = transform.Find("Weapon").gameObject;
        _axeAnimator = _axe.GetComponent<Animator>();
        _axeHitbox = _axe.GetComponent<BoxCollider2D>();
        _axeHitbox.enabled = false;
    }

    private void FixedUpdate()
    {
        if (Alive)
        {
            // _rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
            // _rigidbody2D.linearVelocityY = _input.Vertical * moveSpeed;
            _rigidbody2D.linearVelocity = (new Vector2(_input.Horizontal, _input.Vertical).normalized * moveSpeed +
                                           _rigidbody2D.linearVelocity) / 2;
            _animator.SetFloat("Horizontal", _rigidbody2D.linearVelocity.x);
            _animator.SetFloat("Vertical", _rigidbody2D.linearVelocity.y);
        }
    }

    private float axeAngle = 0f;
    private void Update()
    {
        if (Alive)
        {
            AxeFollowRotation();
            if (_input.Attack && attackTimer <= 0)
            {
                // Swing axe
                attackTimer = attackSpeed;
                _axeHitbox.enabled = true;
                _axeAnimator.Play("Axe swing");
                StartCoroutine(AttackAnimationDoneCallback());
            }

            attackTimer -= Time.deltaTime;
        }
    }

    public void TakesDamage()
    {
        Debug.Log("Took Damange / HP: " + _health.hp);
        healthUI.SetHealth();
    }
    IEnumerator AttackAnimationDoneCallback()
    {
        // Wait until the animation finishes
        yield return new WaitForSeconds(_axeAnimator.GetCurrentAnimatorStateInfo(0).length);
        _axeHitbox.enabled = false;
    }

    public void Dies()
    {
        healthUI.SetHealth();
        _axe.GetComponent<SpriteRenderer>().enabled = false;
        _animator.SetBool("Dead", true);
        Alive = false;
    }

    private void AxeFollowRotation()
    {
        // angle / rotation
        if (_input.Vertical != 0 || _input.Horizontal != 0)
        {
            int flipaxe = (_input.SecondaryAction ? 180 : 0);
            // Debug.Log("flip axe: " + flipaxe);
            axeAngle = flipaxe + Mathf.Round(
                (Mathf.Atan2(_input.Vertical, _input.Horizontal) * Mathf.Rad2Deg)/ 45f ) * 45f - 90f;
        }
        else
        {
            axeAngle = 0f;
        }
        _axe.transform.eulerAngles = new Vector3(0, 0, axeAngle);
    }
}

