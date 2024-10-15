using Minicurso.Movement;
using UnityEngine;
using UnityEngine.UI;
using Minicurso.Tests.Buttons.Interfaces;
using InputField = TMPro.TMP_InputField;

namespace Minicurso.Tests.Buttons
{
    [RequireComponent(typeof(Button))]
    public class BaseTestButton : MonoBehaviour, ICreateTestAssetButton
    {
        [SerializeField] protected InputField _inputField;
        private Button _button;

        public int Amount
        {
            get
            {
                int.TryParse(_inputField.text, out int v);
                return v;
            }
        }

        protected virtual void Start()
        {
            if (_button == null) _button = GetComponent<Button>();
            _button.onClick.AddListener(CreateTestAsset);
        }

        public virtual void CreateTestAsset() => TestManager.Instance.Spawn<BaseMovement>(Amount);
    }
}