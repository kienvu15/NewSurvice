using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptsableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;
    [SerializeField] SpriteFaceDirection spriteFace;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }


    public void DirectionChecker(Vector3 dir)
    {
        direction = dir.normalized;

        // Xoay Object cha để nó di chuyển về hướng đó (Logic 3D)
        float yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, yAngle, 0f);

        // Cập nhật hướng cho Sprite (Logic Visual)
        if (spriteFace != null)
        {
            spriteFace.FaceDirection(direction);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                Debug.Log("GG");
                enemy.TakeDamage(currentDamage);
            }
            else
            {
                Debug.Log("FF");
            }
        }
    }

}
