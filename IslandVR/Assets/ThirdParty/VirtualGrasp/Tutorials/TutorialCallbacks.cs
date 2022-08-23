#if UNITY_TUTORIALS_PACKAGE_INSTALLED
using UnityEngine;
using UnityEditor;
using Unity.Tutorials.Core.Editor;
using VirtualGrasp;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// Implement your Tutorial callbacks here.
/// </summary>
[CreateAssetMenu(fileName = DefaultFileName, menuName = "Tutorials/" + DefaultFileName + " Instance")]
public class TutorialCallbacks : ScriptableObject
{
    /// <summary>
    /// The default file name used to create asset of this class type.
    /// </summary>
    public const string DefaultFileName = "TutorialCallbacks";

    /// <summary>
    /// Creates a TutorialCallbacks asset and shows it in the Project window.
    /// </summary>
    /// <param name="assetPath">
    /// A relative path to the project's root. If not provided, the Project window's currently active folder path is used.
    /// </param>
    /// <returns>The created asset</returns>
    public static ScriptableObject CreateAndShowAsset(string assetPath = null)
    {
        assetPath = assetPath ?? $"{TutorialEditorUtils.GetActiveFolderPath()}/{DefaultFileName}.asset";
        var asset = CreateInstance<TutorialCallbacks>();
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(assetPath));
        EditorUtility.FocusProjectWindow(); // needed in order to make the selection of newly created asset to really work
        Selection.activeObject = asset;
        return asset;
    }

    public bool OneVGMainScriptExists()
    {
        return GameObject.FindObjectsOfType<VG_MainScript>().Length == 1;
    }

    public bool ActiveObjectHasVGMainScript()
    {
        return OneVGMainScriptExists() && Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<VG_MainScript>() != null;
    }
    public bool ActiveObjectHasVGArticulation()
    {
        return Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<VG_Articulation>() != null;
    }

    public bool ActiveObjectMeshIsReadable()
    {
        if (!ActiveObjectHasVGArticulation()) return false;
        return Selection.activeGameObject.GetComponent<MeshFilter>().sharedMesh.isReadable;
    }

    public bool BakeReceived()
    {
        VG_VirtualGraspDbFile db = Resources.Load<VG_VirtualGraspDbFile>("VG_VirtualGraspDBFile");
        string file = "Assets/StreamingAssets/VG_Grasps/" + db.dbName + ".db";
        if (!File.Exists(file)) return false;
        System.DateTime dbWrite = File.GetLastWriteTime(file);
        double diffNow = System.DateTime.Now.Subtract(dbWrite).TotalSeconds;
        return (diffNow < 60);
    }

    public bool DebugFilesCreated()
    {
        VG_VirtualGraspDbFile db = Resources.Load<VG_VirtualGraspDbFile>("VG_VirtualGraspDBFile");
        string file = db.dbName + ".zip";
        if (!File.Exists(file)) return false;

        if (!Directory.Exists("Assets/vg_tmp")) return false;
        double diff = System.DateTime.Now.Subtract(File.GetLastWriteTime(file)).TotalSeconds;
        return (diff < 60);
    }

    public bool DebugSceneCreated()
    {
        if (!Directory.Exists("Assets/vg_tmp")) return false;
        
        string file = "Assets/vg_tmp/" + SceneManager.GetActiveScene().name + ".scn";
        if (!File.Exists(file)) return false;

        double diff = System.DateTime.Now.Subtract(File.GetLastWriteTime(file)).TotalSeconds;
        return (diff < 60);
    }

    public bool GraspStudioResourcesAvailable()
    {
        VG_VirtualGraspDbFile db = Resources.Load<VG_VirtualGraspDbFile>("VG_VirtualGraspDBFile");
        string file = "Assets/StreamingAssets/VG_Grasps/" + db.dbName + ".db";
        if (!File.Exists(file)) return false;
        if (!Directory.Exists("Assets/vg_tmp")) return false;        
        return Directory.GetFiles("Assets/vg_tmp", "*.obj").Length > 0;
    }

    public bool IsGraspStudioScene()
    {
        //return GameObject.FindObjectsOfType<VG_GRas>().Length > 0;
        return false;
    }

    public bool SceneHasSkinnedMeshRenderer()
    {
        return GameObject.FindObjectsOfType<SkinnedMeshRenderer>().Length > 0;
    }

    public bool VGHasControlledAvatar()
    {
        if (!OneVGMainScriptExists()) return false;

        VG_MainScript vg = GameObject.FindObjectsOfType<VG_MainScript>()[0];
        foreach (VG_SensorSetup sensor in vg.m_sensors)
        {
            foreach (VG_Avatar avatar in sensor.m_avatars)
            {
                if (!avatar.m_isRemote && !avatar.m_isReplay && avatar.m_skeletalMesh != null) 
                    return true;
            }
        }
        
        return false;
    }

    public bool VGHasControlledAvatarBySensor()
    {
        if (!VGHasControlledAvatar()) return false;
        return GameObject.FindObjectsOfType<VG_MainScript>()[0].m_sensors[0].m_sensor == VG_SensorType.EXTERNAL_CONTROLLER;
    }
}
#endif // #if UNITY_TUTORIALS_PACKAGE_INSTALLED