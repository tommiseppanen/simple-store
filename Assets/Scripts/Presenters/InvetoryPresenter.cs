using System;
using Assets.Plugins.SimpleStore;
using Assets.Scripts.Models;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Presenters
{
    public class InvetoryPresenter : MonoBehaviour
    {
        private GameCharacter _gameCharacter;
        private IStoreService _storeService;

        [SerializeField]
        private Transform _itemPanelPrefab;

        [Inject]
        public void Init(GameCharacter character, IStoreService storeService)
        {
            _gameCharacter = character;
            _storeService = storeService;
        }

        private void UpdateSelection()
        {
            _storeService.SetItemPurchasePrices(_gameCharacter.PlayerInventory, 0.8m);
            _gameCharacter.PlayerInventory?.ForEach(i => 
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));
        }

        private void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panelPrefab = tileObject.GetComponent<ItemPresenter>();
            panelPrefab.ItemData = item;
            var topAction = new Tuple<string, Action<Unit>>("Wear",
                _ =>
                {
                });
            var bottomAction = new Tuple<string, Action<Unit>>("Sell",
                _ =>
                {
                    _storeService.Sell(item, _gameCharacter.PlayerInventory, _gameCharacter);
                    Destroy(tileObject.gameObject);
                });
            panelPrefab.Init(topAction, bottomAction);
        }


        // Use this for initialization
        void Start ()
        {
            //TODO: ObserveRemove?
            _gameCharacter.PlayerInventory.ObserveAdd()
                .Subscribe(x => InitializePanel(Instantiate(_itemPanelPrefab, transform), x.Value));
            UpdateSelection();
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
