# Evil Bank Mod Loader
EBML is a ModLoader project for supporting mods for the Steam game Evil Bank Manager.  
v1.0.0 is currently under development.

# How to setup cloned fresh repository
1.  Run SetupReferences.bat and provide game directory location to setup 7 / 10 references
1.  Build EBML.sln in Visual Studio 2019
1.  Build EBML_TestMod.sln in Visual Studio 2019
1.  Run SetupReferences.bat again and provide same game directory location to setup the remaining 3 / 10 references
1.  All game references are now available in project! This means that when you build project it will automatically use the latest DLL's when launching game