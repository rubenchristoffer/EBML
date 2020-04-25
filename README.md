# Evil Bank Mod Loader
EBML is a ModLoader project for supporting mods for the Steam game Evil Bank Manager.  
v1.0.0 is currently under development.

# How to setup cloned fresh repository
1.  Edit SetupPaths.bat where you change path to Evil Bank Manager installation folder
2.  Run SetupPaths.bat (you might need admin privileges)
3.  Open file linker.config and change variable 'ebml' to your Evil Bank Manager installation folder
4.  Open cmd.exe (you might need admin privileges)
5.  CD to root of repository
6.  Type `mklinker.exe linkall`
7.  Build EBML.sln
8.  Build EBML_TestMod.sln
9.  Repeat step 4 to 6
7.  All game references are now available in project!