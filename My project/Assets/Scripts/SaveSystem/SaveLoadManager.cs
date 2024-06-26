using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveLoadManager : SingletonMonobehavior<SaveLoadManager>
{
    public List<ISaveable> iSaveableObjectList;

    protected override void Awake()
    {
        base.Awake();
        iSaveableObjectList = new List<ISaveable>();
    }

    public void StoreCurrentSceneData()
    {
        // Loop through all ISaveable objects and trigger store scene data for each
        foreach (ISaveable iSaveableObject in iSaveableObjectList)
        {
            iSaveableObject.ISaveableStoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestoreCurrentSceneData()
    {
        // Loop through all ISaveable objects and trigger restore scene data for each
        foreach (ISaveable iSaveableObject in iSaveableObjectList)
        {
            iSaveableObject.ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }
}
