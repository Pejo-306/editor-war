using UnityEngine;
using UnityEditor;

/*
 * Editor for Weapon components.
 */
[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    /*
     * Provide inspector with the necessary fields.
     *
     * This editor shares the same interface as the normal inspector for
     * the component. The only difference is that an option to change the
     * static shooting angle is given if a target has not been set for the
     * weapon.
     */
    public override void OnInspectorGUI()
    {
        Weapon weapon = (Weapon)target;

        base.OnInspectorGUI();

        // Field for weapon's target.
        weapon.target = (GameObject)EditorGUILayout.ObjectField(
                "Target", weapon.target, typeof(GameObject), true);
        // Allow the editor to add a static shooting angle
        // if no target is set.
        if (weapon.target == null)
        {
            weapon.staticShootingAngle = EditorGUILayout.FloatField(
                    "Static Shooting Angle", weapon.staticShootingAngle); 
        }
    }
}

