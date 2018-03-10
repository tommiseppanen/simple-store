using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.SimpleStore;
using Assets.Scripts.Models;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Presenters
{
    public class StorePresenter : MonoBehaviour
    {

        private Store _storeService;
        private GameCharacter _gameCharacter;

        [SerializeField]
        private Transform _itemPanelPrefab;

        [Inject]
        public void Init(Store storeService, GameCharacter character)
        {
            _storeService = storeService;
            _gameCharacter = character;
        }

        private void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panelPrefab = tileObject.GetComponent<ItemPresenter>();
            panelPrefab.ItemData = item;
            var topAction = new Tuple<string, Action<Unit>>("Buy & wear", 
                _ =>
                {
                    _storeService.Buy(item, _gameCharacter);
                    _gameCharacter.Wear(item);
                    Destroy(tileObject.gameObject);
                });
            var bottomAction = new Tuple<string, Action<Unit>>("Buy",
                _ =>
                {
                    _storeService.Buy(item, _gameCharacter);
                    Destroy(tileObject.gameObject);
                });
            panelPrefab.Init(topAction, bottomAction, _gameCharacter.WearedItem);
        }


        // Use this for initialization
        void Start ()
        {
            _storeService.StoreItems.ForEach(i =>
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));

            _storeService.StoreItems.ObserveAdd()
                .Subscribe(i =>
                    InitializePanel(Instantiate(_itemPanelPrefab, transform), i.Value));
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
