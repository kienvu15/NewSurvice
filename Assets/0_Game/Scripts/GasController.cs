using UnityEngine;

public class GasController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnGas = Instantiate(prefab);
        spawnGas.transform.position = transform.position;
        spawnGas.transform.parent = transform;
    }
}
