using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float SeeRange = 10f;
    public float ChaseRange = 5f;
    public float AttackRange = 2f;
    public float RunSpeed = 5f;
    public AudioClip roarSound;

    private Animator animator;
    private Transform player;
    private bool isPlayerInRange;
    private AudioSource audioSource;

    AttackSystem attackSystem;


    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        attackSystem = GetComponent<AttackSystem>();
      
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= SeeRange)
        {
            isPlayerInRange = true;
            Vector3 targetDirection = player.position - transform.position;
            targetDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            animator.SetBool("isRoar", true);

            if (!audioSource.isPlaying)
            {
                audioSource.clip = roarSound;
                audioSource.Play();
            }
        }
        else
        {
            isPlayerInRange = false;
            animator.SetBool("isRoar", false);
            animator.SetBool("isBreath", true);
        }

        if (distanceToPlayer <= ChaseRange && isPlayerInRange && distanceToPlayer > AttackRange)
        {
            Vector3 moveDirection = player.position - transform.position;
            moveDirection.y = 0f;
            moveDirection.Normalize();
            transform.position += moveDirection * RunSpeed * Time.deltaTime;

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (distanceToPlayer <= AttackRange && isPlayerInRange)
        {
            attackSystem.Attack();
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    

    public bool IsInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= AttackRange;
    }

   

    
}
