namespace Pit.Javascript.JQuery
open Pit
open Pit.Dom
open Pit.Javascript

    [<AutoOpen>]
    module Operators =
        let (@=) (p:string) (v:obj) = (p,v)

    type ajaxOptions<'a> = {
        async       : bool
        contentType : string
        data        : 'a
        dataType : string
        ``global``  : bool
        ifModified  : bool
        processData : bool
        timeout     : int
        url         : string
        xhr         : XMLHttpRequest
    }

    type keyvalue = {
        name    : string
        value   : string
    }

    /// Doc Topic - Events
    [<Pit.Compiler.AstParserExtension(typeof<jQueryParser>);JsIgnore(IgnoreNamespace=true)>]
    module jQuery =
        open Pit.Dom

        type t = JQuery

        [<Js;CompileTo("$");JsIgnore(IgnoreTypeName=true)>]
        let ofEl (x:DomElement) =
            JQuery

        [<Js;CompileTo("$");JsIgnore(IgnoreTypeName=true)>]
        let ofVal(x:string) =
            JQuery

        /// <summary>
        /// Remove an attribute from each of the matched elements.
        /// </summary>
        /// <param name="x">Attribute key/name</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let removeAttr (x) (t:t) =
            t

        /// <summary>
        /// Access a property on the first matched element. This method makes it easy
        /// to retrieve a property value from the first matched element. If the element
        /// does not have an attribute with such a name, undefined is returned.
        /// Attributes include title, alt, src, href, width, style, etc.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let attr (x) (t:t) =
            t

        /// <summary>
        /// Overload for <see cref="jQuery.attr"/>
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///   document.GetElementById("img")
        ///   |> jQuery.ofEl
        ///   |> jQuery.attr2 ("src","images/desert.jpg")
        /// ]]>
        /// </code>
        /// </example>
        /// <param name="x">Attribute key and value</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("attr");JsIgnore(IgnoreTuple=true)>]
        let attr2 (x:string*string) (t:t) =
            t

        /// <summary>
        /// Overload for <see cref="jQuery.attr"/> that gets a map of key/value pairs
        /// and transforms them to property objects as used in jQuery.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///   document.GetElementById("img")
        ///   |> jQuery.ofEl
        ///   |> jQuery.attr3 ([|"src","images/desert.jpg";"title","Desert";"alt","Desert logo"|])
        /// ]]>
        /// </code>
        /// </example>
        /// <param name="x">An array of key/value pairs</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("attr");JsIgnore(IgnoreTuple=true)>]
        let attr3 (x:(string*string)[]) (t:t) =
            t

        /// <summary>
        /// Overload for <see cref="jQuery.attr"/> that gets a map of key/value pairs
        /// and transforms them to property objects as used in jQuery.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///   document.GetElementById("img")
        ///   |> jQuery.ofEl
        ///   |> jQuery.attr4("id", fun(id) -> "div-id" + id.ToString())
        /// ]]>
        /// </code>
        /// </example>
        /// <param name="x">Attribute key and a function callback</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("attr");JsIgnore(IgnoreTuple=true)>]
        let attr4 (x:string * (int -> string)) (t:t) =
            t

        /// <summary>
        /// Adds the specified class if the switch is true, removes the specified class if the switch is false.
        /// </summary>
        /// <param name="x">Class name, Switch (true/false)</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;JsIgnore(IgnoreTuple=true)>]
        let toggleClass (x:string*bool) (t:t) =
            t

        /// <summary>
        /// Adds the specified class(es) to each of the set of matched elements.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("p:last")
        ///     |> jQuery.addClass("selected")
        /// ]]> </code>
        /// </example>
        /// <param name="x">Class name</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        let addClass (x:string) (t:t) =
            t


        /// <summary>
        /// Returns true if the specified class is present on at least one of the set of matched elements.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("p:even")
        ///     |> jQuery.hasClass("className")
        /// ]]> </code>
        /// </example>
        /// <param name="x">Class name</param>
        /// <param name="t">JQuery</param>
        /// <returns>bool</returns>
        let hasClass (x:string) (t:t) =
            true

        /// <summary>
        /// Removes all or the specified class(es) from the set of matched elements.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("p:even")
        ///     |> jQuery.removeClass("selected")
        /// ]]> </code>
        /// </example>
        /// <param name="x">Class name</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        let removeClass (x:string) (t:t) =
            t

        /// <summary>
        /// If no element fits, or the expression is not valid, then the response will be 'false'.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("p:even")
        ///     |> jQuery.is(":first-child")
        /// ]]> </code>
        /// </example>
        /// <param name="x">Query expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let is (x) (t:t) =
            t

        /// <summary>
        /// Argument is the position of the element in the set of matched elements, starting at 0
        /// and going to length - 1. Since the query filters out all elements that do not match the
        /// given index, providing an invalid index returns an empty set of elements rather than null.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("div")
        ///     |> jQuery.eq(0)
        /// ]]> </code>
        /// </example>
        /// <param name="x">int</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let eq (x:int) (t:t) =
            t

        /// <summary>
        /// This method is used to narrow down the results of a search. Provide a
        /// comma-separated list of expressions to apply multiple filters at once.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("div")
        ///     |> jQuery.filter(".middle")
        /// ]]> </code>
        /// </example>
        /// <param name="x">string</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let filter (x:string) (t:t) =
            t

        /// <summary>
        /// The function is called with a context equal to the current element (just like $.each).
        /// If the function returns false, then the element is removed - anything else and
        /// the element is kept.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("div")
        ///     |> jQuery.filter(fun idx ->
        ///         // if id = 1 return true
        ///         idx = 1
        ///     )
        /// ]]> </code>
        /// </example>
        /// <param name="x">Functor with parameter as int and returns a bool</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("filter");>]
        let filter2 (x:int -> bool) (t:t) =
            t

        /// <summary>
        /// Removes elements matching the specified expression from the set of matched elements.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("div")
        ///     |> jQuery.not(".middle, #blueone")
        /// ]]> </code>
        /// </example>
        /// <param name="x">Query expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let not (x:'a) (t:t) =
            t

        /// <summary>
        /// Behaves exactly like the built-in Array slice method.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     let start  = 2
        ///     let endVal = 4
        ///     jQuery.ofVal("div")
        ///     |> jQuery.slice(start,endVal)
        ///     |> jQuery.css("background","yellow")
        /// ]]> </code>
        /// </example>
        /// <param name="x">Query expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;JsIgnore(IgnoreTuple=true)>]
        let slice (x:int * int) (t:t) =
            t

        /// <summary>
        /// Build lists of values, attributes, css values - or even perform special,
        /// custom, selector transformations.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("div")
        ///     |> jQuery.map(fun (idx,el) ->
        ///         jQuery.ofEl(el).value()
        ///     )
        ///     |> jQuery.get
        ///     |> jQuery.join(", ")
        /// ]]> </code>
        /// </example>
        /// <param name="x">Tuple of int and DomElement</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;JsIgnore(IgnoreTuple=true)>]
        let map (x: int * DomElement) (t:t) =
            t

        /// <summary>
        /// Returns the parent of the current element. If there is no parent, returns a jQuery object with a length of 0.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let parent (t:t) =
            t

        /// <summary>
        /// Returns the parent with the given expression. If there is no parent, returns a jQuery object with a length of 0.
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("parent");JsIgnore(IgnoreTuple=true)>]
        let parent2 (x:string) (t:t) =
            t

        /// <summary>
        /// Search elements using jQuery selector expressions.
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let find(x:string) (t:t) =
            t

        /// <summary>
        /// Get a set of elements containing the unique ancestors of the matched
        /// set of elements (except for the root element). The matched elements
        /// can be filtered with an optional expression.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let parents (t:t) =
            t

        /// <summary>
        /// Get a set of elements containing the unique ancestors of the matched
        /// set of elements (except for the root element). The matched elements
        /// can be filtered with an optional expression.
        /// </summary>
        /// <param name="x">An expression to filter parents with.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("parents");JsIgnore(IgnoreTuple=true)>]
        let parents2 (x:string) (t:t) =
            t

        /// <summary>
        /// Only the immediately previous sibling is returned, not all previous siblings.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let prev (t:t) =
            t

        /// <summary>
        /// Only the immediately previous sibling is returned, not all previous siblings.
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("prev");JsIgnore(IgnoreTuple=true)>]
        let prev2 (x:string) (t:t) =
            t

        /// <summary>
        /// Use an optional expression to filter the matched set.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let prevAll (t:t) =
            t

        /// <summary>
        /// Use an optional expression to filter the matched set.
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("prevAll");JsIgnore(IgnoreTuple=true)>]
        let prevAll2 (x:string) (t:t) =
            t

        /// <summary>
        /// Get a set of elements containing all of the unique siblings
        /// of each of the matched set of elements. Can be filtered with
        /// an optional expressions.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let siblings (t:t) =
            t

        /// <summary>
        /// Get a set of elements containing all of the unique siblings of each
        /// of the matched set of elements. Can be filtered with an optional expressions.
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("siblings");JsIgnore(IgnoreTuple=true)>]
        let siblings2 (x:string) (t:t) =
            t

        /// <summary>
        /// Adds more elements, matched by the given expression, to the set of matched elements.
        /// </summary>
        /// <param name="x">An expression whose matched elements are added for String, a string of HTML to create on the fly for DOMElement or one or more Elements to add if an Array.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let add (x) (t:t) =
            t

        /// <summary>
        /// This set can be filtered with an optional expression that will cause only elements
        /// matching the selector to be collected. Also note: while parents() will look at all
        /// ancestors, children() will only consider immediate child elements.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let children (t:t) =
            t

        /// <summary>
        /// This set can be filtered with an optional expression that will cause only elements
        /// matching the selector to be collected. Also note: while parents() will look at all
        /// ancestors, children() will only consider immediate child elements.
        /// </summary>
        /// <param name="x">An expression to filter the child Elements with.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("children");JsIgnore(IgnoreTuple=true)>]
        let children2 (x:string) (t:t) =
            t

        /// <summary>
        /// Closest works by first looking at the current element to see if it matches the specified
        /// expression, if so it just returns the element itself. If it doesn't match then it will continue
        /// to traverse up the document, parent by parent, until an element is found that matches the
        /// specified expression. If no matching element is found then none will be returned.
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let closest(x:string) (t:t) =
            t

        /// <summary>
        /// Find all the child nodes inside the matched elements (including text nodes), or the content document,
        /// if the element is an iframe.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let contents (t:t) =
            t

        /// <summary>
        /// Locates all the elements after this current element.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let nextAll (t:t) =
            t

        /// <summary>
        /// Locates all the elements after this current element. Use a search expression to filter the matched set.
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("nextAll");JsIgnore(IgnoreTuple=true)>]
        let nextAll2 (x:string) (t:t) =
            t

        /// <summary>
        /// This is the first parent of the element that has position (as in relative or absolute).
        /// This method only works with visible elements.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let offsetParent (t:t) =
            t

        /// <summary>
        /// next only returns the very next sibling for each element, not all next siblings
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let next (t:t) =
            t

        /// <summary>
        /// next only returns the very next sibling for each element, not all next siblings
        /// </summary>
        /// <param name="x">Search expression</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("next");JsIgnore(IgnoreTuple=true)>]
        let next2 (x:string) (t:t) =
            t

        /// <summary>
        /// Useful for traversing elements, and then adding something that was matched before the last traversal.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let andSelf (t:t) =
            t

        /// <summary>
        /// If there was no destructive operation before, an empty set is returned.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("end")>]
        let endOf (t:t) =
            t

        /// <summary>
        /// Get the html contents (innerHTML) of the first matched element. This property is
        /// not available on XML documents (although it will work for XHTML documents).
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     let html = jQuery.ofVal("p:last") |> jQuery.html
        /// ]]> </code>
        /// </example>
        /// <param name="t">JQuery</param>
        /// <returns>String</returns>
        [<Js>]
        let html (t:t) =
            ""

        /// <summary>
        /// Set the html contents of every matched element. This property is not
        /// available on XML documents (although it will work for XHTML documents).
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("div") |> jQuery.html2("<span class='red'>Hello <b>Again</b></span>")
        /// ]]> </code>
        /// </example>
        /// <param name="x">HTML text</param>
        /// <param name="t">JQuery</param>
        /// <returns>String</returns>
        [<Js;CompileTo("html");JsIgnore(IgnoreTuple=true)>]
        let html2 (x:string) (t:t) =
            t

        /// <summary>
        /// The result is a string that contains the combined text contents of all matched elements.
        /// This method works on both HTML and XML documents. Cannot be used on input elements. For
        /// input field text use the val attribute.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     let text = jQuery.ofVal("p:last") |> jQuery.text
        /// ]]> </code>
        /// <param name="t">JQuery</param>
        /// <returns>String</returns>
        [<Js>]
        let text (t:t) =
            ""

        /// <summary>
        /// Similar to html(), but escapes HTML (replace "<" and ">" with their HTML entities).
        /// Cannot be used on input elements. For input field text use the val attribute.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("p") |> jQuery.text("<b>Some</b> new text.")
        /// ]]> </code>
        /// </example>
        /// <param name="x">HTML text</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("text");JsIgnore(IgnoreTuple=true)>]
        let text2 (x:string) (t:t) =
            t

        /// <summary>
        /// Get the single value from a single select and an array of values from a multiple
        /// select and display their values.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     let v = jQuery.ofVal("p") |> jQuery.value
        /// ]]> </code>
        /// </example>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("val");JsIgnore(IgnoreTuple=true)>]
        let value (t:t) =
            t

        /// <summary>
        /// Sets the value to the Dom element.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("p") |> jQuery.value("Some Text")
        /// ]]> </code>
        /// </example>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("val");JsIgnore(IgnoreTuple=true)>]
        let value2 (x:string) (t:t) =
            t

        /// <summary>
        /// Checks, or selects, all the radio buttons, checkboxes, and select options
        /// that match the set of values.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     jQuery.ofVal("#multiple") |> jQuery.value([|"Option1";"Option2"|]
        /// ]]> </code>
        /// </example>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("val");JsIgnore(IgnoreTuple=true)>]
        let value3 (x:string[]) (t:t) =
            t

        /// <summary>
        /// This operation is similar to doing an appendChild to all the specified elements,
        /// adding them into the document.
        /// </summary>
        /// <param name="x">This operation is similar to doing an appendChild to all the specified elements, adding them into the document.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let append x (t:t) =
            t

        /// <summary>
        /// This operation is, essentially, the reverse of doing a regular $(A).append(B),
        /// in that instead of appending B to A, you're appending A to B.
        /// </summary>
        /// <param name="x">Target to which the content will be appended</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let appendTo (x:string) (t:t) =
            t

        /// <summary>
        /// This operation is the best way to insert elements inside, at the beginning, of all matched elements.
        /// </summary>
        /// <param name="x">Content to insert after each target</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let prepend x (t:t) =
            t

        /// <summary>
        /// This operation is, essentially, the reverse of doing a regular $(A).prepend(B), in that
        /// instead of prepending B to A, you're prepending A to B.
        /// </summary>
        /// <param name="x">Target to which the content will be appended</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let prependTo (x:string) (t:t) =
            t

        /// <summary>
        /// Insert content after each of the matched elements.
        /// </summary>
        /// <param name="x">Content to insert after each target</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let after x (t:t) =
            t

        /// <summary>
        /// Insert content before each of the matched elements.
        /// </summary>
        /// <param name="x">Content to insert before each target</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let before x (t:t) =
            t

        /// <summary>
        /// This operation is, essentially, the reverse of doing a regular $(A).after(B),
        /// in that instead of inserting B after A, you're inserting A after B.
        /// </summary>
        /// <param name="x">Content after which the selected element(s) is inserted.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let insertAfter x (t:t) =
            t

        /// <summary>
        /// This operation is, essentially, the reverse of doing a regular $(A).before(B),
        /// in that instead of inserting B before A, you're inserting A before B.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let insertBefore x (t:t) =
            t

        /// <summary>
        /// This wrapping process is most useful for injecting additional structure into a document,
        /// without ruining the original semantic qualities of a document.
        /// </summary>
        /// <param name="x">A string of HTML that will be created on the fly and wrapped around the target
        /// Or a DOM element that will be wrapped around each target.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let wrapInner (x) (t:t) =
            t

        /// <summary>
        /// This works by going through the first element provided (which is generated, on the fly,
        /// from the provided HTML) and finds the deepest descendant element within its structure --
        /// it is that element that will enwrap everything else.
        /// </summary>
        /// <param name="x">A string of HTML that will be created on the fly and wrapped around the target
        /// Or a DOM element that will be wrapped around each target.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let wrap (x) (t:t) =
            t

        /// <summary>
        /// This works by going through the first element provided (which is generated, on the fly,
        /// from the provided HTML) and finds the deepest descendant element within its structure --
        /// it is that element that will enwrap everything else.
        /// </summary>
        /// <param name="x">A string of HTML that will be created on the fly and wrapped around the target
        /// Or a DOM element that will be wrapped around each target.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let wrapAll (x) (t:t) =
            t

        /// <summary>
        /// Replaces all matched elements with the specified HTML or DOM elements.
        /// This returns the JQuery element that was just replaced, which has been
        /// removed from the DOM.
        /// </summary>
        /// <param name="x">Content to replace the matched elements with.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let replaceWith (x) (t:t) =
            t

        /// <summary>
        /// This function is the complement to replaceWith() which does the same task
        /// with the parameters reversed.
        /// </summary>
        /// <param name="x">The elements to find and replace the matched elements with.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let replaceAll (x:string) (t:t) =
            t

        /// <summary>
        /// Removes all child nodes and de-registers all event handlers.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let empty (t:t) =
            t

        /// <summary>
        /// Removes the element from the DOM.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let remove (t:t) =
            t

        /// <summary>
        /// Removes the element from the DOM. Uses the expression to match the filters.
        /// </summary>
        /// <param name="x">A jQuery expression to filter the set of elements to be removed.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("remove");JsIgnore(IgnoreTuple=true)>]
        let remove2 (x:string) (t:t) =
            t

        /// <summary>
        /// This is useful for moving copies of the elements to another location in the DOM.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let clone (t:t) =
            t

        /// <summary>
        /// This is useful for moving copies of the elements to another location in the DOM.
        /// </summary>
        /// <param name="x">If true clones the event handlers too</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("clone");JsIgnore(IgnoreTuple=true)>]
        let clone2 (x:bool) (t:t) =
            t

        /// <summary>
        /// Return a style property on the first matched element.
        /// </summary>
        /// <param name="x">The name of the property to access.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let css (x:string) (t:t) =
            t

        /// <summary>
        /// Return a style property on the first matched element.
        /// </summary>
        /// <param name="x">List of key/value pairs to apply CSS.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("css");JsIgnore(IgnoreTuple=true)>]
        let css2 (x: (string*string)[]) (t:t) =
            t

        /// <summary>
        /// Return a style property on the first matched element.
        /// </summary>
        /// <param name="x">A key/value pairs to apply CSS.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("css");JsIgnore(IgnoreTuple=true)>]
        let css3 (x:string * 'a) (t:t) =
            t

        /// <summary>
        /// Gets the scroll left value.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>int</returns>
        [<Js>]
        let scrollLeft (t:t) =
            0

        /// <summary>
        /// Sets the element's scroll left value.
        /// </summary>
        /// <param name="x">Scroll Left value</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("scrollLeft");JsIgnore(IgnoreTuple=true)>]
        let scrollLeft2 (x:float) (t:t) =
            t

        /// <summary>
        /// Gets the scroll top value.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>int</returns>
        [<Js>]
        let scrollTop (t:t) =
            0

        /// <summary>
        /// Sets the element's scroll top value.
        /// </summary>
        /// <param name="x">Scroll Top value</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("scrollTop");JsIgnore(IgnoreTuple=true)>]
        let scrollTop2 (x:float) (t:t) =
            t

        /// <summary>
        /// The returned object contains two Integer properties, top and left. The method
        /// works only with visible elements.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>position</returns>
        [<Js>]
        let offset (t:t) =
            {top=0.;left=0.}

        /// <summary>
        /// The returned object contains two Integer properties, top and left. For accurate
        /// calculations make sure to use pixel values for margins, borders and padding. This
        /// method only works with visible elements.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let position (t:t) =
            {top=0.;left=0.}

        /// <summary>
        /// Gets the inner height.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>int</returns>
        [<Js>]
        let innerHeight (t:t) =
            0

        /// <summary>
        /// Gets the height
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>int</returns>
        [<Js>]
        let height (t:t) =
            0

        /// <summary>
        /// Sets the height of the element
        /// </summary>
        /// <param name="x">String/Number value</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("height");JsIgnore(IgnoreTuple=true)>]
        let height2 (x) (t:t) =
            t

        /// <summary>
        /// Gets the width of the element
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let width (t:t) =
            0

        /// <summary>
        /// Sets the width of the element
        /// </summary>
        /// <param name="x">String/Number value</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("width");JsIgnore(IgnoreTuple=true)>]
        let width2 (x) (t:t) =
            t

        /// <summary>
        /// Gets the outer height.
        /// </summary>
        /// <param name="x">If set to true includes margin in calculation</param>
        /// <param name="t">JQuery</param>
        /// <returns>int</returns>
        [<Js>]
        let outerHeight (x:bool) (t:t) =
            0

        /// <summary>
        /// Gets the outer width
        /// </summary>
        /// <param name="x">If set to true includes margin in calculation</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let outerWidth (x:bool) (t:t) =
            0

        /// <summary>
        /// Gets the inner width
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>int</returns>
        [<Js>]
        let innerWidth (t:t) =
            0

        /// <summary>
        /// Function will be called the instant the DOM is ready to be read and manipulated
        /// </summary>
        /// <param name="fn">Document ready function</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ready (fn:unit->unit) (t:t) =
            t

        /// <summary>
        /// All bound events are removed
        /// </summary>
        /// <param name="x">(String,Event,Object), An event type to unbind. A function to unbind</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let unbind (x:'a * (event->unit)) (t:t) =
            t

        /// <summary>
        /// Possible event values: blur, focus, load, resize, scroll, unload, beforeunload, click,
        /// dblclick, mousedown, mouseup, mousemove, mouseover, mouseout, mouseenter, mouseleave,
        /// change, select, submit, keydown, keypress, keyup, error The event handler is passed an
        /// event object that you can use to prevent default behaviour. To stop both default action and
        /// event bubbling, your handler has to return false.
        /// </summary>
        /// <param name="x">Tuple of type and event function.
        /// Type (String): One or more event types separated by a space
        /// A function to bind to the event on each of the set of matched elements, passed an event object.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let bind (x:'a * (event->unit)) (t:t) =
            t

        /// <summary>
        /// Possible event values: blur, focus, load, resize, scroll, unload, beforeunload, click,
        /// dblclick, mousedown, mouseup, mousemove, mouseover, mouseout, mouseenter, mouseleave,
        /// change, select, submit, keydown, keypress, keyup, error The event handler is passed an
        /// event object that you can use to prevent default behaviour. To stop both default action and
        /// event bubbling, your handler has to return false.
        /// </summary>
        /// <param name="x">Tuple of type and event function.
        /// Type (String): One or more event types separated by a space
        /// A function to bind to the event on each of the set of matched elements, passed an event object.
        /// Data object as a string of key/value pairs.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        /// $("p").bind("click", {foo: "bar"}, handler)
        [<Js;CompileTo("bind");JsIgnore(IgnoreTuple=true)>]
        let bind2 (x:'a * ((string*string)[]) * (event -> unit)) (t:t) =
            t

        /// <summary>
        /// The event handler is executed only once.
        /// </summary>
        /// <param name="x">Tuple of type and event function.
        /// Type (String): One or more event types separated by a space
        /// A function to bind to the event on each of the set of matched elements, passed an event object.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let one (x:'a* (event -> unit)) (t:t) =
            t

        /// <summary>
        /// Triggers the event handler bound using the bind function.
        /// </summary>
        /// <param name="x">Event name/type</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        /// $("button:first").trigger('click');
        [<Js>]
        let trigger (x) (t:t) =
            t

        /// <summary>
        /// Triggers the event handler bound using the bind function.
        /// </summary>
        /// <param name="x">Event name/type with additional data array</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        /// .trigger("click", ["foo", "bar"]);
        [<Js;CompileTo("trigger");JsIgnore(IgnoreTuple=true)>]
        let trigger2 (x:'a * string[]) (t:t) =
            t

        /// <summary>
        /// This method behaves very similarly to the trigger method, with two major exceptions:
        /// First, no default browser actions are triggered.
        /// Second, the event is only triggered on the first element within the jQuery collection.
        /// This method returns the return value of the triggered handler instead of a chainable jQuery
        /// object. Also, if the jQuery collection is empty, this method returns 'undefined'.
        /// </summary>
        /// <param name="x">An event type to trigger</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let triggerHandler (x) (t:t) =
            t

        /// <summary>
        /// This method works and behaves very similarly to jQuery's bind method but with one
        /// important distinction: When you bind a "live" event it will bind to all current and
        /// future elements on the page (using http://www.sitepoint.com/blogs/2008/07/23/javascript-event-delegation-is-easier-than-you-think/).
        /// For example if you bound a live click to all "li" elements on the page then added another
        /// li at a later time - that click event would continue to work for the new element (this is not the case
        /// with bind which must be re-bound on all new elements).
        /// </summary>
        /// <param name="x">
        /// type (String): One or more event types separated by a space
        /// fn (Function): A function to bind to the event on each of the set of matched elements
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let live (x:string * (event->unit)) (t:t) =
            t

        /// <summary>
        /// All bound live events are removed. If the type is provided, all bound live events of that type are removed.
        /// </summary>
        /// <param name="x">
        /// type (String): A live event type to unbind.
        /// fn (Function): A function to unbind from the event on each of the set of matched elements.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let die (x:string * (event->unit)) (t:t) =
            t

        /// <summary>
        /// Whenever the mouse cursor is moved over a matched element, the first specified function is fired.
        /// Whenever the mouse moves off of the element, the second specified function fires. Additionally, checks are in
        /// place to see if the mouse is still within the specified element itself (for example, an image inside of a div),
        /// and if it is, it will continue to 'hover', and not move out (a common error in using a mouseout event handler).
        /// </summary>
        /// <param name="x">
        /// over (Function): The function to fire when the mouse is moved over a matched element.
        /// out (Function): The function to fire when the mouse is moved off of a matched element.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let hover (x:event->unit * (event->unit)) (t:t) =
            t

        /// <summary>
        /// Whenever a matched element is clicked, the first specified function is fired, when clicked again, the second is fired,
        /// and so on. All subsequent clicks continue to rotate through the functions. Use unbind("click") to remove the toggle event.
        /// </summary>
        /// <param name="x">Two functors</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;>]
        let toggleEvent (x: (event->unit) * (event->unit)) (t:t) =
            t

        /// <summary>
        /// Whenever a matched element is clicked, the first specified function is fired, when clicked again, the second is fired,
        /// and so on. All subsequent clicks continue to rotate through the functions. Use unbind("click") to remove the toggle event.
        /// </summary>
        /// <param name="x">Three functors</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("toggle");JsIgnore(IgnoreTuple=true)>]
        let toggleEvent2 (x: (event->unit) * (event->unit) * (event->unit)) (t:t) =
            t

        /// <summary>
        /// The select event fires when a user selects some text in a text field, including input and textarea
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let select (t:t) =
            t

        /// <summary>
        /// The select event fires when a user selects some text in a text field, including input and textarea
        /// </summary>
        /// <param name="x">A function to bind to the select event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("select");JsIgnore(IgnoreTuple=true)>]
        let select2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// Binds a function to the unload event of each matched element.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let unload (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that error event to be executed, and calls
        /// the browser's default error action on the matching element(s).
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let error (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that error event to be executed, and calls
        /// the browser's default error action on the matching element(s).
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("error");JsIgnore(IgnoreTuple=true)>]
        let error2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The keydown event fires when a key on the keyboard is pressed
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let keydown (t:t) =
            t

        /// <summary>
        /// The keydown event fires when a key on the keyboard is pressed
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("keydown");JsIgnore(IgnoreTuple=true)>]
        let keydown2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The keypress event fires when a key on the keyboard is pressed
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let keypress (t:t) =
            t

        /// <summary>
        /// The keypress event fires when a key on the keyboard is pressed
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("keypress");JsIgnore(IgnoreTuple=true)>]
        let keypress2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that blur event to be executed, and calls
        /// the browser's default blur action on the matching element(s).
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let blur (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that blur event to be executed, and calls
        /// the browser's default blur action on the matching element(s).
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("blur");JsIgnore(IgnoreTuple=true)>]
        let blur2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that blur event to be executed, and calls
        /// the browser's default blur action on the matching element(s).
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let change (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that blur event to be executed, and calls
        /// the browser's default blur action on the matching element(s).
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("change");JsIgnore(IgnoreTuple=true)>]
        let change2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The dblclick event fires when the pointing device button is double clicked over an element
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let dblclick (t:t) =
            t

        /// <summary>
        /// The dblclick event fires when the pointing device button is double clicked over an element
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("dblclick");JsIgnore(IgnoreTuple=true)>]
        let dblclick2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The mousedown event fires when the pointing device button is pressed over an element.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let mousedown (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The mouseout event fires when the pointing device is moved away from an element.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let mouseout (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The mousemove event fires when the pointing device is moved from an element.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let mousemove (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The mouseover event fires when the pointing device is hovered over an element.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let mouseover (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The mouseup event fires when the pointing device is lifted up from an element.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let mouseup (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to the keyup event to be executed, and calls
        /// the browser's default keyup action on the matching element(s).
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let keyup (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to the keyup event to be executed, and calls
        /// the browser's default keyup action on the matching element(s).
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("keyup");JsIgnore(IgnoreTuple=true)>]
        let keyup2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// When bound to the window element, the event fires when the user agent finishes loading all content
        /// within a document, including window, frames, objects and images
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let load (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that submit event to be executed, and calls
        /// the browser's default submit action on the matching element(s).
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let submit (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to that submit event to be executed, and calls
        /// the browser's default submit action on the matching element(s).
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("submit");JsIgnore(IgnoreTuple=true)>]
        let submit2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The click event fires when the pointing device button is clicked over an element. A click is defined as
        /// a mousedown and mouseup over the same screen location.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let click (t:t) =
            t

        /// <summary>
        /// The click event fires when the pointing device button is clicked over an element. A click is defined as
        /// a mousedown and mouseup over the same screen location.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("click");JsIgnore(IgnoreTuple=true)>]
        let click2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The scroll event fires when a document view is scrolled.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let scroll (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to the focus event to be executed.
        /// Note that this does not execute the focus method of the underlying elements.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let focus (t:t) =
            t

        /// <summary>
        /// This causes all of the functions that have been bound to the focus event to be executed.
        /// Note that this does not execute the focus method of the underlying elements.
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("focus");JsIgnore(IgnoreTuple=true)>]
        let focus2 (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// The resize event fires when a document view is resized
        /// </summary>
        /// <param name="x">A function to bind to the event on each of the matched elements.</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let resize (x: (event->unit)) (t:t) =
            t

        /// <summary>
        /// If they are shown, toggle makes them hidden (using the hide method). If they are hidden,
        /// toggle makes them shown (using the show method).
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let toggle (t:t) =
            t

        /// <summary>
        /// If they are shown, toggle makes them hidden (using the hide method). If they are hidden,
        /// toggle makes them shown (using the show method).
        /// </summary>
        /// <param name="x">Switch to toggle the display on</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("toggle");JsIgnore(IgnoreTuple=true)>]
        let toggle2 (x:bool) (t:t) =
            t

        /// <summary>
        /// The height, width, and opacity of each of the matched elements are changed dynamically according to
        /// the specified speed. As of jQuery 1.3 the padding and margin are also animated, creating a smoother effect
        /// </summary>
        /// <param name="x">
        /// speed (String, Number ): A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("toggle");JsIgnore(IgnoreTuple=true)>]
        let toggle3 (x:'a* (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Same as show( speed, [callback] ) without animations. Doesn't change anything if the selected elements
        /// are all visible. It doesn't matter if the element is hidden via a hide() call, or via a display:none in a stylesheet
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let show (t:t) =
            t

        /// <summary>
        /// The height, width, and opacity of each of the matched elements are changed dynamically according to the
        /// specified speed. As of jQuery 1.3 the padding and margin are also animated, creating a smoother effect.
        /// </summary>
        /// <param name="x">
        /// speed (String, Number ): A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes; executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("show");JsIgnore(IgnoreTuple=true)>]
        let show2 (x:'a* (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Same as hide( speed, [callback] ) without animations. Doesn't change anything if the selected elements are all hidden.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let hide (t:t) =
            t

        /// <summary>
        /// The height, width, and opacity of each of the matched elements are changed dynamically
        /// according to the specified speed. As of jQuery 1.3 the padding and margin are also animated,
        /// creating a smoother effect.
        /// </summary>
        /// <param name="x">
        /// speed (String, Number ): A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("hide");JsIgnore(IgnoreTuple=true)>]
        let hide2 (x:'a* (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Only the height is adjusted for this animation, causing all matched elements
        /// to be revealed in a "sliding" manner. As of jQuery 1.3 the vertical padding
        /// and vertical margin are also animated, creating a smoother effect.
        /// </summary>
        /// <param name="x"> A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let slideDown (x) (t:t) =
            t

        /// <summary>
        /// Only the height is adjusted for this animation, causing all matched elements
        /// to be revealed in a "sliding" manner. As of jQuery 1.3 the vertical padding
        /// and vertical margin are also animated, creating a smoother effect.
        /// </summary>
        /// <param name="x">
        /// String/Number: A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("slideDown");JsIgnore(IgnoreTuple=true)>]
        let slideDown2 (x:'a * (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Only the height is adjusted for this animation, causing all matched elements
        /// to be hidden in a "sliding" manner. As of jQuery 1.3 the vertical padding and
        /// vertical margin are also animated, creating a smoother effect.
        /// </summary>
        /// <param name="x"> A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let slideUp (x) (t:t) =
            t

        /// <summary>
        /// Only the height is adjusted for this animation, causing all matched elements
        /// to be hidden in a "sliding" manner. As of jQuery 1.3 the vertical padding and
        /// vertical margin are also animated, creating a smoother effect.
        /// </summary>
        /// <param name="x">
        /// String/Number: A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("slideUp");JsIgnore(IgnoreTuple=true)>]
        let slideUp2 (x:'a * (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Only the height is adjusted for this animation, causing all matched elements
        /// to be hidden or shown in a "sliding" manner. As of jQuery 1.3 the vertical padding
        /// and vertical margin are also animated, creating a smoother effect.
        /// </summary>
        /// <param name="x"> A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let slideToggle (x) (t:t) =
            t

        /// <summary>
        /// Only the height is adjusted for this animation, causing all matched elements
        /// to be hidden or shown in a "sliding" manner. As of jQuery 1.3 the vertical padding
        /// and vertical margin are also animated, creating a smoother effect.
        /// </summary>
        /// <param name="x">
        /// String/Number: A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("slideToggle");JsIgnore(IgnoreTuple=true)>]
        let slideToggle2 (x:'a * (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Only the opacity is adjusted for this animation, meaning that all of the
        /// matched elements should already have some form of height and width associated with them.
        /// </summary>
        /// <param name="x">
        /// A string representing one of the three predefined speeds ("slow", "def", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let fadeIn (x) (t:t) =
            t

        /// <summary>
        /// Only the opacity is adjusted for this animation, meaning that all of the
        /// matched elements should already have some form of height and width associated with them.
        /// </summary>
        /// <param name="x">
        /// A string representing one of the three predefined speeds ("slow", "def", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("fadeIn");JsIgnore(IgnoreTuple=true)>]
        let fadeIn2 (x:'a * (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Only the opacity is adjusted for this animation, meaning that all of the
        /// matched elements should already have some form of height and width associated with them.
        /// </summary>
        /// <param name="x">
        /// A string representing one of the three predefined speeds ("slow", "def", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let fadeOut (x) (t:t) =
            t

        /// <summary>
        /// Only the opacity is adjusted for this animation, meaning that all of the
        /// matched elements should already have some form of height and width associated with them.
        /// </summary>
        /// <param name="x">
        /// A string representing one of the three predefined speeds ("slow", "def", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("fadeOut");JsIgnore(IgnoreTuple=true)>]
        let fadeOut2 (x:'a * (unit->unit)) (t:t) =
            t

        /// <summary>
        /// Only the opacity is adjusted for this animation, meaning that all of the
        /// matched elements should already have some form of height and width associated with them.
        /// </summary>
        /// <param name="x">
        /// speed (String, Number ): A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// opacity (Number ): The opacity to fade to (a number from 0 to 1)
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let fadeTo (x:'a * float) (t:t) =
            t

        /// <summary>
        /// Only the opacity is adjusted for this animation, meaning that all of the
        /// matched elements should already have some form of height and width associated with them.
        /// </summary>
        /// <param name="x">
        /// speed (String, Number ): A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// opacity (Number ): The opacity to fade to (a number from 0 to 1)
        /// callback (Function): A function to be executed whenever the animation completes, executed once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("fadeTo");JsIgnore(IgnoreTuple=true)>]
        let fadeTo2 (x:'a * float * (unit->unit)) (t:t) =
            t

        /// <summary>
        /// The key aspect of this function is the object of style properties that will be animated, and to what end.
        /// </summary>
        /// <remarks>
        /// Each key within the object represents a style property that will also be animated
        /// (for example: "height", "top", or "opacity"). Note that properties should be specified
        /// using camel case, e.g. "marginLeft" instead of "margin-left." The value associated with
        /// the key represents to what end the property will be animated. If a number is provided
        /// as the value, then the style property will be transitioned from its current state to
        /// that new number. Otherwise if the string "hide", "show", or "toggle" is provided, a default
        /// animation will be constructed for that property. Only properties that take numeric values
        /// are supported (e.g. backgroundColor is not supported).
        /// </remarks>
        /// <param name="x">
        /// params: A set of style attributes that you wish to animate, and to what end.
        /// duration (String, Number ): A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let animate (x: (string*string)[] * 'a) (t:t) =
            t

        /// <summary>
        /// The key aspect of this function is the object of style properties that will be animated, and to what end.
        /// </summary>
        /// <param name="x">
        /// params: A set of style attributes that you wish to animate, and to what end.
        /// duration (String, Number ): A string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// callback (Function): A function to be executed whenever the animation completes, executes once for each element animated against.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("animate");JsIgnore(IgnoreTuple=true)>]
        let animate2 (x: (string*string)[] * 'a * string * (unit->unit)) (t:t) =
            t

        (*/// <summary>
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("animate");JsIgnore(IgnoreTuple=true)>]
        let animate3 (x: (string*string)[] * animation) (t:t) =
            t*)

        /// <summary>
        /// If any animations are queued to run (and the clearQueue argument is not set to true),
        /// then they will begin immediately.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let stop (t:t) =
            t

        /// <summary>
        /// If any animations are queued to run (and the clearQueue argument is not set to true),
        /// then they will begin immediately.
        /// </summary>
        /// <param name="x">
        /// clearQueue (Boolean): A Boolean (true/false) that when set to true clears the animation queue, effectively stopping all queued animations.
        /// gotoEnd (Boolean): A Boolean (true/false) that when set to true causes the currently playing animation to immediately complete, including resetting original styles on show and hide and calling the callback function
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("stop");JsIgnore(IgnoreTuple=true)>]
        let stop2 (x:bool*bool) (t:t) =
            t

        /// <summary>
        /// $.ajax() returns the XMLHttpRequest that it creates. In most cases you won't need
        /// that object to manipulate directly, but it is available if you need to abort the
        /// request manually. $.ajax() takes one argument, an object of key/value pairs, that
        /// are used to initialize and handle the request.
        /// </summary>
        /// <param name="x">Key/Value pairs of data</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajax (x: (string*obj)[]) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// $.ajax() returns the XMLHttpRequest that it creates. In most cases you won't need
        /// that object to manipulate directly, but it is available if you need to abort the
        /// request manually. $.ajax() takes one argument, an object of key/value pairs, that
        /// are used to initialize and handle the request.
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let get(x:string) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Same as <see cref="jQuery.get"/>
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// data (Map): Key/value pairs that will be sent to the server.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("get")>]
        let get2 (x:string * ((string*obj)[])) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Same as <see cref="jQuery.get"/>
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// data (Map): Key/value pairs that will be sent to the server.
        /// callback (Function): A function to be executed whenever the data is loaded successfully.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("get")>]
        let get3 (x:string * ((string*obj)[]) * (obj->unit)) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Same as <see cref="jQuery.get"/>
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// data (Map): Key/value pairs that will be sent to the server.
        /// callback (Function): A function to be executed whenever the data is loaded successfully.
        /// type (String): Type of data to be returned to callback function: "xml", "html", "script", "json", "jsonp", or "text".
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("get")>]
        let get4 (x:string * ((string*obj)[]) * (string->unit) * string) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Gets the JSON data from the url and callback function is invoked.
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// callback (Function): A function to be executed whenever the data is loaded successfully.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let getJSON (x: string * ('a->unit)) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Gets the JSON data from the url and callback function is invoked.
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// data (Map): Key/value pairs that will be sent to the server.
        /// callback (Function): A function to be executed whenever the data is loaded successfully.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("getJSON")>]
        let getJSON2 (x: string * ((string*obj)[]) * ('a->unit)) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// $.ajax() returns the XMLHttpRequest that it creates. In most cases you won't need
        /// that object to manipulate directly, but it is available if you need to abort the
        /// request manually. $.ajax() takes one argument, an object of key/value pairs, that
        /// are used to initialize and handle the request.
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let post(x:string) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Same as <see cref="jQuery.post"/>
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// data (Map): Key/value pairs that will be sent to the server.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("post")>]
        let post2 (x:string * ((string*obj)[])) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Same as <see cref="jQuery.post"/>
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// data (Map): Key/value pairs that will be sent to the server.
        /// callback (Function): A function to be executed whenever the data is loaded successfully.
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("post")>]
        let post3 (x:string * ((string*obj)[]) * (obj->unit)) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Same as <see cref="jQuery.post"/>
        /// </summary>
        /// <param name="x">
        /// Url: The URL of the page to load.
        /// data (Map): Key/value pairs that will be sent to the server.
        /// callback (Function): A function to be executed whenever the data is loaded successfully.
        /// type (String): Type of data to be returned to callback function: "xml", "html", "script", "json", "jsonp", or "text".
        /// </param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js;CompileTo("post")>]
        let post4 (x:string * ((string*obj)[]) * (string->unit) * string) =
            Unchecked.defaultof<XMLHttpRequest>

        /// <summary>
        /// Attach a function to be executed whenever all AJAX requests have ended. This is an Ajax Event.
        /// </summary>
        /// <param name="x">Function to execute</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajaxStop (x:unit->unit) (t:t) =
            t

        /// <summary>
        /// The XMLHttpRequest and settings used for that request are passed as arguments to the callback.
        /// </summary>
        /// <param name="x">Event, XMLHttpRequest and ajaxoptions</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajaxComplete (x:(event * XMLHttpRequest * ajaxOptions<'a>) -> unit) (t:t) =
            t

        /// <summary>
        /// The XMLHttpRequest and settings used for that request are passed as arguments to the callback.
        /// A third argument, an exception object, is passed if an exception occured while processing the request.
        /// </summary>
        /// <param name="x">Event, XMLHttpRequest and ajaxoptions</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajaxError (x:(event * XMLHttpRequest * ajaxOptions<'a>) -> unit) (t:t) =
            t

        /// <summary>
        /// Gets invoked before an AJAX call is made
        /// </summary>
        /// <param name="x">Event, XMLHttpRequest and ajaxoptions</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajaxSend (x:(event * XMLHttpRequest * ajaxOptions<'a>) -> unit) (t:t) =
            t

        /// <summary>
        /// Attach a function to be executed whenever an AJAX request begins and there is none already active.
        /// </summary>
        /// <param name="x">Function callback</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajaxStart (x:unit->unit) (t:t) =
            t

        /// <summary>
        /// The event object, XMLHttpRequest, and settings used for that request are passed as arguments to the callback.
        /// </summary>
        /// <param name="x">Event, XMLHttpRequest and ajaxoptions</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajaxSuccess (x:(event * XMLHttpRequest * ajaxOptions<'a>) -> unit) (t:t) =
            t

        /// <summary>
        /// Sets the defaults for AJAX requests
        /// </summary>
        /// <param name="x">Map of key value pairs of ajax options</param>
        /// <param name="t">JQuery</param>
        /// <returns>JQuery</returns>
        [<Js>]
        let ajaxSetup (x: (string*obj)[]) = ()

        /// <summary>
        /// Serialize is typically used to prepare user input data to be posted to a server.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>String</returns>
        [<Js>]
        let serialize (t:t) =
            ""

        /// <summary>
        /// he returned JSON structure consists of an Array of Objects where each Object
        /// contains one or two keys: name for the parameter name and value for the parameter
        /// value if set/not empty.
        /// </summary>
        /// <param name="t">JQuery</param>
        /// <returns>String</returns>
        [<Js>]
        let serializeArray (t:t) =
            [|{name="";value=""}|]

        /// <summary>
        /// Ignores the result pipeline. Use this to end the chain of pipeline.
        /// </summary>
        /// <example>
        /// <code> <![CDATA[
        ///     document.GetElementById("img")
        ///     |> jQuery.ofEl
        ///     |> jQuery.ignore
        /// ]]>
        /// </code>
        /// </example>
        /// <param name="t">JQuery</param>
        [<Js;JsIgnore(IgnoreCall=true)>]
        let ignore (t:t) =
            ()