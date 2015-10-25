using UnityEngine;
using System.Collections;

public abstract class AbstractBehaviourScript : MonoBehaviour {

	private string testString;

	public string TestString
	{
		get { return testString; }
		set { testString = value; }
	}

}
