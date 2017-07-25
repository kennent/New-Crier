using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunContoller : MonoBehaviour
{

    Transform weaponHold;
    public Gun startingGun;
    Gun equippedGun;

	void Start ()
    {
        weaponHold = transform;
        if (startingGun != null)
            EquipGun(startingGun);
	}
	
	
	public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
            Destroy(equippedGun.gameObject);
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if (equippedGun != null)
            equippedGun.Shoot();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
}
