using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.SimpleStore;
using Assets.Scripts.Models;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class StoreController : MonoBehaviour
    {

        private IStoreService _storeService;
        private GameCharacter _gameCharacter;

        private ReactiveCollection<IStoreItem> _storeItems;

        [SerializeField]
        private Transform _itemPanelPrefab;

        [Inject]
        public void Init(IStoreService storeService, GameCharacter character)
        {
            _storeService = storeService;
            _gameCharacter = character;
        }

        private void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panelPrefab = tileObject.GetComponent<ItemViewModel>();
            panelPrefab.ItemData = item;
            panelPrefab.Init(this);
        }


        // Use this for initialization
        void Start ()
        {
            _storeItems = _storeService.GenerateItems().ToReactiveCollection();
            _storeItems.ForEach(i =>
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));
            _gameCharacter.PlayerCoins.ObserveEveryValueChanged(x => x.Value).Subscribe(d => Debug.Log(d));
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void BuyAndWear(IStoreItem item)
        {         
            _storeService.Buy(item, _storeItems, _gameCharacter);
        }
    }
}
