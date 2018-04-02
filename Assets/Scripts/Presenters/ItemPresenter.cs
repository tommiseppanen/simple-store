using System;
using System.Globalization;
using Plugins.SimpleStore;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters
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
        private Button _infoPanelButton;

        [SerializeField]
        private Image _infoPanelBackground;

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
                _price.text = $"{value.NormalPrice.ToString(CultureInfo.InvariantCulture)} C";
                _image.sprite = Resources.Load<Sprite>($"Images/{value.Image}");
            }
        }
        
        public void Init(Tuple<string, Action<Unit>> topAction, 
            Tuple<string, Action<Unit>> bottomAction, IObservable<bool> itemWeared)
        {
            _infoPanelButton.OnClickAsObservable().Subscribe(_ => ToggleState(false));

            _topActionText.text = topAction.Item1;
            var topButtonObservable = _topActionButton.OnClickAsObservable();
            topButtonObservable.Subscribe(topAction.Item2);
            topButtonObservable.Subscribe(_ => ToggleState(true));

            _bottomActionText.text = bottomAction.Item1;
            var bottomButtonObservable = _bottomActionButton.OnClickAsObservable();
            bottomButtonObservable.Subscribe(bottomAction.Item2);
            bottomButtonObservable.Subscribe(_ => ToggleState(true));

            itemWeared.Subscribe(weared =>
            {
                if (_infoPanelBackground != null)
                    _infoPanelBackground.color = GetItemColor(weared);
            });
        }

        private Color GetItemColor(bool weared)
        {
            var alpha = weared ? 0.5f : 0.25f;
            if (_itemData.Rarity == Rarity.Special)
                return new Color(0, 1, 0, alpha);
            else if (_itemData.Rarity == Rarity.Rare)
                return new Color(0, 0, 1, alpha);
            return new Color(1, 1, 1, alpha);
        }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (Input.touchCount <= 0 && !Input.GetMouseButtonDown(0))
                return;

            Vector2 position;
            if (Input.touchCount > 0)
                position = Input.touches[0].position;
            else
                position = Input.mousePosition;

            if (!_actionPanel.activeSelf)
                return;

            if (!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), position))
                ToggleState(true);

        }

        public void ToggleState(bool infoPanelActive)
        {
            _infoPanel.SetActive(infoPanelActive);
            _actionPanel.SetActive(!infoPanelActive);
        }
    }
}
