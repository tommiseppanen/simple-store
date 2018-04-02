using System;
using Models;
using ModestTree;
using Plugins.SimpleStore;
using UniRx;
using UnityEngine;
using Zenject;
using System.Linq;

namespace Presenters
{
    public class InvetoryPresenter : MonoBehaviour
    {
        private GameCharacter _gameCharacter;
        private IStoreService _storeService;

        [SerializeField]
        private Transform _itemPanelPrefab;

        [Inject]
        public void Init(GameCharacter character, Store storeService)
        {
            _gameCharacter = character;
            _storeService = storeService;
        }

        private void UpdateSelection()
        {
            _storeService.SetItemPurchasePrices(_gameCharacter.PlayerInventory);
            _gameCharacter.PlayerInventory?.OrderBy(i => i.Image)
                .ThenBy(i => i.NormalPrice).ForEach(i => 
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));
        }

        private void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panelPrefab = tileObject.GetComponent<ItemPresenter>();
            panelPrefab.ItemData = item;
            var topAction = new Tuple<string, Action<Unit>>("Wear",
                _ =>
                {
                    _gameCharacter.Wear(item);
                });
            var bottomAction = new Tuple<string, Action<Unit>>("Sell",
                _ =>
                {
                    _storeService.Sell(item, _gameCharacter);
                    Destroy(tileObject.gameObject);
                });
            panelPrefab.Init(topAction, bottomAction, 
                _gameCharacter.WearedItem.Select(_ => _gameCharacter.IsWearing(item)));
        }

        void Start ()
        {
            UpdateSelection();
            _gameCharacter.PlayerInventory.ObserveAdd().Subscribe(_ =>
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
                UpdateSelection();
            });
        }
    }
}
