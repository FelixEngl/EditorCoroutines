using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace EditorCoroutines.Samples.WaitForNull
{
	[CustomEditor(typeof (WaitForNullTest))]
	public class EditorWaitForNullTest : AbstractTestClass<WaitForNullTest>
	{

		public int iterations = 100;

		public override void Awake()
		{
			base.Awake();
			testName = "WaitForNullTest";
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			DrawDefaultInspector();
		}

		public override void ShowAdditionalInformation()
		{
			iterations = EditorGUILayout.IntField("Custom iterations: ", iterations);
		}

		public override void GetTestButtons(ref TestToggle[] testToggle)
		{
			if (testToggle == null)
			{

				List<TestToggle> testTogglesList = new List<TestToggle>();
				testTogglesList.Add(new TestToggle("Test: Wait for custom iterations with return null", false, Test_1));

				/**
				 * Add new tests here
				 */


				testToggle = testTogglesList.ToArray();
			}

		}

		public IEnumerator Test_1()
		{
			Stopwatch stopwatch = new Stopwatch();
			int testNumber = 1;
			Debug.Log("Start Test " + testName + "_"+testNumber);

			stopwatch.Start();
			for (int i = 0; i < iterations; i++)
				yield return null;
			stopwatch.Stop();

			Debug.Log(generateEndText("_" + testNumber, stopwatch.Elapsed));
		}

		private string generateEndText(string testNr, TimeSpan ts)
		{
			StringBuilder strb = new StringBuilder();
			strb.AppendLine("End Test " + testName + testNr + " with " + iterations + " iterations" + " (click for stats)");
			string elapsedTime = String.Format("Time needet: "+"{0:00}:{1:00}:{2:00}.{3:0000}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds);
			strb.AppendLine(elapsedTime);
			return strb.ToString();
		}
	}
}