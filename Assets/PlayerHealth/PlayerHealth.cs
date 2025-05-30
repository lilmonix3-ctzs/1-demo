using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("血量设置")]
    public int maxHealth = 100;       // 最大生命值
    public int currentHealth;         // 当前生命值

    [Header("血条UI引用")]
    public Slider healthSlider;       // 血条Slider组件
    public Image fillImage;           // 血条填充图像
    public Color fullHealthColor = Color.green;   // 满血颜色
    public Color zeroHealthColor = Color.red;     // 空血颜色

    void Start()
    {
        // 初始化血条
        healthSlider.value = 1;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // 受到伤害
    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 恢复生命值
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        UpdateHealthUI();
    }

    // 更新血条UI
    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }

        if (fillImage != null)
        {
            // 根据血量比例渐变颜色
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor,
                                         (float)currentHealth / maxHealth);
        }
    }

    // 死亡处理
    void Die()
    {
        Debug.Log("玩家死亡!");
        
    }
    public void TakeDamage(float percent)
    {
        healthSlider.value -= percent;
    }

}

