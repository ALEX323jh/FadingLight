using UnityEngine;

public class EnemyPatrole : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement")]
    [SerializeField] private float speed;
    private Vector3 initscale;
    private bool movingLeft;

    [SerializeField]private Animator anim;

    [SerializeField] private float idlee;
    private float idleTimer;

    private void Awake()
    {
        initscale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("moveing", false);
    }

    private void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                Directionchange();
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
            MoveInDirection(1);
            else
            {
                Directionchange();
            }
        }
    }

    private void Directionchange()
    {
        anim.SetBool("moveing", false);

        idleTimer += Time.deltaTime;

        if(idleTimer >= idlee)
        {
            movingLeft = !movingLeft;
        }

        
    }

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        anim.SetBool("moveing", true);
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x) * direction, initscale.y, initscale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction *speed, enemy.position.y, enemy.position.z);
    }
}
