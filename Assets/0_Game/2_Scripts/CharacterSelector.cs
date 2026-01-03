using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public CharacterScriptsableObject characterData;

    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static CharacterScriptsableObject GetData()
    {
        return instance.characterData;
    }

    public void SelectCharacter(CharacterScriptsableObject character)
    {
        characterData = character;
    }

    public void DestroySingletion()
    {
        instance = null;
        Destroy(gameObject);
    }
}
