using UnityEngine;

[System.Serializable]
public struct Item
{
    public GameObject GameObject;
    public int Price;
    public string Name;
}

public class Shop : MonoBehaviour
{
   [SerializeField] private Item[] _items;
     private Wallet _wallet;
    private ShopUI _shopUI;
    [SerializeField] private Transform _player;

    private int _index;

    [Zenject.Inject]
    private void Constructor(Wallet wallet,ShopUI shopUI)
    {
        _wallet = wallet;
          _shopUI = shopUI;
    }

   public void ToLeft() 
   {
        _index--;
        if (_index < 0) _index = _items.Length - 1;
        _shopUI.SwitchText(_items[_index].Name);
   }

   public void ToRight() 
   {
    _index++;
        if (_index > _items.Length) _index = 0 ;
        _shopUI.SwitchText(_items[_index].Name);
    }

    public void Buy() 
    {
        if (_wallet.Money >= _items[_index].Price)
        {
            GameObject gameObject = Instantiate(_items[_index].GameObject, _player.position, _player.rotation);
            gameObject.transform.SetParent(_player.transform);
            _wallet.SpendMoney(_items[_index].Price);
        }
        else
        {
            Debug.Log("net deneg");
        }

    }
}
