# ShaderLabLab
A system using T4 Templates to generate Unity ShaderLab code in the Editor

# Why?
Unity's ShaderLab lanuages lacks any kind of preprocessing directives.  ShaderLabLab provides templating functionality to overcome the limiations of ShaderLab and even shader code compilation directives.  You could even auto generate extended custom GUI scripts.

# Common Uses 
* File Includes eg include common Properties between shaders
* Precompile control blocks: If, For etc
* Full C# logic avaliable, could write out custom GUI scripts
* Read list of SahderLab properties from external list and generate Properties and global variables
* Complex shader variant creation

# How it works
ShaderLabLab uses the T4 text template system:
https://msdn.microsoft.com/en-us/library/bb126445.aspx

ShaderLabLabProcessor defines a custom asset processor which catches all *.shader.tt asset saves.  It then processes the template using Mono.TextTemplating and outputs a shader file of the same name.

eg myTemplate.shader.tt will be compiled to myTemplate.shader in the same location as the template.

# Examples
Look in the Test folder for an example of file include and a for loop creating mutliple ShaderLab properties.

# TODO
* Try and add custom icons for *.shader.tt files
* Work out a way to add dependencies between shaders and include files

# Reference
https://github.com/mono/t4
http://www.gamasutra.com/blogs/ByronMayne/20160121/258356/Code_Generation_in_Unity.php
http://www.gamasutra.com/blogs/LiorTal/20140311/212863/Code_Generation_Fun_with_Unity.php

I sourced Mono.TextTemplating.dll from here:
https://github.com/winalex/Unity3d-InputMapper/blob/master/Assets/Editor/Mono.TextTemplating.dll.meta

# Notes
Was built on Unity 5.6.0f3 on Windows 10.  Not tested on Mac.
