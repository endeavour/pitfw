#Pit - F# to JS Compiler
>Lets you code, debug and manage easily

Pit is F# to Javascript compiler that leverages the beauty of F# and also JavaScript.

##Roadmap
###Features
* F# Map Structure
* AJAX
    * Support for mapping response text as JSON [Done]
    * Support for reading response XML
* jQuery integration [Done]
    * Additionally implement extension points in the compiler to modify the AST. [Done]
* D3 JS ([link](http://d3js.org "d3")) integration
* F# views for ASP.NET MVC (Tomas Petricek's project)
* HTML5 apis
	* WebSocket [Done]
    * WebWorkers
    * File API
    * Data attributes
* WinRT + VS2011 integration
    * F# 3.0 build targetting VS 2011
    * Metro-specific application templates
    * JavaScript bindings to WinJS
Note: From now on it will be an incremental release based on feature set completion, and no specific version based releases. This is because we have initial set of feature set ready with Pit. Any of these features could be contributed by the community.

Additionally, If someone is interested in creating component controls using Pit, below are the areas of focus,

* F# Component Controls (using reactive pattern aka Observables)
    * Editor controls like AutoComplete, MaskEdit, DateTime, Integer/Double/Percent edit, Popup edit, Slider, Range slider, Color picker, RadioListBox, CheckListBox etc.,
    * Basic Charting library (using SVG/HTML5 Canvas)
        * Sparkline charts
    * Basic diagram controls (using SVG/HTML5 Canvas) 
    * Basic DataGrid

## Building Pit Source:
We recently added [Fake](https://github.com/forki/FAKE "Fake") scripts (build tool for F#). Run the build.bat to execute the scripts, all related dlls will be placed in the bin\debug or bin\release folder.

Additionally to create Vsix and setup, use the run.bat which executes a set of MSbuild project files. This requires additional setup to be installed, since we create VS Extensions, Please download:

* Visual Studio 2010 SDK [here](http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=2680 "link")
* Windows Installer XML (WiX) toolset 3.6 [here](http://wix.codeplex.com/releases/view/75656 "link")
     
##How to contribute?
If you would like to contribute to the Pit project you could take up any of the features that is available in the roadmap / any custom feature that you think would provide nice value. You can email fahad@pitfw.org for dicussing and getting started with it. Small note here, Pit team may be working on some of the features already, so it's at best to check once before you fork off and start on it.

And if you want to work on bug fixes, go ahead and fork it off no need to check with us! Send us couple of test cases along with it.

Note: All features should pass the existing tests found in the "tests" folder and also provide new tests for the feature, only then the feature will be accepted for inclusion in the main branch.

##Reporting issues
Bugs can be filed using the Issues tab in Github (https://github.com/fsharp/pitfw/issues). Make sure you have got the following things

* Sample with clear reproducing steps
* If possible, provide a screenshot and describe the error in a simple way

We will analyze the bug and if it's a good use-case then this will be added to the main test cases for future regression testing.

##Special Thanks
We would like to thank the F# community for providing valuable information in getting this work done. Also, we would like to thank projects like Tomas's F# WebTools (http://fswebtools.codeplex.com/), Jason Greene's F# to JavaScript (https://github.com/jgreene/FSharp.Javascript), Script# (https://github.com/nikhilk/scriptsharp) and the F# source compiler drops (http://fsharppowerpack.codeplex.com/) to help us understand and complete the implementation.