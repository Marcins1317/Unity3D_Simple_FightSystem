using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject weapon;
    public GameObject weapon1;
    public GameObject shield;
    public KeyCode[] activateKeys = { KeyCode.Space, KeyCode.Alpha1 };

    private bool isWeaponActive = false;
    private bool isWeapon1Active = false;
    private bool isShieldActive = false;

   

    private void Update()
    {
        foreach (KeyCode key in activateKeys)
        {
            if (Input.GetKeyDown(key))
            {
                ToggleWeapon();
                ToggleWeapon1();
                ToggleShield();
                break;
            }
        }
    }


private void ToggleWeapon1()
    {
        isWeapon1Active = !isWeapon1Active;
        weapon1.SetActive(isWeapon1Active);
        
    }
    private void ToggleWeapon()
    {
        isWeaponActive = !isWeaponActive;
        weapon.SetActive(isWeaponActive);
        
    }
    private void ToggleShield()
    {
        isShieldActive = !isShieldActive;
        shield.SetActive(isShieldActive);

    }

   
}
