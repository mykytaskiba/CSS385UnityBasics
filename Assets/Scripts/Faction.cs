using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Faction")]
public class Faction : ScriptableObject
{
    [SerializeField]
    private string factionName;

    [SerializeField]
    private Faction[] enemies;

    public bool isEnemy(Faction other)
    {
        foreach (Faction faction in enemies)
        {
            if (faction == other)
            {
                return true;
            }
        }
        return false;
    }

    private void addEnemy(Faction other)
    {
        Faction[] newEnemies = new Faction[enemies.Length+1];
        for (int i = 0; i < enemies.Length; i++)
        {
            newEnemies[i] = enemies[i];
        }
        newEnemies[enemies.Length] = other;

        enemies = newEnemies;
    }

    private void OnValidate()
    {
        foreach (Faction faction in enemies)
        {
           if (!faction.isEnemy(this))
            {
                faction.addEnemy(this);
            }
        }
    }
}
