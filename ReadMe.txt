Made with Unity 5.2.1f1
by Felix Engl (c)
Contact: felix.engl@hotmail.com 

Git: https://github.com/FelixEngl/EditorCoroutines

Version 0.8

Instruction:

1. Import the following namespace
	using EditorCoroutines;
2. (Optional) Define the following using alias for the namespace EditorCoroutines.WaitForSeconds
	using WaitForSeconds = EditorCoroutines.WaitForSeconds;
3. Use it in your code like this
	EditorCoroutine.StartCoroutine(IEnumerator);
4. Possible yield values
	4.1 WWW
	4.2 WaitForSeconds(float f)
	4.3 a random value
	4.4 null


Known bugs:
	1. When the seconds at WaitForSeconds are <1.0f the waited time gets unprecise (it takes a few milliseconds longer).
	2. When the project is moved, you may get this error: "SecurityException: No valid crossdomain policy available to allow access"
		Fix:
			1. Shut down the Project
			2. Delete the following file: [ProjectName]\Library\EditorUserBuildSettings.asset
			3. Start your Project

To-Do:
	1. More functions
	2. Improve sample documentation
    
    
Usefull links to understand coroutines and yield:

https://www.reddit.com/r/gamedev/comments/yum87/unity_coroutines_more_than_you_want_to_know/c5z8dsk

https://startbigthinksmall.wordpress.com/2008/06/09/behind-the-scenes-of-the-c-yield-keyword/

http://twistedoakstudios.com/blog/Post83_coroutines-more-than-you-want-to-know