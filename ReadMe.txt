Instruction:

1. Import the following namespace
	using EditorCoroutines;
2. (Optional) Define the following using alias for the namespace EditorCoroutines.WaitForSeconds
	using WaitForSeconds = EditorCoroutines.WaitForSeconds;
3. Use it in your code like this
	EditorCoroutine.StartCoroutine(IEnumerator);
4. Possible yield values
	4.1	WWW
	4.2 WaitForSeconds(float f)
	4.3 a random value
	4.4 null


Known bugs:
	1. When seconds at WaitForSeconds are beneath 1.0f the waited time gets a little bit unprecise and takes longer.

To-Do:
	1. More functions
	2. Improve sample documentation