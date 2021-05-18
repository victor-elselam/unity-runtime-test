# unity-runtime-test
This is a Unit Test Framework built with Unity Scenes, so we have all features of Unity available, we can use it in Mobile Builds and has support for async methods. 
It's based on NUnit implementation, however, it's still much more limitated. 
I plan to keep improving and investing effort in this framework, some of my next steps are:

- Create a system that can play tests in sequence and provide a file/window with the result report
- Create a shortcut allowing us to run tests on builds with this automated system
- A configurable object to allow send those reports over a custom server
- Improve the assert options and interactions
- Better UI
- Improve repository with the package.json in sub folders and keep the main project available in the Repository
- Add auto-fill in TestPrefab inspector fields
- New examples for all new features
- Improve documentation

It's very simple to use. 
1 - Drag TestPrefab to a new scene
2 - Assign the inspector fields
3 - Create a new c# script that inherit from AssertMonoBehaviour
4 - Do the Asserts in Awake method, just like the examples

I encourage you to extend the AssertMonoBehaviour with your own needs, for that, Setup() method is virtual.
So you can override it's initialization and create the default setups for your project, like a Context, for example.

Issues:
The sintaxe allows you to use "ShouldBe().ShouldNotBe()" in the same Assert, but this is not supported and I'll make a fix for that as soon as possible
