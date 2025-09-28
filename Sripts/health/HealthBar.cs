using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currenthealthbar;
    [SerializeField] private Image lightbar;

    private void Start()
    {
        currenthealthbar.fillAmount = playerHealth.currentHealth / 10;
        lightbar.fillAmount = playerHealth.currentLight / 10;
    }

    private void Update()
    {
        currenthealthbar.fillAmount = playerHealth.currentHealth / 10;
        lightbar.fillAmount = playerHealth.currentLight / 10;
    }


}
