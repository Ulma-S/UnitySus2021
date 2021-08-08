using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class GameManager : MonoBehaviour {
        private void Awake() {
            //キーボード入力の参照をServiceLocatorに登録する.
            var obj = Resources.Load<KeyboardInputProvider>("KeyboardInputProvider");
            var instance = Instantiate(obj);
            Locator.Register<IInputProvider>(instance);
        }
    }
}