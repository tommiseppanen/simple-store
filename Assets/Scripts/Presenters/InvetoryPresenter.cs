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

        [SerializeField]
        private Transform _itemPanelPrefab;

        [Inject]
        public void Init(GameCharacter character)
        {
            _gameCharacter = character;
        }

        private void UpdateSelection()
        {
            _gameCharacter.PlayerInventory?.ForEach(i => 
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));
        }

        private static void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panelPrefab = tileObject.GetComponent<ItemPresenter>();
            panelPrefab.ItemData = item;
        }


        // Use this for initialization
        void Start ()
        {
            _gameCharacter.PlayerInventory.ObserveAdd()
                .Subscribe(x => InitializePanel(Instantiate(_itemPanelPrefab, transform), x.Value));
            UpdateSelection();
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
