
[System.Serializable]
public class GunModelScript
{
   public float Damage;
   public float TimeOfRecherge;
   public int AmmoNumber;
   public int ReloadBullets;
   public int MaxAmmo;

   public bool CanShoot => AmmoNumber > 0;

    public void Reload()
    {
      int differemce = MaxAmmo - AmmoNumber;
      AmmoNumber += differemce;
      ReloadBullets -= differemce;
    }
}