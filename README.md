Navisworks Object Traversal Plugin

This plugin is developed for Autodesk Navisworks using the .NET API and Visual Studio 2022/2026.

Example repository structure:

ObjectTraversalPlugin/
│
├── Properties/
├── References/
├── bin/
├── obj/
├── Icons/
│
├── ObjectTraversalPlugin.bundle/
│   ├── Contents/
│   │   └── Windows/
│   │       ├── Icons/
│   │       │   ├── object16.png.png
│   │       │   └── object32.png.png
│   │       │
│   │       ├── ObjectTraversalPlugin.dll
│   │       └── RibbonLayout.xaml
│   │
│   └── PackageContents.xml
│
├── .gitattributes
├── .gitignore
├── ObjectCounterCommandHandler.cs
├── ObjectCounterPlugin.cs
├── README.md
└── RibbonLayout.xaml

Plugin Setup Steps
1. Build the Project

Build the solution in Visual Studio.

Generated DLL:

bin/Debug/ObjectTraversalPlugin.dll

2. Copy DLL

Copy the generated DLL into:

ObjectTraversalPlugin.bundle/Contents/Windows/

3. Plugin Bundle

The plugin uses Autodesk Navisworks .bundle structure with:

PackageContents.xml
Plugin DLL
RibbonLayout.xaml
Ribbon Icons

4. Install Plugin in Navisworks

Copy:

ObjectTraversalPlugin.bundle

into Navisworks Plugins folder:

C:\ProgramData\Autodesk\ApplicationPlugins

5. Launch Navisworks

Open Navisworks and the ribbon tab/button will appear.

Plugin Features:

Traverse Objects |
Count Objects |
Display Object Statistics
