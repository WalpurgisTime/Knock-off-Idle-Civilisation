using UnityEngine;

public class DestructionScript : MonoBehaviour
{
    public ArrayContainer arrayContainer;
    public ArrayArmurerie arrayArmouryContainer;
    public ArrayButchery arrayButchery;
    public ArrayForge arrayForge;
    public ArrayCamp arrayCamp;
    public GameObject objectsToPreserve;
    private DontDestroyOnLoad dontDestroyOnLoad;

    void Start()
    {
        dontDestroyOnLoad = FindObjectOfType<DontDestroyOnLoad>();
    }

    void Update()
    {
        DestroyElements();
    }

    void DestroyElements()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (!IsInExclusionLists(obj) && !IsChildOfPreservedObject(obj) && !IsDontDestroyOnLoadObject(obj))
            {
                Destroy(obj);
            }
        }
    }

    bool IsInExclusionLists(GameObject obj)
    {
        return arrayContainer.createdObjects.Contains(obj) ||
               arrayContainer.createdBoulangerie.Contains(obj) ||
               arrayContainer.createdArmurerie.Contains(obj) ||
               arrayArmouryContainer.createdObjects.Contains(obj) ||
               arrayArmouryContainer.createdArmoury1.Contains(obj) ||
               arrayArmouryContainer.createdArmoury2.Contains(obj) ||
               arrayArmouryContainer.createdArmoury3.Contains(obj) ||
               arrayButchery.createdButchery1.Contains(obj) ||
               arrayButchery.createdButchery2.Contains(obj) ||
               arrayButchery.createdButchery3.Contains(obj) ||
               arrayButchery.createdObjects.Contains(obj) ||
               arrayForge.createdObjects.Contains(obj) ||
               arrayForge.createdForge1.Contains(obj) ||
               arrayForge.createdForge2.Contains(obj) ||
               arrayCamp.createdObjects.Contains(obj) ||
               arrayCamp.createdCamp1.Contains(obj) ||
               arrayCamp.createdCamp2.Contains(obj) ||
               arrayCamp.createdCamp3.Contains(obj);
    }

    bool IsChildOfPreservedObject(GameObject obj)
    {
        return obj.transform.IsChildOf(objectsToPreserve.transform);
    }

    bool IsDontDestroyOnLoadObject(GameObject obj)
    {
        if (dontDestroyOnLoad != null)
        {
            foreach (var dontDestroyObj in dontDestroyOnLoad.objects)
            {
                if (obj == dontDestroyObj || obj.transform.IsChildOf(dontDestroyObj.transform))
                    return true;
            }
        }

        return false;
    }
}
