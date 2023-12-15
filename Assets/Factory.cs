using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Factory : MonoBehaviour
{
    [SerializeField] private UnitsConfig UnitsConfig;
    [SerializeField] private SpriteRenderer _prefab;

    private void Start()
    {
        int i = 0;
        foreach (UnitConfig item in UnitsConfig.Orcs)
        {
            GameObject clone = Instantiate(_prefab.gameObject, new Vector3(i, 0, 0), Quaternion.identity);
            clone.GetComponent<SpriteRenderer>().sprite = item.Sprite;
            i += 2;
        }
    }
}

public class Test : MonoBehaviour
{
    public List<int> A;
}

[CustomEditor(typeof(Test))]
class TestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var editor = (Test)target;

        if (editor == null) return;
    }
}
