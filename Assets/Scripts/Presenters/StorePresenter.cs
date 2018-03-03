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
            var panelPrefab = tileObject.GetComponent<ItemPresenter>();
            panelPrefab.ItemData = item;
            var topAction = new Tuple<string, Action<Unit>>("Buy & wear", 
                _ =>
                {
                    _storeService.Buy(item, _storeItems, _gameCharacter);
                    Destroy(tileObject.gameObject);
                });
            var bottomAction = new Tuple<string, Action<Unit>>("Buy",
                _ =>
                {
                    _storeService.Buy(item, _storeItems, _gameCharacter);
                    Destroy(tileObject.gameObject);
                });
            panelPrefab.Init(topAction, bottomAction);
        }


        // Use this for initialization
        void Start ()
        {
            _storeItems = _storeService.GenerateItems(1.15m).ToReactiveCollection();
            _storeItems.ForEach(i =>
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
