#Pit - F# to JS Compiler
>Lets you code, debug and manage easily

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