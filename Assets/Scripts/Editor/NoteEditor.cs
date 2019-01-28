using UnityEditor;
using UnityEngine;

namespace PixelatedLabs.UnityNotes
{
	[CustomEditor(typeof(Note))]
	public class NoteEditor : Editor
	{
		bool editable;
		bool focusContent;
		SerializedProperty content;
		GUIStyle labelStyle;
		GUIStyle textAreaStyle;
		GUILayoutOption[] textAreaOptions;

		void OnEnable()
		{
			editable = false;
			content = serializedObject.FindProperty("content");
			labelStyle = new GUIStyle(EditorStyles.label) { wordWrap = true };
			textAreaStyle = new GUIStyle(EditorStyles.textArea) { wordWrap = true };
			textAreaOptions = new GUILayoutOption[] { GUILayout.ExpandHeight(true) };
		}

		public override void OnInspectorGUI()
		{
			GUILayout.Space(5);
			if (editable)
			{
				serializedObject.Update();
				GUI.SetNextControlName("content");
				content.stringValue = EditorGUILayout.TextArea(content.stringValue, textAreaStyle, textAreaOptions);
				serializedObject.ApplyModifiedProperties();
				if (GUILayout.Button("Close Edit Mode"))
				{
					editable = false;
				}
				if (focusContent)
				{
					focusContent = false;
					EditorGUI.FocusTextInControl("content");
				}
			}
			else
			{
				if (GUILayout.Button(content.stringValue, labelStyle))
				{
					editable = true;
					focusContent = true;
				}
				GUILayout.Space(5);
			}
		}
	}
}