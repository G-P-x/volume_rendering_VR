This project uses Unity version **6000.3.0f1**.
Installed modules are:
- **Android Build Support**
    - *OpneJDK*
    - *Andorid SDK & NDK Tools*
- **Windows Build Support (IL2CPP)**

Download the repository as a ZIP from https://github.com/mlavik1/UnityVolumeRendering (no need to clone).
Unpack it into your Assets folder in your Unity project.
Use the version corresponding to commit **65ab1f6**
Be sure, at the end, to have a path like Assets/UnityVolumeRendering-master/UnityVolumeRendering-master/..
Otherwise you will have problem loading the raw dataset. Eventually, change it with the new path to the raw dataset in the scriptable object DatasetPaths.

To ensure it won’t be included in your own repository, verify that the path and the name of the unzipped folder match an entry in your **.gitignore**.

**Possible errors**
- If you see an error related to the XR settings from the UnityVolumeRendering-master folder, you can safely delete it. It will not effect the project.

***References***
- *lowpoly-medical-room*: https://sketchfab.com/3d-models/lowpoly-medical-room-616dbedad00e4ff9982d336035d6987a
- *UnityVolumeRendering*: https://github.com/mlavik1/UnityVolumeRendering
