#Pit - F# to JS Compiler
>Lets you code, debug and manage easily

##Changelog v0.3.1 (4/13/2012)
####Fixes
* Added jQuery unit tests

###Changelog v0.3 (3/26/2012)
####Fixes
* Closure variable when using new ctor for setting properties
* Corrected setter for DomElement.Style
* added jQuery code generation for tuple args as in hover function
* removed object extensions in pit.js for isInterfaceOf,containsInterface,equality, this make it compatible to work with jquery.js file

###Feature
* Added Pit.Core.Ex project for new extensions 
* Added QUnit support with jQuery
* Added PitJQuery template in VSIX project
* Changed most of the tests to QUnit

###Changelog v0.2.3 (3/4/2012)
####Fixes
* Updated FAKE scripts
* Added code to strip extra op_PipeRight in jQuery code generation
* Added parser context (internal to compiler)
* Added formatting option in build

###Changelog v0.2.2 (2/4/2012)
####Fixes
* ENUM namespace/code generation issue
* If/Else code generation with "when" gaurd
* inheriting DomBody from DomElement
* added assembly resolve code for fixing up referenced assemblies with pfc.exe
* added additional APIs to DomAudio
* partial functions code generation
* added closure wraps for all function calls in a type
* extension methods code gen fix

####Feature
* jQuery support added

###Changelog v0.2.1
#####Fixes
* Changed DomElement to DomObject in event wireup
* let declaration with same names
* record types used with nested Option + match expressions
* added string indexer for JsArray

#####Features
* HTML5 WebSocket API
* JSON parser / stringify API added

###Changelog v0.2

####Features
* Array2D, F# Set, F# String extensions
* Operator overloading for types, records, unions
* AJAX / XMLHttpRequest both in debug/JS mode
* HTML5 DOM elements & SVG
* Custom Library project templates
* Mac MonoDevelop support

####Fixes
* Fix closure issue in for loops
* Fix mapping .NET string functions to JsString
* Fix tuple value code generation in function parameters
* Fix type extensions for DOM type classes
* Fix overloaded constructors issue
* Fix overloaded members
* Fix code generation issue with static property GETTER
* Fix missing method for Window.setInterval

###Changelog v0.1

* Support all features of F# that can be translated using "ReflectedDefinitionAttribute"
* Clean JS code generation
* Support below major F# libraries
  * Seq
  * List
  * Array
  * Event
  * IObservable
  * Computation Expressions
* Full HTML DOM and HTML5 Canvas Support
* Visual Studio 2010 integration with Application Project Templates
  * Debugging support for F# code
  * Build support with Pit compiler
  * JavaScript error notification