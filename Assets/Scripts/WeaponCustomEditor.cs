using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace WeaponSystem
{
#if UNITY_EDITOR

    public class WeaponCustomEditor : Editor
    {

    }

    [CustomEditor(typeof(Shotgun))]
    public class ShotgunCustomEditor : Editor
    {
        private Shotgun _shotgun;

        private void OnEnable()
        {
            _shotgun = (Shotgun)target;
        }
    }

    [CustomEditor(typeof(Handgun))]
    public class HandgunCustomEditor : Editor
    {
        private Handgun _handgun;

        private SerializedObject _serializedObject;
        private SerializedProperty _serializedProperty;

        private bool foldout;

        private void OnEnable()
        {
            _handgun = (Handgun)target;
            _serializedObject = new SerializedObject(target);
            _serializedProperty = _serializedObject.FindProperty("weaponStats");
        }

        public override void OnInspectorGUI()
        {
            _handgun.reloadType = (ReloadTypeEnum)EditorGUILayout.EnumPopup("Reload Type", _handgun.reloadType);

            switch (_handgun.reloadType)
            {
                case ReloadTypeEnum.Bullet:
                {
                    _handgun.bulletPerReload = EditorGUILayout.IntField("Bullet per Reload", _handgun.bulletPerReload);
                    _handgun.reloadRate = EditorGUILayout.FloatField("Reload Rate", _handgun.reloadRate);
                    break;
                }
            }

            _handgun.detectionLayers = EditorGUILayout.MaskField("Detection layers", _handgun.detectionLayers, UnityEditorInternal.InternalEditorUtility.layers);

            _handgun.weaponStats = EditorGUILayout.ObjectField("Weapon Stats", _handgun.weaponStats, typeof(WeaponStatsSO), true) as WeaponStatsSO;

            if (_handgun.weaponStats != null)
            {
                foldout = EditorGUILayout.Foldout(foldout, "Weapon Stats");

                if (foldout)
                {
                    SerializedObject scriptableObject = new SerializedObject(_serializedProperty.objectReferenceValue);
                    SerializedProperty scriptableProperties = scriptableObject.GetIterator();

                    GUI.enabled = false;

                    scriptableProperties.NextVisible(true);
                    while (scriptableProperties.NextVisible(false))
                    {
                        EditorGUILayout.PropertyField(scriptableProperties, true);
                    }

                    GUI.enabled = true;
                }
            }
        }
    }
#endif
}