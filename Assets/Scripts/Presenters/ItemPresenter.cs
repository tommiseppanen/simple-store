using System;
using System.Globalization;
using Assets.Plugins.SimpleStore;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Presenters
{
    public class ItemPresenter : MonoBehaviour {

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

        [SerializeField]
        private Button _topActionButton;
        [SerializeField]
        private Text _topActionText;

        [SerializeField]
        private Button _bottomActionButton;
        [SerializeField]
        private Text _bottomActionText;

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
        
        public void Init(Tuple<string, Action<Unit>> topAction, 
            Tuple<string, Action<Unit>> bottomAction)
        {
            _topActionText.text = topAction.Item1;
            _topActionButton.OnClickAsObservable().Subscribe(topAction.Item2);
            _bottomActionText.text = bottomAction.Item1;
            _bottomActionButton.OnClickAsObservable().Subscribe(bottomAction.Item2);
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
    }
}
