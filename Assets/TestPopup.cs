using UnityEngine;
using UnityEngine.EventSystems;

public class TestPopup : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData) {
        AndyPack.Popups.ShowPopupVX("OuO", "QAQ", () => print("leftBtnCallBackMsg"), () => print("rightBtnCallBackMsg"));
    }
}
