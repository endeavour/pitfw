namespace Pit.JavaScript.JQuery

//current version 1.6.1
open Pit
open Pit.JavaScript
open Pit.Dom
open Pit.Compiler

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type browser() =
    [<DefaultValue>]
    val mutable webkit : bool
    [<DefaultValue>]
    val mutable msie : bool
    [<DefaultValue>]
    val mutable opera : bool
    [<DefaultValue>]
    val mutable mozilla : bool
    [<DefaultValue>]
    val mutable version : string

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type event() =
    [<DefaultValue>]
    val mutable currentTarget : DomElement
    [<DefaultValue>]
    val mutable data : obj
    [<DefaultValue>]
    val mutable pageX : float
    [<DefaultValue>]
    val mutable pageY : float
    [<DefaultValue>]
    val mutable relatedTarget : DomElement
    [<DefaultValue>]
    val mutable result : obj
    [<DefaultValue>]
    val mutable target : DomElement
    [<DefaultValue>]
    val mutable timeStamp : obj
    [<DefaultValue>]
    val mutable ``type`` : obj
    [<DefaultValue>]
    val mutable which : obj
    [<DefaultValue>]
    val mutable keyCode : int
    [<DefaultValue>]
    val mutable ``namespace`` : string


    member this.isDefaultPrevented() = true
    member this.isImmediatePropagationStopped() = true
    member this.isPropagationStopped() = true
    member this.preventDefault() = ()
    member this.stopImmediatePropagation() = ()
    member this.stopPropagation() = ()

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type position() =
    [<DefaultValue>]
    val mutable top : float
    [<DefaultValue>]
    val mutable left : float

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type support() =
    [<DefaultValue>]
    val mutable boxModel : bool
    [<DefaultValue>]
    val mutable cssFloat : bool
    [<DefaultValue>]
    val mutable hrefNormalized : bool
    [<DefaultValue>]
    val mutable htmlSerialize : bool
    [<DefaultValue>]
    val mutable leadingWhitespace : bool
    [<DefaultValue>]
    val mutable noCloneEvent : bool
    [<DefaultValue>]
    val mutable objectAll : bool
    [<DefaultValue>]
    val mutable opacity : bool
    [<DefaultValue>]
    val mutable scriptEval : bool
    [<DefaultValue>]
    val mutable style : bool
    [<DefaultValue>]
    val mutable tbody : bool

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
type promise() =
    member this.``then``(x,y) = deferred()
    member this.``done``(x) = deferred()
    member this.``done``(x,y) = deferred()
    member this.fail(x) = deferred()
    member this.fail(x,y) = deferred()
    member this.always(x) = deferred()
    member this.pipe() = promise()
    member this.pipe(x) = promise()
    member this.pipe(x,y) = promise()

and [<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]deferred() =
    member this.always(x) = deferred()
    member this.``done``(x) = deferred()
    member this.``done``(x,y) = deferred()
    member this.fail(x) = deferred()
    member this.fail(x,y) = deferred()
    member this.isRejected() = true
    member this.isResolved() = false
    member this.pipe() = promise()
    member this.pipe(x) = promise()
    member this.pipe(x,y) = promise()
    member this.promise() = promise()
    member this.promise(x) = promise()
    member this.promise(x,y) = promise()
    member this.reject() = deferred()
    member this.reject(x) = deferred()
    member this.rejectWith(x) = deferred()
    member this.rejectWith(x,y) = deferred()
    member this.resolve() = deferred()
    member this.resolve(x) = deferred()
    member this.resolveWith(x) = deferred()
    member this.resolveWith(x,y) = deferred()
    member this.``then``(x,y) = deferred()
and [<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]jqXHR() =
    inherit XMLHttpRequest()
    member this.``then``(x,y) = deferred()
    member this.``done``(x) = deferred()
    member this.``done``(x,y) = deferred()
    member this.fail(x) = deferred()
    member this.fail(x,y) = deferred()
    member this.always(x) = deferred()
    member this.pipe() = promise()
    member this.pipe(x) = promise()
    member this.pipe(x,y) = promise()

// Documentation : Events
[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
[<AstParserExtension(typeof<jQueryParser>)>]
[<Alias("$")>]
/// <summary>
/// The core functionality of jQuery centers around this function. Everything in jQuery is based upon this, or uses this in some way. The most basic use of this function is to pass in an expression (usually consisting of CSS), which then finds all matching elements.
/// </summary>
type jQuery (x:obj) =   
    /// Adds more elements, matched by the given expression, to the set of matched elements.
    member this.add(x:string) = jQuery(null)
    /// Adds the specified class(es) to each of the set of matched elements.
    member this.addClass(x:string) = jQuery(null)
    /// Insert content after each of the matched elements.
    member this.after(x) = jQuery(null)
    member this.ajaxComplete(x) = jQuery(null)
    member this.ajaxError(x) = jQuery(null)
    member this.ajaxSend(x) = jQuery(null)
    member this.ajaxStart(x) = jQuery(null)
    member this.ajaxStop(x) = jQuery(null)
    member this.ajaxSuccess(x) = jQuery(null)
    /// Useful for traversing elements, and then adding something that was matched before the last traversal.
    member this.andSelf() = jQuery(null)
    member this.animate(x, y) = jQuery(null)
    member this.animate(x,y,z) = jQuery(null)
    member this.animate(x,y,z,q) = jQuery(null)
    /// This operation is similar to doing an appendChild to all the specified elements, adding them into the document.
    member this.append(x) = jQuery(null)
    /// This operation is, essentially, the reverse of doing a regular $(A).append(B), in that instead of appending B to A, you're appending A to B.
    member this.appendTo(x) = jQuery(null)
    /// Access a property on the first matched element. This method makes it easy to retrieve a property value from the first matched element. If the element does not have an attribute with such a name, undefined is returned. Attributes include title, alt, src, href, width, style, etc.
    member this.attr(x:string) = ""
    /// Access a property on the first matched element. This method makes it easy to retrieve a property value from the first matched element. If the element does not have an attribute with such a name, undefined is returned. Attributes include title, alt, src, href, width, style, etc.
    member this.attr(x:string,y) = jQuery(null)
    /// Access a property on the first matched element. This method makes it easy to retrieve a property value from the first matched element. If the element does not have an attribute with such a name, undefined is returned. Attributes include title, alt, src, href, width, style, etc.
    member this.attr(x:string,y:int->unit) = jQuery(null)
    /// This serves as the best way to set a large number of properties on all matched elements.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.attr(x:(string*obj)list) = jQuery(null)
    /// Insert content before each of the matched elements.
    member this.before(x) = jQuery(null)
    /// Insert content before each of the matched elements.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.before(x,y) = jQuery(null)
    /// Possible event values, blur, focus, load, resize, scroll, unload, beforeunload, click, dblclick, mousedown, mouseup, mousemove, mouseover, mouseout, mouseenter, mouseleave, change, select, submit, keydown, keypress, keyup, error.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.bind(x:string,y:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    /// Possible event values, blur, focus, load, resize, scroll, unload, beforeunload, click, dblclick, mousedown, mouseup, mousemove, mouseover, mouseout, mouseenter, mouseleave, change, select, submit, keydown, keypress, keyup, error.
    member this.bind(x:string,y:obj,z:event->unit) = jQuery(null)
    /// This causes all of the functions that have been bound to that blur event to be executed
    member this.blur() = jQuery(null)
    /// The blur event fires when an element loses focus either via the pointing device or by tabbing navigation.
    member this.blur(x:event->unit) = jQuery(null)
    /// The blur event fires when an element loses focus either via the pointing device or by tabbing navigation.
    member this.blur(x:unit->unit) = jQuery(null)
    /// This causes all of the functions that have been bound to that change event to be executed
    member this.change() = jQuery(null)
    /// The change event fires when a control loses the input focus and its value has been modified since gaining focus.
    member this.change(x:event->unit) = jQuery(null)
    /// The change event fires when a control loses the input focus and its value has been modified since gaining focus.
    member this.change(x:unit->unit) = jQuery(null)
    /// This set can be filtered with an optional expression that will cause only elements matching the selector to be collected.
    member this.children() = jQuery(null)
    /// This set can be filtered with an optional expression that will cause only elements matching the selector to be collected.
    member this.children(selector:string) = jQuery(null)
    member this.clearQueue() = jQuery(null)
    member this.clearQueue(queueName) = jQuery(null)
    /// Triggers the click event
    member this.click() = jQuery(null)
    /// Causes all of the functions that have been bound to that click event to be executed.
    member this.click(x:event->unit) = jQuery(null)
    /// Causes all of the functions that have been bound to that click event to be executed.
    member this.click(x:unit->unit) = jQuery(null)
    /// This is useful for moving copies of the elements to another location in the DOM.
    member this.clone() = jQuery(null)
    /// This is useful for moving copies of the elements to another location in the DOM.
    member this.clone(x) = jQuery(null)
    /// This is useful for moving copies of the elements to another location in the DOM.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.clone(x,y) = jQuery(null)
    /// Closest works by first looking at the current element to see if it matches the specified expression, if so it just returns the element itself.
    member this.closest(x:string) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.closest(x,y) = jQuery(null)
    /// Find all the child nodes inside the matched elements (including text nodes), or the content document, if the element is an iframe.
    member this.contents() = jQuery(null)    
    [<DefaultValue>]
    ///Should be used in conjunction with selector to determine the exact query used. These two properties are mostly useful to plugin developers.
    val mutable context : DomElement
    /// Return a style property on the first matched element.
    member this.css(x) = jQuery(null)
    /// If a number is provided, it is automatically converted into a pixel value.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.css(x,y) = jQuery(null)
    /// This is the best way to set several style properties on all matched elements.
    member this.css(x:(string*obj)list) = jQuery(null)
    /// Stores a data value on a given jQuery object
    member this.data(key:string) = new System.Object()
    [<JsIgnore(IgnoreTuple=true)>]
    /// Stores a data value on a given jQuery object
    member this.data(key,value) = ()
    /// This causes all of the functions that have been bound to that dblclick event to be executed,
    member this.dblclick() = jQuery(null)
    /// Hooks up the dbl click event
    member this.dblclick(x:event->unit) = jQuery(null)
    /// Hooks up the dbl click event
    member this.dblclick(x:unit->unit) = jQuery(null)
    member this.delay(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.delay(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.``delegate``(selector,events) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.``delegate``(selector,eventType,handler) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.``delegate``(selector,eventType,eventData,handler) = jQuery(null)
    /// Removes a queued function from the front of the queue and executes it.
    member this.dequeue() = jQuery(null)
    /// Removes a queued function from the front of the queue and executes it.
    member this.dequeue(x:string) = jQuery(null)
    member this.detach() = jQuery(null)
    member this.detach(selector) = jQuery(null)
    member this.die() = jQuery(null)
    member this.die(eventType) = jQuery(null)
    /// Without any arguments, all bound live events are removed.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.die(eventType:string,handler:unit->unit) = jQuery(null)
    /// Additionally, the function, when executed, is passed a single argument representing the position of the element in the matched set (integer, zero-index).
    member this.each(callback:int -> unit) = jQuery(null)
    /// This means that every time the passed-in function is executed (which is once for every element matched) the 'this' keyword points to the specific DOM element.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.each(callback:int * DomElement -> unit) = jQuery(null)
    member this.enableSelectioN() = jQuery(null)
    /// Removes all child nodes (including text nodes), events and internal cache data
    member this.empty() = jQuery(null)
    /// If there was no destructive operation before, an empty set is returned.
    member this.``end``() = jQuery(null)
    /// The position of the element in the set of matched elements starts at 0 and goes to length - 1.
    member this.eq(x:int) = jQuery(null)
    /// This causes all of the functions that have been bound to that error event to be executed, and calls the browser's default error action on the matching element(s)
    member this.error(x:unit->unit) = jQuery(null)
    /// This causes all of the functions that have been bound to that error event to be executed, and calls the browser's default error action on the matching element(s)    
    member this.error(x:event->unit) = jQuery(null)
    member this.fadeIn() = jQuery(null)
    member this.fadeIn(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.fadeIn(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.fadeIn(x,y,z) = jQuery(null)
    member this.fadeOut() = jQuery(null)
    member this.fadeOut(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.fadeOut(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.fadeOut(x,y,z) = jQuery(null)
    member this.fadeTo(duration,opacity) = jQuery(null)
    member this.fadeTo(duration,opacity,callback) = jQuery(null)
    member this.fadeTo(duration,opacity,callback,y) = jQuery(null)
    member this.fadeToggle() = jQuery(null)
    member this.fadeToggle(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.fadeToggle(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.fadeToggle(x,y,z) = jQuery(null)
    /// This method is used to narrow down the results of a search.
    member this.filter(x:string) = jQuery(null)
    /// The function is called with a context equal to the current element (just like $.each). If the function returns false, then the element is removed - anything else and the element is kept.
    member this.filter(fn:int->bool) = jQuery(null)
    /// All searching is done using a jQuery expression. The expression can be written using CSS 1-3 Selector syntax.
    member this.find(x:string) = jQuery(null)
    member this.first() = jQuery(null)
    /// This causes all of the functions that have been bound to the focus event to be executed. 
    member this.focus() = jQuery(null)
    /// The focus event fires when an element receives focus either via the pointing device or by tab navigation.
    member this.focus(handler:unit->unit) = jQuery(null)
    /// The focus event fires when an element receives focus either via the pointing device or by tab navigation.
    member this.focus(handler:event->unit) = jQuery(null)
    member this.focusin(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.focusin(x,y) = jQuery(null)
    member this.focusout(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.focusout(x,y) = jQuery(null)
    /// This serves as a backwards-compatible way of accessing all matched elements (other than the jQuery object itself, which is, in fact, an array of elements).
    member this.get() = new DomElement()
    /// This serves as a backwards-compatible way of accessing all matched elements (other than the jQuery object itself, which is, in fact, an array of elements).
    member this.get(x:int) = new DomElement()
    member this.has(x) = jQuery(null)
    /// Returns true if the specified class is present on at least one of the set of matched elements.
    member this.hasClass(x:string) = jQuery(null)
    /// Gets the height
    member this.height() = 0.0
    /// Sets the height
    member this.height(x) = jQuery(null)
    member this.hide() = jQuery(null)
    member this.hide(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hide(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hide(x,y,z) = jQuery(null)
    /// Whenever the mouse cursor is moved over a matched element, the first specified function is fired.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hover(x:event->unit,y:event->unit) = jQuery(null)
    /// Get the html contents (innerHTML) of the first matched element. This property is not available on XML documents (although it will work for XHTML documents).
    member this.html() = ""
    /// Set the html contents of every matched element. This property is not available on XML documents (although it will work for XHTML documents).
    member this.html(x:string) = jQuery(null)
    /// returns the index (based zero)
    member this.index() = 0
    /// returns the index (based zero) of an element in the page
    member this.index(x) = 0
    /// Gets the inner height
    member this.innerHeight() = 0.
    /// Gets the inner width
    member this.innerWidth() = 0.
    /// This operation is, essentially, the reverse of doing a regular $(A).after(B), in that instead of inserting B after A, you're inserting A after B.
    member this.insertAfter(x) = jQuery(null)
    /// This operation is, essentially, the reverse of doing a regular $(A).before(B), in that instead of inserting B before A, you're inserting A before B.
    member this.insertBefore(x) = jQuery(null)
    /// If no element fits, or the expression is not valid, then the response will be 'false'.
    member this.is(x:string) = true
    /// The keydown event fires when a key on the keyboard is pressed.
    member this.keydown() = jQuery(null)
    /// The keydown event fires when a key on the keyboard is pressed.
    member this.keydown(x:event->unit) = jQuery(null)
    /// The keydown event fires when a key on the keyboard is pressed.
    member this.keydown(x:unit->unit) = jQuery(null)
    /// This causes all of the functions that have been bound to the keypress event to be executed.
    member this.keypress() = jQuery(null)
    /// This causes all of the functions that have been bound to the keypress event to be executed.
    member this.keypress(x:event->unit) = jQuery(null)
    /// This causes all of the functions that have been bound to the keypress event to be executed.
    member this.keypress(x:unit->unit) = jQuery(null)
    /// This causes all of the functions that have been bound to the keyup event to be executed.
    member this.keyup() = jQuery(null)
    /// This causes all of the functions that have been bound to the keyup event to be executed.
    member this.keyup(x:event->unit) = jQuery(null)
    /// This causes all of the functions that have been bound to the keyup event to be executed.
    member this.keyup(x:unit->unit) = jQuery(null)
    member this.last() = jQuery(null)
    [<DefaultValue>]
    /// The number of elements currently matched. The size function will return the same value.
    val mutable length : int
    /// When you bind a "live" event it will bind to all current and future elements on the page
    [<JsIgnore(IgnoreTuple=true)>]
    member this.live(eventType:string, handler:event->unit) = jQuery(null)    
    member this.load(a) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.load(a,b) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.load(a,b,c) = jQuery(null)
    /// Build lists of values, attributes, css values - or even perform special, custom, selector transformations.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.map(x:int->unit) = jQuery(null)
    /// Build lists of values, attributes, css values - or even perform special, custom, selector transformations.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.map(x:(int*DomElement)->unit) = jQuery(null)
    /// The mousedown event fires when the pointing device button is pressed over an element.
    member this.mousedown() = jQuery(null)    
    /// The mousedown event fires when the pointing device button is pressed over an element.
    member this.mousedown(x:event->unit) = jQuery(null)
    /// The mousedown event fires when the pointing device button is pressed over an element.
    member this.mousedown(x:unit->unit) = jQuery(null)
    /// The mouseenter event fires when the pointing device is hovered over an element for the first time
    member this.mouseenter() = jQuery(null)    
    /// The mouseenter event fires when the pointing device is hovered over an element for the first time
    member this.mouseenter(x:event->unit) = jQuery(null)
    /// The mouseenter event fires when the pointing device is hovered over an element for the first time
    member this.mouseenter(x:unit->unit) = jQuery(null)
    member this.mouseleave() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.mouseleave(x: event -> unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.mouseleave(y, x: event -> unit) = jQuery(null)
    member this.mousemove() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.mousemove(x: event -> unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.mousemove(y, x: event -> unit) = jQuery(null)
    /// The mouseout event fires when the pointing device is moved away from an element.
    member this.mouseout() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    /// The mouseout event fires when the pointing device is moved away from an element.
    member this.mouseout(x:event->unit) = jQuery(null)
    /// The mouseout event fires when the pointing device is moved away from an element.    
    member this.mouseout(x:unit->unit) = jQuery(null)
    /// The mouse over event fires when the pointing device is hovered over an element.
    member this.mouseover() = jQuery(null)    
    /// The mouse over event fires when the pointing device is hovered over an element.
    member this.mouseover(x:event->unit) = jQuery(null)
    /// The mouse over event fires when the pointing device is hovered over an element.
    member this.mouseover(x:unit->unit) = jQuery(null)
    /// The mouse up event fires when the pointing device is un-pressed.
    member this.mouseup() = jQuery(null)    
    /// The mouse up event fires when the pointing device is un-pressed.
    member this.mouseup(x: unit->unit) = jQuery(null)    
    /// The mouse up event fires when the pointing device is un-pressed.
    member this.mouseup(x: event->unit) = jQuery(null)
    /// Returns the very next sibling for each element
    member this.next() = jQuery(null)
    /// Returns the very next sibling for each element, provide an optional expression to filter the returned set.
    member this.next(x:string) = jQuery(null)
    /// Returns all the next siblings
    member this.nextAll() = jQuery(null)
    /// Returns all the next siblings, provide an optional expression to filter the returned set.
    member this.nextAll(x:string) = jQuery(null)
    member this.nextUntil() = jQuery(null)
    member this.nextUntil(x) = jQuery(null)
    /// Removes elements matching the specified expression from the set of matched elements.
    member this.not(x:string) = jQuery(null)
    /// The returned object contains two Integer properties, top and left. The method works only with visible elements.
    member this.offset() = new position()
    /// The returned object contains two Integer properties, top and left. The method works only with visible elements.
    member this.offset(x) = new position()
    /// The returned object contains two Integer properties, top and left. The method works only with visible elements.
    member this.offsetParent() = new position()
    /// The handler is executed only once for each element.
    member this.one(x) = jQuery(null)
    /// The handler is executed only once for each element.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.one(x,y:event->unit) = jQuery(null)
    /// The handler is executed only once for each element.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.one(x:string,y:obj,z:event->unit) = jQuery(null)
    /// Gets the outer height
    member this.outerHeight() = 0.0
    /// Gets the outer height
    member this.outerHeight(x:bool) = 0.0
    /// Gets the outer width
    member this.outerWidth() = 0.0
    /// Gets the outer width
    member this.outerWidth(x:bool) = 0.0
    /// If there is no parent, returns a jQuery object with a length of 0.
    member this.parent() = jQuery(null)
    /// Use an optional expression to filter the set of parent elements that will match. If there is no parent, returns a jQuery object with a length of 0.
    member this.parent(x:string) = jQuery(null)
    /// Get a set of elements containing the unique ancestors of the matched set of elements (except for the root element).
    member this.parents() = jQuery(null)
    /// Get a set of elements containing the unique ancestors of the matched set of elements (except for the root element). The matched elements can be filtered with an optional expression.
    member this.parents(x:string) = jQuery(null)
    member this.parentsUntil() = jQuery(null)
    member this.parentsUntil(x) = jQuery(null)
    /// The returned object contains two Integer properties, top and left.
    member this.position() = position()
    /// This operation is the best way to insert elements inside, at the beginning, of all matched elements.
    member this.prepend(x) = jQuery(null)
    /// This operation is the best way to insert elements inside, at the beginning, of all matched elements.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.prepend(x,y) = jQuery(null)
    /// This operation is, essentially, the reverse of doing a regular $(A).prepend(B), in that instead of prepending B to A, you're prepending A to B.
    member this.prependTo(x) = jQuery(null)
    /// Only the immediately previous sibling is returned, not all previous siblings.
    member this.prev() = jQuery(null)
    /// Only the immediately previous sibling is returned, not all previous siblings. Use an optional expression to filter the matched set.
    member this.prev(x:string) = jQuery(null)
    /// Returns all the prev siblints
    member this.prevAll() = jQuery(null)
    /// Returns all the prev siblints, Use an optional expression to filter the matched set.
    member this.prevAll(x:string) = jQuery(null)
    member this.prevUntil() = jQuery(null)
    member this.prevUntil(x) = jQuery(null)
    member this.promise() = promise()
    member this.promise(x) = promise()
    member this.promise(x,y) = promise()
    member this.prop(x) = ""
    member this.prop(x,y) = ""
    //member this.pushStack(x) = jQuery(null)
    member this.pushStack(x,y) = jQuery(null)
    //member this.pushStack(x,y,z) = jQuery(null)
    /// Returns a reference to the first element's queue (which is an array of functions).
    member this.queue() = jQuery(null)
    /// Returns a reference to the first element's queue (which is an array of functions).
    member this.queue(x:string) = jQuery(null)
    /// Returns a reference to the first element's queue (which is an array of functions).
    member this.queue(x:string,y:(unit->unit)array) = jQuery(null)
    /// The function to be executed when the DOM is ready
    member this.ready(x) = jQuery(null)
    /// This does NOT remove them from the jQuery object, allowing you to use the matched elements further.
    member this.remove() = jQuery(null)
    /// This does NOT remove them from the jQuery object, allowing you to use the matched elements further.
    member this.remove(x) = jQuery(null)
    /// Remove an attribute from each of the matched elements.
    member this.removeAttr(x:string) = jQuery(null)
    /// Removes all or the specified class(es) from the set of matched elements.
    member this.removeClass(x:string) = jQuery(null)
    /// Removes the data based on given key from the jQuery object
    member this.removeData(x:string) = jQuery(null)
    member this.removeProp(x) = jQuery(null)
    member this.removeProp(x,y) = jQuery(null)
    /// This function is the complement to replaceWith() which does the same task with the parameters reversed.
    member this.replaceAll(x) = jQuery(null)
    /// Replaces all matched elements with the specified HTML or DOM elements.
    member this.replaceWith(x) = jQuery(null)
    /// The resize event fires when a document view is resized
    member this.resize() = jQuery(null)
    /// The resize event fires when a document view is resized
    member this.resize(x:event->unit) = jQuery(null)
    /// The resize event fires when a document view is resized
    member this.resize(x:unit->unit) = jQuery(null)
    /// The scroll event fires when a document view is scrolled.
    member this.scroll() = jQuery(null)
    /// The scroll event fires when a document view is scrolled.
    member this.scroll(x:unit->unit) = jQuery(null)
    /// The scroll event fires when a document view is scrolled.
    member this.scroll(x:event->unit) = jQuery(null)
    /// Gets the scroll left value
    member this.scrollLeft() = 0.0
    /// Gets the scroll left value
    member this.scrollLeft(x) = 0.0
    /// Gets the scroll top value
    member this.scrollTop() = 0.0
    /// Gets the scroll top value
    member this.scrollTop(x) = 0.0
    /// The select event fires when a user selects some text in a text field, including input and textarea.
    member this.select() = jQuery(null)
    /// The select event fires when a user selects some text in a text field, including input and textarea.
    member this.select(x:unit->unit) = jQuery(null)
    /// The select event fires when a user selects some text in a text field, including input and textarea.
    member this.select(x:event->unit) = jQuery(null)
    [<DefaultValue>]
    /// Should be used in conjunction with context to determine the exact query used. These two properties are mostly useful to plugin developers.
    val mutable selector : string
    member this.serialize() = ""
    member this.serializeArray() = [||]
    member this.show() = jQuery(null)
    member this.show(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.show(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.show(x,y,z) = jQuery(null)
    /// Get a set of elements containing all of the unique siblings of each of the matched set of elements.
    member this.siblings() = jQuery(null)
    /// Get a set of elements containing all of the unique siblings of each of the matched set of elements. Can be filtered with an optional expressions.
    member this.siblings(x) = jQuery(null)
    /// This returns the same number as the 'length' property of the jQuery object. However, it is slightly slower, so length should be used instead.
    member this.size() = 0
    /// Behaves exactly like the built-in Array slice method.
    member this.slice(start:int) = jQuery(null)
    /// Behaves exactly like the built-in Array slice method.
    member this.slice(start:int,e:int) = jQuery(null)
    member this.slideDown() = jQuery(null)
    member this.slideDown(x) = jQuery(null)
    member this.slideDown(x,y) = jQuery(null)
    member this.slideDown(x,y,z) = jQuery(null)
    member this.slideToggle() = jQuery(null)
    member this.slideToggle(x) = jQuery(null)
    member this.slideToggle(x,y) = jQuery(null)
    member this.slideToggle(x,y,z) = jQuery(null)
    member this.slideUp() = jQuery(null)
    member this.slideUp(x) = jQuery(null)
    member this.slideUp(x,y) = jQuery(null)
    member this.slideUp(x,y,z) = jQuery(null)
    member this.stop() = jQuery(null)
    member this.stop(x) = jQuery(null)
    member this.stop(x,y) = jQuery(null)
    /// The select event fires when a form is submitted
    member this.submit(x:unit->unit) = jQuery(null)
    /// The select event fires when a form is submitted
    member this.submit(x:event->unit) = jQuery(null)
    /// The result is a string that contains the combined text contents of all matched elements
    member this.text() = ""
    /// Similar to html(), but escapes HTML (replace "<" and ">" with their HTML entities). Cannot be used on input elements. For input field text use the val attribute.
    member this.text(v:string) = jQuery(null)
    member this.toArray() = [||]
    /// Whenever a matched element is clicked, the first specified function is fired, when clicked again, the second is fired, and so on.
    member this.toggle(x:(event->unit)[]) = jQuery(null)
    /// Adds the specified class if the switch is true, removes the specified class if the switch is false.
    member this.toggleClass(x:string) = jQuery(null)
    /// Adds the specified class if the switch is true, removes the specified class if the switch is false.
    [<JsIgnore(IgnoreTuple=true)>]
    member this.toggleClass(x:string,y:bool) = jQuery(null)
    /// This will also cause the default action of the browser with the same name (if one exists) to be executed.
    member this.trigger(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    /// This will also cause the default action of the browser with the same name (if one exists) to be executed.
    member this.trigger(x,y) = jQuery(null)
    /// This method behaves very similarly to the trigger method,
    member this.triggerHandler(x) = new System.Object()
    /// This method behaves very similarly to the trigger method,
    [<JsIgnore(IgnoreTuple=true)>]
    member this.triggerHandler(x,y) = new System.Object()
    /// Without any arguments, all bound events are removed. If the type is provided, all bound events of that type are removed.
    member this.unbind(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    /// Without any arguments, all bound events are removed. If the type is provided, all bound events of that type are removed.
    member this.unbind(x,y) = jQuery(null)
    member this.undelegate() = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.undelegate(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.undelegate(x,y,z) = jQuery(null)
    /// Binds a function to the unload event of each matched element.
    member this.unload(x) = jQuery(null)
    /// Binds a function to the unload event of each matched element.
    member this.unload(x:unit->unit) = jQuery(null)
    /// Binds a function to the unload event of each matched element.
    member this.unload(x:event->unit) = jQuery(null)
    member this.unwrap() = jQuery(null)
    /// a value is now returned for all elements, including selects
    member this.``val``() = ""
    /// this is also able to set the value of select elements, but selecting the appropriate options.
    member this.``val``(x:string) = ""
    /// this is also able to set array of value to select elements.
    member this.``val``(x:string[]) = ""
    member this.value() = ""
    member this.value(x) = ""
    /// Gets the width
    member this.width() = 0
    /// Sets the width
    member this.width(x) = jQuery(null)
    /// This wrapping process is most useful for injecting additional structure into a document, without ruining the original semantic qualities of a document.
    member this.wrap(x) = jQuery(null)
    /// This is different from .wrap() where each element in the matched set would get wrapped with an element.
    member this.wrapAll(x) = jQuery(null)
    /// This wrapping process is most useful for injecting additional structure into a document, without ruining the original semantic qualities of a document.
    member this.wrapInner(x) = jQuery(null)
    [<JsIgnore(IgnoreCall=true)>]
    member this.ignore() = ()


    static member ajax(x) = jqXHR()
    static member ajax(x, y) = jqXHR()
    static member ajax(x:(string*obj)[]) = jqXHR()

    static member ajaxPrefilter(x, y) = ()
    static member ajaxSetup(x) = ()

    //[<DefaultValue>]
    static let mutable browser = browser()

    static let mutable cssHooks = new System.Object()

    static member contains(container, contained) = true
    //static member data(key) = System.Object()
    [<JsIgnore(IgnoreTuple=true)>]
    static member data(element, key) = new System.Object()
    [<JsIgnore(IgnoreTuple=true)>]
    static member data(element, key, value) = ()
    static member dequeue(element) = ()
    [<JsIgnore(IgnoreTuple=true)>]
    static member dequeue(element, queueName) = ()
    [<JsIgnore(IgnoreTuple=true)>]
    static member each(collection, callback:int -> unit) = ()
    static member error(message) = ()
    static member extend(x) = ()
    [<JsIgnore(IgnoreTuple=true)>]
    static member extend(x,y) = ()
    [<JsIgnore(IgnoreTuple=true)>]
    static member extend(x,y,z) = ()
    [<JsIgnore(IgnoreTuple=true)>]
    static member extend(x,y,z,q) = ()
//    static member get(a) = HtmlElement()
//    static member get(a,b) = HtmlElement()
//    static member get(a,b,c) = HtmlElement()
//    static member get(a,b,c,d) = HtmlElement()
    static member getJSON(a) = jqXHR()
    [<JsIgnore(IgnoreTuple=true)>]
    static member getJSON(a,b) = jqXHR()
    [<JsIgnore(IgnoreTuple=true)>]
    static member getJSON(a,b,c) = jqXHR()
    [<JsIgnore(IgnoreTuple=true)>]
    static member getJSON(a,b,c,d) = jqXHR()
    static member getScript(a) = XMLHttpRequest()
    [<JsIgnore(IgnoreTuple=true)>]
    static member getScript(a,b) = XMLHttpRequest()
    static member globalEval(x) = ()
    static member grep(x) = [||]
    [<JsIgnore(IgnoreTuple=true)>]
    static member grep(x,y) = [||]
    [<JsIgnore(IgnoreTuple=true)>]
    static member grep(x,y,z) = [||]
    static member hasData(x) = true
    static member holdReady(x) = true
    [<JsIgnore(IgnoreTuple=true)>]
    static member inArray(x,y) = 0.0
    static member isArray(x) = true
    static member isEmptyObject(x) = true
    static member isFunction(x) = true
    static member isPlainObject(x) = true
    static member isWindow(x) = true
    static member isXMLDoc(x) = true
    static member makeArray(x) = [||]
    [<JsIgnore(IgnoreTuple=true)>]
    static member map(x,y) = [||]
    [<JsIgnore(IgnoreTuple=true)>]
    static member merge(x,y) = [||]
    static member noConflict() = System.Object()
    static member noConflict(x) = System.Object()
    static member noop() = (fun () -> ())
    static member now() = 0.0
    static member param(x) = ""
    [<JsIgnore(IgnoreTuple=true)>]
    static member param(x,y) = ""
    static member parseJSON(x) : 't = Unchecked.defaultof<_>
    static member parseXML(x) : 't = Unchecked.defaultof<_>
    static member post(a) = jqXHR()
    [<JsIgnore(IgnoreTuple=true)>]
    static member post(a,b) = jqXHR()
    [<JsIgnore(IgnoreTuple=true)>]
    static member post(a,b,c) = jqXHR()
    [<JsIgnore(IgnoreTuple=true)>]
    static member post(a,b,c,d) = jqXHR()
    [<JsIgnore(IgnoreTuple=true)>]
    static member proxy(x,y) = x
    static member pushStack(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    static member pushStack(x,y,z) = jQuery(null)
    /// Returns a reference to the first element's queue (which is an array of functions).
    [<JsIgnore(IgnoreTuple=true)>]
    static member queue(x) = [||] : obj array
    /// Returns a reference to the first element's queue (which is an array of functions).
    [<JsIgnore(IgnoreTuple=true)>]
    static member queue(a,b) = [||] : obj array
    /// Returns a reference to the first element's queue (which is an array of functions).
    [<JsIgnore(IgnoreTuple=true)>]
    static member queue(c,y,z) = [||] : obj array
    static member removeData(element) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    static member removeData(element, name) = jQuery(null)
    static member sub() = jQuery(null)
    static member support = new support()
    static member trim(x:string) = ""
    static member unique(x) = [||]
    static member ``when``(def) = promise()

[<AutoOpen>]
[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true,IgnoreTypeName=true)>]
module DomUtils =
    
    type DomElement with
        [<CompileTo("jQuery")>]
        member this.ToJQuery() = jQuery(this)