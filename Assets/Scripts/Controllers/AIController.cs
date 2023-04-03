using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    private Character character;
    private Faction faction;
    private RotationMode rotation;
    private MovementMode movement;
    private Item weapon;

    public override void setCharacter(Character character)
    {
        this.character = character;
        Validate();
    }

    public override void Validate()
    {
        rotation = character.getRotation();
        movement = character.getMovement();
        weapon = character.GetElement<Item>();
        faction = character.getFaction();
    }

    Character target;
    private void Update()
    {
        if (target == null)
        {
            target = findClosestEnemy();
        }
        if (target != null)
        {
            movement.Move(target.transform.position-character.transform.position);
            rotation.RotateTowards(target.transform.position);
            
            if (weapon != null)
            {
                weapon.Primary();
                weapon.PrimaryContinous();
            }
        }
    }

    //return true if character1 is closer than character2
    bool closer(Character character1, Character character2)
    {
        return (distanceTo(character1) < distanceTo(character2));
    }

    float distanceTo(Character other)
    {
        return (other.transform.position - character.transform.position).magnitude;
    }
    Character findClosestEnemy()
    {
        Character closestEnemy = null;
        Character[] allCharacters = CharacterManager.Get().GetCharacters();
        foreach (Character character in allCharacters)
        {
            if (faction.isEnemy(character.getFaction())) {
                if (closestEnemy == null || closer(character,closestEnemy))
                {
                    closestEnemy = character;
                }
            }
        }
        return closestEnemy;
    }
}
