using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int testDamage = 10;

    void Update()
    {
        // 按H键治疗
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth.Heal(10);
        }

        // 按D键造成伤害
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerHealth.TakeDamage(testDamage);
        }
    }
}
