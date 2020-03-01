using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// Variable affix explain(變數詞綴註釋)
// Inp => InputField(Component)
// VX => vBtn(positive) & xBtn(negative)
// (Number)B => btn*(Number)

namespace AndyPack {
    public class Popups : MonoBehaviour {

        #region Singleton
        static Popups s_inst;
        public void Awake() {
            if(s_inst != null) {
                DestroyImmediate(gameObject); return;
            }
            else s_inst = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion Singleton

        public Transform popupPool;
        [Space]
        public DialogBase popup0B; // 無可視按鈕(實際上有一個全幕範圍按鈕)
        public DialogBase popupVX; // 雙按鈕彈框(positive)(negative)
        public DialogBase popup1InpVX; // 雙按鈕彈框(with 1 InputField)
        public DialogBase popup2InpVX; // 雙按鈕彈框(with 2 InputField)

        ///<summary>顯示無可視按鈕彈框(實際上有一個全幕範圍按鈕)</summary>
        public static DialogBase ShowPopup0B(string title, string msg, UnityAction clickCb = null) {
            var dialog = GetDialogFromPool("Popup0B", s_inst.popup0B);
            dialog.SetLebals(title, msg);
            dialog.SetButtonsCallbacks(clickCb); // 實際安排了一個全幕範圍鈕(按下關閉)
            dialog.transform.SetAsLastSibling();
            dialog.gameObject.SetActive(true);
            return (dialog);
        }

        ///<summary>顯示雙按鈕彈框(positive)&(negative)</summary>
        public static DialogBase ShowPopupVX(string title, string msg, UnityAction vCB = null, UnityAction xCB = null) {
            var dialog = GetDialogFromPool("PopupVX", s_inst.popupVX);
            dialog.SetLebals(title, msg);
            dialog.SetButtonsCallbacks(vCB, xCB, xCB); // 實際安排了3個鈕，最後一個是全幕暗透背景(視為取消)
            dialog.transform.SetAsLastSibling();
            dialog.gameObject.SetActive(true);
            return (dialog);
        }

        ///<summary>顯示雙按鈕彈框(with 1 InputField)</summary>
        public static DialogBase ShowPopup1InpVX(string title, string msg, UnityAction<string> vCB = null, UnityAction<string> xCB = null) {
            var dialog = GetDialogFromPool("Popup1InpVX", s_inst.popup1InpVX);
            var inpFld = dialog.GetComponentInChildren<InputField>();
            inpFld.text = string.Empty;
            dialog.SetLebals(title, msg);
            dialog.SetButtonsCallbacks(() => { // 實際安排了3個鈕，最後一個是全幕暗透背景(視為取消)
                if(vCB != null) vCB.Invoke(inpFld.text);
            }, () => {
                if(xCB != null) xCB.Invoke(inpFld.text);
            }, () => {
                if(xCB != null) xCB.Invoke(inpFld.text);
            });
            dialog.transform.SetAsLastSibling();
            dialog.gameObject.SetActive(true);
            return (dialog);
        }

        ///<summary>顯示雙按鈕彈框(with 2 InputField)</summary>
        public static DialogBase ShowPopup2InpVX(string title, string msg0, string msg1, UnityAction<string, string> vCB = null, UnityAction<string, string> xCB = null) {
            var dialog = GetDialogFromPool("Popup2InpVX", s_inst.popup2InpVX);
            var inpFlds = dialog.GetComponentsInChildren<InputField>();
            inpFlds[0].text = string.Empty;
            inpFlds[1].text = string.Empty;
            dialog.SetLebals(title, msg0, msg1);
            dialog.SetButtonsCallbacks(() => { // 實際安排了3個鈕，最後一個是全幕暗透背景(視為取消)
                if(vCB != null) vCB.Invoke(inpFlds[0].text, inpFlds[1].text);
            }, () => {
                if(xCB != null) xCB.Invoke(inpFlds[0].text, inpFlds[1].text);
            }, () => {
                if(xCB != null) xCB.Invoke(inpFlds[0].text, inpFlds[1].text);
            });
            dialog.transform.SetAsLastSibling();
            dialog.gameObject.SetActive(true);
            return (dialog);
        }

        /// <summary>嘗試從彈框實例池(popupPool)取Dialog實例，若無則實例化defaultPrefab並回傳該實例</summary>
        static T GetDialogFromPool<T>(string name, T defaultPrefab) where T : DialogBase {
            // in pool and is inactive(canUse)
            foreach(Transform childs in s_inst.popupPool)
                if(childs.name == name && !childs.gameObject.activeSelf)
                    return childs.GetComponent<T>();

            // not in pool or is active(canNotUse)
            T clone = Instantiate(defaultPrefab, s_inst.popupPool);
            clone.name = name;
            return clone;
        }
    }
}
