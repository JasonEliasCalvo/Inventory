using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSystem : MonoBehaviour
{
    [SerializeField] private int maxHeald;
    [SerializeField] private int currentHeald;

    public void ReciveHeal(int heal)
    {
        currentHeald += heal;

        if (currentHeald > maxHeald)
        {
            currentHeald = maxHeald;
        }
    }

    public void ReciveDamage(int damage)
    {
        currentHeald -= damage;

        if (currentHeald <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
        Debug.Log("Murio");
    }
}
