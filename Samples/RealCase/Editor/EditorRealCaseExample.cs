using UnityEngine;
using System.Collections;
using UnityEditor;



namespace EditorCoroutines.Samples.RealCase
{
	using WaitForSeconds = EditorCoroutines.WaitForSeconds;
	[CustomEditor(typeof(RealCaseExample))]
	public class EditorRealCaseExample : Editor
	{

		private int iterations = 100;
		private bool stop = false;

		public override void OnInspectorGUI()
		{
			EditorGUILayout.LabelField("Performance example");
			EditorGUILayout.LabelField("Increment an int");
			EditorGUILayout.Space();
			iterations = EditorGUILayout.IntField("Iterations ", iterations);
			EditorGUILayout.Space();
			if (GUILayout.Button("Start Slow - WaitForSeconds 0.1f"))
			{
				EditorCoroutine.StartCoroutine(testCoroutine_slow());
			}
			if (GUILayout.Button("Start Fast - return null"))
			{
				EditorCoroutine.StartCoroutine(testCoroutine_fast());
			}
			if (GUILayout.Button("Stop"))
			{
				stop = true;
			}
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("This function may freeze/crash your Unity instance!", MessageType.Warning);
			if (GUILayout.Button("Start iterator without EditorCoroutine"))
			{
				withoutCoroutine();
			}
			EditorGUILayout.Space();
			DrawDefaultInspector();
		}

		public IEnumerator testCoroutine_slow()
		{
			int numberToIterate = 0;
			int iter = iterations;
			Debug.Log("Start slow");
			while (numberToIterate < iter)
			{
				if (stop)
				{
					stop = false;
					break;
				}
				numberToIterate++;
				Debug.Log(numberToIterate);
				yield return new WaitForSeconds(0.1f);
			}
			stop = false;
			Debug.Log("Stop slow");
		}

		public IEnumerator testCoroutine_fast()
		{
			int numberToIterate = 0;
			int iter = iterations;
			Debug.Log("Start fast");
			while (numberToIterate < iter)
			{
				if (stop)
				{
					stop = false;
					break;
				}
				numberToIterate++;
				Debug.Log(numberToIterate);
				yield return null;
			}
			stop = false;
			Debug.Log("Stop fast");
		}

		public void withoutCoroutine()
		{
			int numberToIterate = 0;
			int iter = iterations;
			if (iter > 100)
			{
				iter = 100;
				Debug.Log("Warning iterating over "+ iter + " might crash you Unity instance, reduce to " + iter);
			}
			Debug.Log("Start without Iterator");
			while (numberToIterate < iter)
			{
				if (stop)
				{
					stop = false;
					break;					
				}

				numberToIterate++;
				Debug.Log(numberToIterate);
			}
			Debug.Log("Stop without Iterator");
		}
	}


}