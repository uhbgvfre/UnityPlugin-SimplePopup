# UnityPlugin-SimpleDialog
### [Setup]
- Download SimpleDialog.unitypackage in UnityPackage folder.
- Import package to your unity project.
- Drag Prefab("SimpleDialogManager(Canvas)") to Hierarchy.
- Make sure EventSystem is in current scene.(or create one)

### [Usage]
```csharp
AndyPack.SimpleDialog.ShowDialogVX("OuO", "QAQ", () => print("leftBtnCallBackMsg"), () => print("rightBtnCallBackMsg"));
```
