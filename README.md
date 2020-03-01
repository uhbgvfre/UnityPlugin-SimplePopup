# UnityPlugin-SimplePopup
### [Setup]
- Download SimplePopup.unitypackage in UnityPackage folder.
- Import package to your unity project.

### [Usage]
- Drag Prefab("PopupsManager(Canvas)") to Hierarchy.
- Make sure EventSystem is in current scene.(or create one)
- Then you can write syntax anywhere like this:

```csharp
AndyPack.Popups.ShowPopupVX("OuO", "QAQ", () => print("leftBtnCallBackMsg"), () => print("rightBtnCallBackMsg"));
```
