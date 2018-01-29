using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.SimpleStore;
using Assets.Scripts.Models;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class StoreController : MonoBehaviour
    {

        private IStoreService _storeService;

        [SerializeField]
        private Transform _itemPanelPrefab;

        [Inject]
        public void Init(IStoreService storeService)
        {
            this._storeService = storeService;
        }

        private void UpdateSelection()
        {
            _storeService.GenerateItems().ForEach(i => 
                InitializePanel(Instantiate(_itemPanelPrefab, transform), i));
        }

        private static void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panelPrefab = tileObject.GetComponent<ItemViewModel>();
            panelPrefab.ItemData = item;
        }


        // Use this for initialization
        void Start ()
        {
            UpdateSelection();
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
