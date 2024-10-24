using UnityEngine;
using TMPro;

public class AmmoScript : MonoBehaviour
{
    [SerializeField]
    public int CurrentMagAmmo = 8;
    private int TotalAmmo = 32;

    public TextMeshProUGUI AmmoCount;


    // Start is called before the first frame update
    void Start()
    {
        AmmoCount.text = "Ammo: 8 / 32";
    }


    public void DecMagAmmo(int amount)
    {
        CurrentMagAmmo -= amount;
        AmmoCount.text = "Ammo: " + CurrentMagAmmo.ToString() + " / " + TotalAmmo.ToString();
    }

    public void ReloadAmmo(int magCap)
    {
        int bulletsNeeded = magCap - CurrentMagAmmo;
        int bulletsToReload = Mathf.Min(bulletsNeeded, TotalAmmo);

        TotalAmmo -= bulletsToReload;
        CurrentMagAmmo += bulletsToReload;

        AmmoCount.text = "Ammo: " + CurrentMagAmmo.ToString() + " / " + TotalAmmo.ToString();
    }

    public void maxAmmo(int max)
    {
        TotalAmmo = max;
        CurrentMagAmmo = 8;
        AmmoCount.text = "Ammo: " + CurrentMagAmmo.ToString() + " / " + TotalAmmo.ToString();
    }
}
