using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptsableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptsableObject : ScriptableObject
{
    [SerializeField] GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] float might;
    public float Might { get => Might; private set => Might = value; }

    [SerializeField] float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }

    [SerializeField] float magnet;
    public float Magnet { get => magnet; private set => magnet = value; }
}
