using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Health : MonoBehaviour
{
    [SerializeField]private float startingHealth;
    [SerializeField] private float startingLight;
    private Animator anim;
    public float currentHealth { get; private set; }
    public float currentLight { get; private set; }
    private bool dead;

    public Light2D lightt;

    private void Awake()
    {
        currentHealth = startingHealth;
        currentLight = startingLight;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                if(GetComponent<PlaerMovement>() != null)
                    GetComponent<PlaerMovement>().enabled = false;
                if(GetComponentInParent<EnemyPatrole>()!=null)
                    GetComponentInParent<EnemyPatrole>().enabled = false;
                if(GetComponent<MeleEnemy>() != null)
                    GetComponent<MeleEnemy>().enabled = false;

                dead = true;
            }
            
        }
    }


    public void TakeLight(float _lightt)
    {
        currentLight = Mathf.Clamp(currentLight - _lightt, 0, startingLight);
        lightt.intensity = currentLight / 10 * 3;

        if(currentLight <= 0 && !dead)
        {
            anim.SetTrigger("die");
            GetComponent<PlaerMovement>().enabled = false;
            dead = true;
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
            TakeLight(1);
    }
}
