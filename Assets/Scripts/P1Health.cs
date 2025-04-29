using UnityEngine;
using UnityEngine.UI;

public class P1Health : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float maxHealth;

    private Animator animator;
    public Image healthBar;

    // assign this in the inspector
    public MovementP1 movementP1;

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
            animator.SetTrigger("P1Dmg");
            animator.SetBool("isAttack3", false);
        }

        if (health <= 0f)
        {
            animator.SetBool("P1Dead", true);

            // disable movement and zero velocity
            if (movementP1 != null && movementP1.enabled)
            {
                movementP1.enabled = false;
                var rb = movementP1.GetComponent<Rigidbody2D>();
                if (rb != null) rb.linearVelocity = Vector2.zero;
            }
        }

        if (health > maxHealth)
            health = maxHealth;
    }
}
