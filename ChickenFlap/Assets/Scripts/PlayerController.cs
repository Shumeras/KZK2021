using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool canCantrol = true;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;

    public ParticleSystem particleSystem = null;

    private float jumpCooldownRemaining = 0;

    public Rigidbody2D Rigidbody { get; private set; }
    public Collider2D Collider { get; private set; }
    public Animator Animator { get; set; }

    private void Awake() {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Blinking());
    }

    private void FixedUpdate() {

        if(jumpCooldownRemaining > 0 )
        {
            jumpCooldownRemaining -= Time.fixedDeltaTime;
        }

        if(Input.GetAxis("Jump") >= 1 && jumpCooldownRemaining <= 0 && canCantrol)
        {
            Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // Debug.Log("Jump");
            Animator.SetTrigger("Flap");
            Invoke("ResetTrigger", 0.1f);
            jumpCooldownRemaining = jumpCooldown;
        }
    }

    private void ResetTrigger()
    {
        Animator.ResetTrigger("Flap");
    }

    private IEnumerator Blinking()
    {

        while(canCantrol)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            
            Animator.SetTrigger("Blink");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Obstacle")
        {
            Die();
        } 
    }

    private void Die()
    {
        particleSystem.Emit(100);
        canCantrol = false;
        Rigidbody.AddForce(new Vector2(-1, 1).normalized * Random.Range(5f, 10f), ForceMode2D.Impulse);
        Collider.enabled = false;
        GameController.Instance.GameEnd();
        // Debug.Log("Died");
    }

}
