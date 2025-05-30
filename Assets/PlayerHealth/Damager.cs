using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int testDamage = 10;

    void Update()
    {
        // ��H������
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth.Heal(10);
        }

        // ��D������˺�
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerHealth.TakeDamage(testDamage);
        }
    }
}
