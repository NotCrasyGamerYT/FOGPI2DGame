using UnityEngine;
using UnityEngine.UI;

public class P2Health : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float maxHealth;

    private Animator animator;
    public Image healthBar;

    // add this
    public MovementP2 movementP2;

    void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = 100;
        health = maxHealth;
        currentHealth = health;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health < currentHealth)
        {
            currentHealth = health;
            animator.SetTrigger("P2Dmg");
            animator.SetBool("isAttack3", false);
        }

        if (health <= 0f)
        {
            animator.SetBool("P2Dead", true);

            // disable movement and zero velocity
            if (movementP2 != null && movementP2.enabled)
            {
                movementP2.enabled = false;
                var rb = movementP2.GetComponent<Rigidbody2D>();
                if (rb != null) rb.linearVelocity = Vector2.zero;
            }
        }

        if (health > maxHealth)
            health = maxHealth;
    }
}
