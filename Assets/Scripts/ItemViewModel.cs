using System.Globalization;
using Assets.Plugins.SimpleStore;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ItemViewModel : MonoBehaviour {

        [SerializeField]    
        private Text _name;
        [SerializeField]
        private Text _description;
        [SerializeField]
        private Text _price;
        [SerializeField]
        private Image _image;

        [SerializeField]
        private GameObject _infoPanel;

        [SerializeField]
        private GameObject _actionPanel;

        private IStoreItem _itemData;
        public IStoreItem ItemData
        {
            get
            {
                return _itemData;
            }
            set
            {
                _itemData = value;
                _name.text = value.Name;
                _description.text = value.Description;
                _price.text = $"{value.Price.ToString(CultureInfo.InvariantCulture)} C";
                _image.sprite = Resources.Load<Sprite>($"Images/{value.Image}");
            }
        }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void ToggleState()
        {
            _infoPanel.SetActive(!_infoPanel.activeSelf);
            _actionPanel.SetActive(!_infoPanel.activeSelf);
        }

        public void BuyAndWear()
        {
            ToggleState();
        }

        public void Buy()
        {
            ToggleState();
        }
    }
}
