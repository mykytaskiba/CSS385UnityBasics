using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : ItemElement
{

    [SerializeField]
    private ItemBase ammoType;

    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private SoundProfile shootSound;

    [SerializeField]
    private float firerate;

    float lastFireTime = -1;

    void Fire()
    {
        //Not enough time passed
        if (Time.time - lastFireTime < firerate)
        {
            return;
        }

        if (!UseAmmo())
        {
            return;
        }


        lastFireTime = Time.time;

        GameObject clone = GameObject.Instantiate(bulletPrefab);
        clone.transform.position = bulletSpawnPoint.position;
        clone.transform.rotation = transform.rotation;

        SoundManager.Get().playSound(shootSound, transform.position);

        character.Validate();
    }

    bool UseAmmo()
    {
        ItemInstance ammoItem = character.GetInventory().GetItemOfType(ammoType);
        if (ammoItem == null)
        {
            return false;
        }
        QuantifiableInstance ammoQuantifiable = ammoItem as QuantifiableInstance;

        return (ammoQuantifiable.Decrement());
    }

    bool firing = false;
    public override void onPrimaryDown()
    {
        firing = true;
    }

    public override void onPrimaryUp()
    {
        firing = false;
    }

    private void Update()
    {
        if (firing)
        {
            Fire();
        }
    }

    protected override void onAttach()
    {
        base.onAttach();
        lastFireTime = Time.time;
    }

}
