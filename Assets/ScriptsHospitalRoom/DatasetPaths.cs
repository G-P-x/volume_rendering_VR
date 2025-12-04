using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "DatasetPaths", menuName = "Scriptable Objects/DatasetPaths")]
public class DatasetPaths : ScriptableObject
{
    [SerializeField] string rawDatasetPath;

    public string RawDatasetPath => Path.GetFullPath(Path.Combine(Application.dataPath,rawDatasetPath));
}

