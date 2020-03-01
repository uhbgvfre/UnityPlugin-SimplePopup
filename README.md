# UnityPlugin-SimplePopup
### [Setup]
1. Download SimplePopup.unitypackage in UnityPackage folder.
2. Import package to your unity project.

### [Usage]
1. Drag Prefab("PopupsManager(Canvas)") to Hierarchy.
2. Make sure EventSystem is in current scene.(or create one)
3. Then you can write syntax anywhere like this:

    AndyPack.Popups.ShowPopupVX("OuO", "QAQ", () => print("leftBtnCallBackMsg"), () => print("rightBtnCallBackMsg"));

