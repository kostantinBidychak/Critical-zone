using TMPro;
using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _ammoNumber;

    public void SpawnBullet(GameObject gameObject, int ammoNumber)
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
        _ammoNumber.text = ammoNumber.ToString();
    }
    public void DestroyBullet(GameObject gameObject) => Destroy(gameObject);
    public void ReloadAmmoText(int  numberReloadAmmo) => _ammoText.text =  numberReloadAmmo.ToString();

}
