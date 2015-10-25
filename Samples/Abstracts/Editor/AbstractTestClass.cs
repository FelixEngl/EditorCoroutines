using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using FreeEditorCoroutines;
using UnityEngine;


public abstract class AbstractTestClass <T> : Editor where T : UnityEngine.Object{


	/// <summary>
	/// The target of the Editorscript
	/// </summary>
	public T targ;

	//Buttons
	private TestToggle[] testToggles;


	public string testName;


	/// <summary>
	/// The base Awake, call in public override void Awake() of child
	/// </summary>
	public virtual void Awake()
	{
		targ = (T) target;
	}
	
	/// <summary>
	/// The Inspector of the Parent Class, call in override public void OnInspectorGUI() of the cild
	/// </summary>
	override public void OnInspectorGUI()
	{
		EditorGUILayout.LabelField(testName);
		EditorGUILayout.Space();
		ShowAdditionalInformation();
		EditorGUILayout.Space();
		GetTestButtons(ref testToggles);
		if (testToggles == null || testToggles.Length <= 0) return;
		DrawSelectionBoxes();
		EditorGUILayout.Space();
		DrawTestButton();
	}

	/// <summary>
	/// Sets the Testtoggles
	/// </summary>
	/// <param name="testToggle">Reference to the Testbuttons</param>
	public abstract void GetTestButtons(ref TestToggle[] testToggle);

	/// <summary>
	/// Aditional information shown
	/// </summary>
	public virtual void ShowAdditionalInformation()
	{
		
	}

	/// <summary>
	/// Draws toggles
	/// </summary>
	public virtual void DrawSelectionBoxes(){
		for (int i = 0; i < testToggles.Length; i++)
		{
			testToggles[i].selected = EditorGUILayout.Toggle(testToggles[i].toggleName, testToggles[i].selected);
		}
	}

	/// <summary>
	/// Draws the Testbutton
	/// </summary>
	public virtual void DrawTestButton()
	{
		if (GUILayout.Button("Start selected"))
		{
			RunTests();
		}
	}

	/// <summary>
	/// Runs the given tests
	/// </summary>
	public virtual void RunTests()
	{
		for (int i = 0; i < testToggles.Length; i++)
		{
			if (testToggles[i].selected)
			{
				Debug.Log(testToggles[i].toggleName);
				EditorCoroutine.StartCoroutine(testToggles[i].testToStart());
			}
		}
	}

	public virtual void builEndmessage()
	{
		
	}

}

public struct TestToggle{
	public string toggleName;
	public bool selected;
	public Func<IEnumerator> testToStart;

	public TestToggle(string toggleName, bool selected, Func<IEnumerator> testToStart)
	{
		this.toggleName = toggleName;
		this.selected = selected;
		this.testToStart = testToStart;
	}
}