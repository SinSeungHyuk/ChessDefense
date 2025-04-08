using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DB_", menuName = "Scriptable Objects/DB")]
public class Database : ScriptableObject
{
    [SerializeField] private List<IdentifiedObject> db = new();

    public IReadOnlyList<IdentifiedObject> DB => db;
    public int Count => db.Count;


    [ContextMenu("Sort By ID")] // �ν����Ϳ� ���Ĺ�ư ����
    private void SortDB()
    {
        for (int i=0;i <db.Count; i++)
        {
            // id �ʵ�� public,static ������ �ƴϿ�����
            FieldInfo field = typeof(IdentifiedObject).GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);

            // FieldInfo�� SetValue�� Ÿ���� id�ʵ带 �Ű����� ����
            field.SetValue(db[i], i);

            // SetDirty�� ����Ƽ�� �������� �˷��־�� ������ �����
            #if UNITY_EDITOR
            EditorUtility.SetDirty(db[i]);
            #endif
        }

        #if UNITY_EDITOR
        // �����ͺ��̽� ��ü�� dirty�� ǥ��
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
        #endif        
    }


    public T GetDataByID<T>(int id) where T : IdentifiedObject
    {
        var result = db.FirstOrDefault(x => x.ID == id) as T;

        // null�̸� �α׸� ����Ѵ�
        if (result == null)
        {
            Debug.LogWarning($"Data with ID {id} not found in the database.#@$@#%@#^#$%&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
        }

        return result;
    }

    public bool Contains(IdentifiedObject item) 
        => db.Contains(item);
}