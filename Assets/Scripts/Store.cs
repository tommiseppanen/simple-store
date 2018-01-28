using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.SimpleStore;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class Store : MonoBehaviour {

        [SerializeField]
        private Transform _itemPanelPrefab;

        private void UpdateSelection()
        {
            var random = new System.Random();
            var generators = new List<IStoreItemGenerator>
            {
                new ArmorGenerator(random),
                new WeaponGenerator(random)
            };
            var items = generators.SelectMany(g => g.Generate()).ToList();
            items.ForEach(i => InitializePanel(Instantiate(_itemPanelPrefab, transform), i));
        }

        private static void InitializePanel(Component tileObject, IStoreItem item)
        {
            var panel = tileObject.GetComponent<ItemViewModel>();
            panel.ItemData = item;
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
