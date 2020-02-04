### EBML_DLL Source File Structure ###

All folders correspond to the namespace of the classes in them, except for 'src' which corresponds to the 
namespace 'EBML'.

src 						Main source folder

src/GameAPI					Contains classes that interacts with the game - Very useful namespace for modders

src/GameAPI/Extensions 		Contains classes that implement extension methods for 
							internal game classes in order to access private fields / methods etc.
							
src/GUI						Contains helper classes in order to utilize Unity's old GUI system

src/Hooks					Contains classes that allow you to create method hooks. This is code that will be run
							right before the main body of a function (pre) or right before a function returns 
							(post). 