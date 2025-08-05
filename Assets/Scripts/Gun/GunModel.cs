[System.Serializable]
public class GunModel
{
    public int Damage = 25;
    public float TimeOfRecherge;
    public int AmmoNumber = 30;
    public int ReloadBullets;
    public int MaxAmmo;

    public bool CanShoot => AmmoNumber > 0;

    public void Reload()
    {
        int difference = MaxAmmo - AmmoNumber;
        int toload = UnityEngine.Mathf.Min(difference, ReloadBullets);
        AmmoNumber += toload;
        ReloadBullets -= toload;
    }
}