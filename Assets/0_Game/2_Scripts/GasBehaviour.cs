using UnityEngine;
using System.Collections.Generic;

public class GasBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);

            markedEnemies.Add(other.gameObject);
        }
        else if (other.CompareTag("Prop") && !markedEnemies.Contains(other.gameObject))
        {
            if (other.gameObject.TryGetComponent(out BreakableProp breakable))
            {
                breakable.TakeDamage(currentDamage);
                markedEnemies.Add(other.gameObject);
            }
        }
    }
}
