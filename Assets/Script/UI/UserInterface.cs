using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class UserInterface : MonoBehaviour
    {
        [SerializeField]
        private Slider _chargeSlider;

        [SerializeField]
        private PlayerController _playerController;

        public Slider ChargeSlider
        {
            get { return _chargeSlider; }
        }

        public PlayerController PlayerController
        {
            get { return _playerController; }
        }

        void Start()
        {
            _playerController.Cannon.ChargevalueChanged += CannonOnChargevalueChanged;
        }

        private void CannonOnChargevalueChanged(object sender, CannonChargeEventArgs cannonChargeEventArgs)
        {
            
            var chargeSliderValue = (cannonChargeEventArgs.Intensity -1f) / (cannonChargeEventArgs.MaxValue-1f);
            _chargeSlider.value = chargeSliderValue;
        }
    }
}