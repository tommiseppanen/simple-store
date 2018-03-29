using System;
using Models;
using ModestTree;
using Plugins.SimpleStore;
using UniRx;
using UnityEngine;
using Zenject;

namespace Presenters
{
    public class StorePresenter : MonoBehaviour
    {

        private Store _store;
        private GameCharacter _gameCharacter;

        [SerializeField]
        private Transform _itemPanelPrefab;

        [Inject]
        public void Init(Store store, GameCharacter character)
        {
            _store = store;
            _gameCharacter = character;
        }

        private void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panelPrefab = tileObject.GetComponent<ItemPresenter>();
            panelPrefab.ItemData = item;
            var topAction = new Tuple<string, Action<Unit>>("Buy & wear", 
                _ =>
                {
                    _store.Buy(item, _gameCharacter);
                    _gameCharacter.Wear(item);
                    Destroy(tileObject.gameObject);
                });
            var bottomAction = new Tuple<string, Action<Unit>>("Buy",
                _ =>
                {
                    _store.Buy(item, _gameCharacter);
                    Destroy(tileObject.gameObject);
                });
            panelPrefab.Init(topAction, bottomAction, 
                _gameCharacter.WearedItem.Select(_ => _gameCharacter.IsWearing(item)));
        }


        // Use this for initialization
        void Start ()
        {
            _store.StoreItems.ForEach(i =>
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));

            _store.StoreItems.ObserveAdd()
                .Subscribe(i =>
                    InitializePanel(Instantiate(_itemPanelPrefab, transform), i.Value));
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
