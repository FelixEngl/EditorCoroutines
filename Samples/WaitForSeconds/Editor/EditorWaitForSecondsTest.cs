using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace EditorCoroutines.Samples.WaitForSeconds
{
	using WaitForSeconds = EditorCoroutines.WaitForSeconds;

	[CustomEditor(typeof(WaitForSecondsTest))]
	public class EditorWaitForSecondsTest : AbstractTestClass<WaitForSecondsTest>
	{

		public float customWaitTime = 1.0f;

		public override void Awake()
		{
			base.Awake();
			testName = "WaitForSecondsTest";
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			DrawDefaultInspector();
		}

		public override void ShowAdditionalInformation()
		{
			customWaitTime = EditorGUILayout.FloatField("Custom waittime: ", customWaitTime);
		}

		public override void GetTestButtons(ref TestToggle[] testToggle)
		{
			if (testToggle == null)
			{

				List<TestToggle> testTogglesList = new List<TestToggle>();
				testTogglesList.Add(new TestToggle("Test: Wait for 5 seconds", false, Test_1));
				testTogglesList.Add(new TestToggle("Test: Wait for custom waittime", false, Test_2));

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
			Debug.Log("Start Test " + testName + "_" + testNumber);

			stopwatch.Start();
			yield return new WaitForSeconds(5f);
			stopwatch.Stop();

			Debug.Log(generateEndText("_" + testNumber, stopwatch.Elapsed, 5f));
		}

		public IEnumerator Test_2()
		{
			Stopwatch stopwatch = new Stopwatch();
			int testNumber = 2;
			Debug.Log("Start Test " + testName + "_" + testNumber);
			stopwatch.Start();
			yield return new WaitForSeconds(customWaitTime);
			stopwatch.Stop();

			Debug.Log(generateEndText("_" + testNumber, stopwatch.Elapsed, customWaitTime));
		}

		private string generateEndText(string testNr, TimeSpan ts, float timeToWait)
		{
			StringBuilder strb = new StringBuilder();
			strb.AppendLine("End Test " + testName + testNr + " Time to Wait: " + timeToWait + " (click for stats)");
			string elapsedTime = String.Format("Time needet: "+"{0:00}:{1:00}:{2:00}.{3:0000}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds);
			strb.AppendLine(elapsedTime);
			return strb.ToString();
		}
	}

}

