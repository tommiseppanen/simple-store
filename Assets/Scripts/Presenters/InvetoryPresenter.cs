﻿using System;
using Models;
using ModestTree;
using Plugins.SimpleStore;
using UniRx;
using UnityEngine;
using Zenject;

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
