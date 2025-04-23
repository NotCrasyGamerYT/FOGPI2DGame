using UnityEngine;
using UnityEngine.UI;

public class P1Health : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float maxHealth;
    private Animator animator;
    public Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = 100;
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health < currentHealth)
        {
            currentHealth = health;
            animator.SetTrigger("P1Dmg");
            animator.SetBool("isAttack3", false);
        }

        if (health <= 0)
        {
            animator.SetBool("P1Dead", true);
        }

        if (health > 100)
        {
            health = maxHealth;
        }
    }
}
