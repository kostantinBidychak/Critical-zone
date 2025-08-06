using TMPro;
using UnityEngine;

[System.Serializable]
public class GunViewScript
{
    [SerializeField] private TextMeshProUGUI _ammoReload;
    [SerializeField] private TextMeshProUGUI _ammoNumber;

    public void BulletText(int ammoNumber) => _ammoNumber.text = ammoNumber.ToString();
    public void ReloadAmmoText(int numberReloadAmmo) => _ammoReload.text = "/" + numberReloadAmmo;
}