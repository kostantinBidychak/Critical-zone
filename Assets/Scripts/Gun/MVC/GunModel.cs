[System.Serializable]
public class GunModel
{
    public int Damage = 25;
    public float TimeOfShoot = 0.1f;
    public int Ammo = 30;
    public int ReloadAmmo = 90;
    public int MaxAmmo = 30;

    public bool CanShoot => Ammo > 0;

    public void Reload()
    {
        int difference = MaxAmmo - Ammo;
        int toload = UnityEngine.Mathf.Min(difference, ReloadAmmo);
        Ammo += toload;
        ReloadAmmo -= toload;
    }
}