using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    #region Singleton
    static CharacterManager instance;
    public static CharacterManager Get()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private List<Character> characters = new List<Character>();

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }
    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);
    }

    public Character[] GetCharacters()
    {
        return characters.ToArray();
    }
}
