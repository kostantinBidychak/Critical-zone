using NUnit.Framework;

public class GunTester
{
    [Test]
    public void WhenReload_AndAmmoIsFull_ThenReloadBulletsShouldNotChange()
    {
      GunModel gunModelScript = new GunModel();
     
        gunModelScript.Reload();

        Assert.AreEqual(30,gunModelScript.AmmoNumber);
        Assert.AreEqual(90, gunModelScript.ReloadBullets);
    }

    [Test]
    public void WhenShoot_AndMaxAmmoIsFull_ThenShootBulletsShouldNotChange()
    {
        GunModel gunModelScript = new GunModel();

        Assert.IsFalse(gunModelScript.CanShoot);
        Assert.AreEqual(30, gunModelScript.MaxAmmo);
    }
}
