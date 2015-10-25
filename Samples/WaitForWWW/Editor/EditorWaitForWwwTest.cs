using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace FreeEditorCoroutines.Samples.WaitForWww
{
	[CustomEditor(typeof(WaitForWwwTest))]
	public class EditorWaitForWwwTest : AbstractTestClass<WaitForWwwTest>
	{
		//Do not change
		private readonly string testUrl = "https://docs.google.com/spreadsheets/d/1Umgu8OGfr1msf0aK3kTyrsVC95AsjbxU3IchxPFTI4s/export?format=tsv&id=1Umgu8OGfr1msf0aK3kTyrsVC95AsjbxU3IchxPFTI4s&gid=0";

		public string customUrl;


		public override void Awake()
		{
			base.Awake();
			testName = "WaitForWwwTest - Predefined Google Spreadsheet tests";
			customUrl = testUrl;
		}

		override public void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			DrawDefaultInspector();
		}

		public override void ShowAdditionalInformation()
		{
			EditorGUILayout.LabelField("Given test-URL: " + testUrl);
			customUrl = EditorGUILayout.TextField("Custom URL: ", customUrl);
		}

		public override void GetTestButtons(ref TestToggle[] testToggle)
		{
			if (testToggle == null)
			{

				List<TestToggle> testTogglesList = new List<TestToggle>();
				testTogglesList.Add(new TestToggle("Test: Wait for Test URL", false, Test_1));
				testTogglesList.Add(new TestToggle("Test: Wait for Custom URL", false, Test_2));

				/**
				 * Add new tests here
				 */


				testToggle = testTogglesList.ToArray();
			}
		}

		public IEnumerator Test_1()
		{
			Stopwatch stopwatch = new Stopwatch();
			Debug.Log("Start Test " + testName + "_1");
			WWW www = new WWW(testUrl);
			stopwatch.Start();
			yield return www;
			stopwatch.Stop();
			Debug.Log(generateEndText("_1", stopwatch.Elapsed, "TestURL", www.text));
		}

		public IEnumerator Test_2()
		{
			Stopwatch stopwatch = new Stopwatch();
			Debug.Log("Start Test " + testName + "_2");
			WWW www = new WWW(customUrl);
			stopwatch.Start();
			yield return www;
			stopwatch.Stop();
			Debug.Log(generateEndText("_2", stopwatch.Elapsed, "CustomURL", www.text));
		}

		private string generateEndText(string testNr, TimeSpan ts, string urlDesc, string answer)
		{
			StringBuilder strb = new StringBuilder();
			strb.AppendLine("End Test " + testName + testNr + " URL: " + urlDesc + " (click for stats)");
			string elapsedTime = String.Format("Time needet: " + "{0:00}:{1:00}:{2:00}.{3:0000}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds);
			strb.AppendLine(elapsedTime);
			strb.AppendLine("Content: " + answer);
			return strb.ToString();
		}
	}
}