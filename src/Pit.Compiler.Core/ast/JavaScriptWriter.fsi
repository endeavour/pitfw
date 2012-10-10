namespace Pit.Compiler

module JavaScriptWriter =
    /// Returns JavaScript string for a single node
    val nodeToJS : Node -> string
    
    /// Returns JavaScript string for the node array
    val getJS : Node[] -> string