
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowTarget : MonoBehaviour
{

    [SerializeField]internal float speed;
    [SerializeField]internal bool searchByName; 
    [SerializeField]internal string targetName;
    [SerializeField]internal Transform target;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        StartSettings();
    }

    private void StartSettings()
    {
        agent = GetComponent<NavMeshAgent>();
        if (searchByName)
        {
            target = GameObject.Find(targetName).transform;
        }
        agent.speed = speed;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
#if UNITY_EDITOR

[CustomEditor(typeof(FollowTarget))]
public class CIFollowTarget : Editor
{
    private FollowTarget _followT;
    
    private void OnEnable()
    {
        _followT = (FollowTarget)target;
    }

    public override void OnInspectorGUI()
    {
     
        serializedObject.Update();
        
        _followT.speed = EditorGUILayout.FloatField("Speed",_followT.speed);
        _followT.searchByName = GUILayout.Toggle(_followT.searchByName, "Search By Name?");
        
        if (_followT.searchByName == true)
        {
            _followT.targetName = EditorGUILayout.TextField("Nombre",_followT.targetName);
        }
        else
        {
            _followT.target = (Transform)EditorGUILayout.ObjectField("Target", _followT.target, typeof(Transform), true);
        }

        serializedObject.ApplyModifiedProperties();
    }
    
}
#endif