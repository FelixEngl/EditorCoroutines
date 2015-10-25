using UnityEngine;
using System.Collections;
using UnityEditor;
using WaitForSeconds = FreeEditorCoroutines.WaitForSeconds;

namespace FreeEditorCoroutines.Samples.SimpleCase
{

	[CustomEditor(typeof(SimpleCaseExample))]
	public class EditorSimpleCaseExample : Editor
	{

		public override void OnInspectorGUI()
		{
			
			if (GUILayout.Button("Start"))
			{
				EditorCoroutine.StartCoroutine(testCoroutine());
			}
			
			EditorGUILayout.Space();
			DrawDefaultInspector();
		}

		public IEnumerator testCoroutine()
		{
			Debug.Log("Start to wait for 5 seconds");
			yield return new WaitForSeconds(5f);
			Debug.Log("Stop");
		}
	}
}




