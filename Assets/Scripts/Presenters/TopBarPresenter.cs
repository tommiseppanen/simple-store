using System.Globalization;
using Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Presenters
{
    public class TopBarPresenter : MonoBehaviour
    {

        private GameCharacter _gameCharacter;
        [SerializeField] private Text _money;

        [Inject]
        public void Init(GameCharacter character)
        {
            _gameCharacter = character;
        }

        // Use this for initialization
        void Start()
        {
            _gameCharacter.PlayerCoins.ObserveEveryValueChanged(x => x.Value)
                .SubscribeToText(_money, d => $"Coins: {d.ToString(CultureInfo.InvariantCulture)}");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}