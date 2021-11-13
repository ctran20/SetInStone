using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] AudioSource hurt;

    private void DisplayHealth()
    {
        healthText.text = hitPoints.ToString();
    }
    public void TakeDamage(float damage)
    {
        DisplayHealth();
        GetComponent<DisplayDamage>().ShowDamageImpact();
        hitPoints -= damage;
        hurt.Play();
        if (hitPoints < 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
            AudioManager.PlaySound("lose", 0.5f, 0.6f);
        }
    }
}
