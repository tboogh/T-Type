using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "TType/EnemyData", order = 1)]
public class EntityData : ScriptableObject
{
    [SerializeField]
    private GameObject _prefab;

    public GameObject Prefab
    {
        get { return _prefab; }
    }
}