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