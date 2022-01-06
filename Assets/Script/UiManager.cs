using UnityEngine;

namespace Assets.Script
{
    class UiManager: MonoBehaviour
    {
        [SerializeField] private GameObject _joystick;
        [SerializeField] private GameObject _buttonJump;

        private void Awake()
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                _joystick.SetActive(false);
                _buttonJump.SetActive(false);
            }
        }
    }
}
