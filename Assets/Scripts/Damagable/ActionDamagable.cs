using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDamagable : MonoBehaviour, IDamagable
{

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private Action zeroHealthAction;


    float health;
    public void onDamage(float damage)
    {
        health += -damage;
        if (health <= 0)
        {
            zeroHealthAction.onAction();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
