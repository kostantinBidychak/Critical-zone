using TMPro;
using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _ammoNumber;

    public void BulletText( int ammoNumber)
    {
      //  Instantiate(gameObject, transform.position, Quaternion.identity);
        _ammoNumber.text = ammoNumber.ToString();
    }
    public void ReloadAmmoText(int  numberReloadAmmo) => _ammoText.text =  numberReloadAmmo.ToString();
}
