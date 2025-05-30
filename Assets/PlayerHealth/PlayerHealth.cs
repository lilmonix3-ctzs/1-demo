using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Ѫ������")]
    public int maxHealth = 100;       // �������ֵ
    public int currentHealth;         // ��ǰ����ֵ

    [Header("Ѫ��UI����")]
    public Slider healthSlider;       // Ѫ��Slider���
    public Image fillImage;           // Ѫ�����ͼ��
    public Color fullHealthColor = Color.green;   // ��Ѫ��ɫ
    public Color zeroHealthColor = Color.red;     // ��Ѫ��ɫ

    void Start()
    {
        // ��ʼ��Ѫ��
        healthSlider.value = 1;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // �ܵ��˺�
    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // �ָ�����ֵ
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        UpdateHealthUI();
    }

    // ����Ѫ��UI
    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }

        if (fillImage != null)
        {
            // ����Ѫ������������ɫ
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor,
                                         (float)currentHealth / maxHealth);
        }
    }

    // ��������
    void Die()
    {
        Debug.Log("�������!");
        
    }
    public void TakeDamage(float percent)
    {
        healthSlider.value -= percent;
    }

}

