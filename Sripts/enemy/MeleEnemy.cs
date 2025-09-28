using UnityEngine;

public class MeleEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float coliderdistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private LayerMask playerMask;
    private float cooldowntimer= Mathf.Infinity;

    private Animator anim;
    private Health playerHealth;

    private EnemyPatrole enemypatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemypatrol = GetComponentInChildren<EnemyPatrole>();
    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if(cooldowntimer>= attackCooldown)
            {
                cooldowntimer = 0;
                anim.SetTrigger("meleAtack");
            }
        }

        if (enemypatrol != null)
        {
            enemypatrol.enabled = !PlayerInSight();
        }
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center + transform.right * range * transform.localScale.x * coliderdistance,new Vector3(box.bounds.size.x * range,box.bounds.size.y,box.bounds.size.z), 0, Vector2.left, 0, playerMask);

        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box.bounds.center + transform.right * range * transform.localScale.x * coliderdistance, new Vector3(box.bounds.size.x * range, box.bounds.size.y, box.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
