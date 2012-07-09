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

[<JsIgnore(IgnoreNamespace=true,IgnoreGetSet=true)>]
[<AstParserExtension(typeof<jQueryParser>)>]
[<Alias("$")>]
type jQuery (x:obj) =
    member this.add(x) = jQuery(null)
    member this.addClass(x) = jQuery(null)
    member this.after(x) = jQuery(null)
    member this.ajaxComplete(x) = jQuery(null)
    member this.ajaxError(x) = jQuery(null)
    member this.ajaxSend(x) = jQuery(null)
    member this.ajaxStart(x) = jQuery(null)
    member this.ajaxStop(x) = jQuery(null)
    member this.ajaxSuccess(x) = jQuery(null)
    member this.andSelf() = jQuery(null)
    member this.animate(x, y) = jQuery(null)
    member this.animate(x,y,z) = jQuery(null)
    member this.animate(x,y,z,q) = jQuery(null)
    member this.append(x) = jQuery(null)
    member this.appendTo(x) = jQuery(null)
    member this.attr(x) = ""
    member this.attr(x,y) = jQuery(null)
    member this.before(x) = jQuery(null)
    member this.before(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.bind(x:string,y:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.bind(x:string,y:obj,z:event->unit) = jQuery(null)
    member this.blur() = jQuery(null)
    member this.blur(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.blur(x,y) = jQuery(null)
    member this.change() = jQuery(null)
    member this.change(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.change(x,y) = jQuery(null)
    member this.children() = jQuery(null)
    member this.children(selector) = jQuery(null)
    member this.clearQueue() = jQuery(null)
    member this.clearQueue(queueName) = jQuery(null)
    member this.click() = jQuery(null)
    member this.click(handler : event -> unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.click(x,y) = jQuery(null)
    member this.clone() = jQuery(null)
    member this.clone(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.clone(x,y) = jQuery(null)
    member this.closest(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.closest(x,y) = jQuery(null)
    member this.contents() = jQuery(null)
    [<DefaultValue>]
    val mutable context : DomElement
    member this.css(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.css(x,y) = jQuery(null)
    member this.data(key) = new System.Object()
    [<JsIgnore(IgnoreTuple=true)>]
    member this.data(key,value) = ()
    member this.dblclick() = jQuery(null)
    member this.dblclick(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.dblclick(x,y) = jQuery(null)
    member this.delay(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.delay(x,y) = jQuery(null)
    member this.``delegate``(selector,events) = jQuery(null)
    member this.``delegate``(selector,eventType,handler) = jQuery(null)
    member this.``delegate``(selector,eventType,eventData,handler) = jQuery(null)
    member this.dequeue() = jQuery(null)
    member this.dequeue(x) = jQuery(null)
    member this.detach() = jQuery(null)
    member this.detach(selector) = jQuery(null)
    member this.die() = jQuery(null)
    member this.die(eventType) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.die(eventType,handler) = jQuery(null)
    member this.each(callback) = jQuery(null)
    member this.enableSelectioN() = jQuery(null)
    member this.empty() = jQuery(null)
    member this.``end``() = jQuery(null)
    member this.eq(x) = jQuery(null)
    member this.error(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.error(x,y) = jQuery(null)
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
    member this.filter(x) = jQuery(null)
    member this.find(x) = jQuery(null)
    member this.first() = jQuery(null)
    member this.focus() = jQuery(null)
    member this.focus(handler) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.focus(x,y) = jQuery(null)
    member this.focusin(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.focusin(x,y) = jQuery(null)
    member this.focusout(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.focusout(x,y) = jQuery(null)
    member this.get() = new DomElement()
    member this.get(x) = new DomElement()
    member this.has(x) = jQuery(null)
    member this.hasClass(x) = jQuery(null)
    member this.height() = 0.0
    member this.height(x) = jQuery(null)
    member this.hide() = jQuery(null)
    member this.hide(x) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hide(x,y) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hide(x,y,z) = jQuery(null)
    member this.hover(x:event->unit) = jQuery(null)
    [<JsIgnore(IgnoreTuple=true)>]
    member this.hover(x,y) = jQuery(null)
    member this.html() = ""
    member this.html(x) = jQuery(null)
    member this.index() = 0.0
    member this.index(x) = 0.0
    member this.innerHeight() = 1.0
    member this.innerWidth() = 1.0
    member this.insertAfter(x) = jQuery(null)
    member this.insertBefore(x) = jQuery(null)
    member this.is(x) = true
    member this.keydown() = jQuery(null)
    member this.keydown(x : event -> unit) = jQuery(null)
    member this.keydown(x : event -> bool) = jQuery(null)
    member this.keydown(z,x : event -> unit) = jQuery(null)
    member this.keydown(z, x : event -> bool) = jQuery(null)
    member this.keypress() = jQuery(null)
    member this.keypress(x : event -> unit) = jQuery(null)
    member this.keypress(x : event -> bool) = jQuery(null)
    member this.keypress(z,x : event -> unit) = jQuery(null)
    member this.keypress(z,x : event -> bool) = jQuery(null)
    member this.keyup() = jQuery(null)
    member this.keyup(x:event -> unit) = jQuery(null)
    member this.keyup(x:event -> bool) = jQuery(null)
    member this.keyup(z,x:event -> unit) = jQuery(null)
    member this.keyup(z,x:event -> bool) = jQuery(null)
    member this.last() = jQuery(null)
    [<DefaultValue>]
    val mutable length : int
    member this.live(eventType, handler) = jQuery(null)
    member this.live(eventType,eventData,handler) = jQuery(null)
    member this.load(a) = jQuery(null)
    member this.load(a,b) = jQuery(null)
    member this.load(a,b,c) = jQuery(null)
    member this.map(x) = jQuery(null)
    member this.mousedown() = jQuery(null)
    member this.mousedown(x:event->unit) = jQuery(null)
    member this.mousedown(x,y) = jQuery(null)
    member this.mouseenter() = jQuery(null)
    member this.mouseenter(x:event->unit) = jQuery(null)
    member this.mouseenter(x,y) = jQuery(null)
    member this.mouseleave() = jQuery(null)
    member this.mouseleave(x: event -> unit) = jQuery(null)
    member this.mouseleave(y, x: event -> unit) = jQuery(null)
    member this.mousemove() = jQuery(null)
    member this.mousemove(x: event -> unit) = jQuery(null)
    member this.mousemove(y, x: event -> unit) = jQuery(null)
    member this.mouseout() = jQuery(null)
    member this.mouseout(x: event -> unit) = jQuery(null)
    member this.mouseout(y, x: event -> unit) = jQuery(null)
    member this.mouseover() = jQuery(null)
    member this.mouseover(x: event -> unit) = jQuery(null)
    member this.mouseover(y, x: event -> unit) = jQuery(null)
    member this.mouseup() = jQuery(null)
    member this.mouseup(x: event -> unit) = jQuery(null)
    member this.mouseup(y, x: event -> unit) = jQuery(null)
    member this.next() = jQuery(null)
    member this.next(x) = jQuery(null)
    member this.nextAll() = jQuery(null)
    member this.nextAll(x) = jQuery(null)
    member this.nextUntil() = jQuery(null)
    member this.nextUntil(x) = jQuery(null)
    member this.not(x) = jQuery(null)
    member this.offset() = new position()
    member this.offset(x) = new position()
    member this.offsetParent() = new position()
    member this.one(x) = jQuery(null)
    member this.one(x,y) = jQuery(null)
    member this.one(x,y,z) = jQuery(null)
    member this.outerHeight() = 0.0
    member this.outerHeight(x) = 0.0
    member this.outerWidth() = 0.0
    member this.outerWidth(x) = 0.0
    member this.parent() = jQuery(null)
    member this.parent(x) = jQuery(null)
    member this.parents() = jQuery(null)
    member this.parents(x) = jQuery(null)
    member this.parentsUntil() = jQuery(null)
    member this.parentsUntil(x) = jQuery(null)
    member this.position() = position()
    member this.prepend(x) = jQuery(null)
    member this.prepend(x,y) = jQuery(null)
    member this.prependTo(x) = jQuery(null)
    member this.prev() = jQuery(null)
    member this.prev(x) = jQuery(null)
    member this.prevAll() = jQuery(null)
    member this.prevAll(x) = jQuery(null)
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
    member this.queue() = [||]
    member this.queue(x) = [||]
    member this.queue(x,y) = [||]
    member this.ready(x) = jQuery(null)
    member this.remove() = jQuery(null)
    member this.remove(x) = jQuery(null)
    member this.removeAttr(x) = jQuery(null)
    member this.removeClass(x) = jQuery(null)
    member this.removeData(x) = jQuery(null)
    member this.removeProp(x) = jQuery(null)
    member this.removeProp(x,y) = jQuery(null)
    member this.replaceAll(x) = jQuery(null)
    member this.replaceWith(x) = jQuery(null)
    member this.resize() = jQuery(null)
    member this.resize(x) = jQuery(null)
    member this.resize(x,y) = jQuery(null)
    member this.scroll() = jQuery(null)
    member this.scroll(x) = jQuery(null)
    member this.scroll(x,y) = jQuery(null)
    member this.scrollLeft() = 0.0
    member this.scrollLeft(x) = 0.0
    member this.scrollTop() = 0.0
    member this.scrollTop(x) = 0.0
    member this.select() = jQuery(null)
    member this.select(x) = jQuery(null)
    member this.select(x,y) = jQuery(null)
    [<DefaultValue>]
    val mutable selector : string
    member this.serialize() = ""
    member this.serializeArray() = [||]
    member this.show() = jQuery(null)
    member this.show(x) = jQuery(null)
    member this.show(x,y) = jQuery(null)
    member this.show(x,y,z) = jQuery(null)
    member this.siblings() = jQuery(null)
    member this.siblings(x) = jQuery(null)
    member this.size() = 0.0
    member this.slice(start) = jQuery(null)
    member this.slice(start,e) = jQuery(null)
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
    member this.submit() = jQuery(null)
    member this.submit(x) = jQuery(null)
    member this.submit(x,y) = jQuery(null)
    member this.text() = ""
    member this.toArray() = [||]
    member this.toggle() = jQuery(null)
    member this.toggle(x) = jQuery(null)
    member this.toggle(x,y) = jQuery(null)
    member this.toggle(x,y,z) = jQuery(null)
    member this.toggleClass(x) = jQuery(null)
    member this.toggleClass(x,y) = jQuery(null)
    member this.trigger(x) = jQuery(null)
    member this.trigger(x,y) = jQuery(null)
    member this.triggerHandler(x) = new System.Object()
    member this.triggerHandler(x,y) = new System.Object()
    member this.unbind(x) = jQuery(null)
    member this.unbind(x,y) = jQuery(null)
    member this.undelegate() = jQuery(null)
    member this.undelegate(x,y) = jQuery(null)
    member this.undelegate(x,y,z) = jQuery(null)
    member this.unload(x) = jQuery(null)
    member this.unload(x,y) = jQuery(null)
    member this.unwrap() = jQuery(null)
    member this.``val``() = ""
    member this.``val``(x) = ""
    member this.value() = ""
    member this.value(x) = ""
    member this.width() = 0
    member this.width(x) = 0
    member this.wrap(x) = jQuery(null)
    member this.wrapAll(x) = jQuery(null)
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
    static member data(element, key) = new System.Object()
    static member data(element, key, value) = ()
    static member dequeue(element) = ()
    static member dequeue(element, queueName) = ()
    static member each(collection, callback) = ()
    static member error(message) = ()
    static member extend(x) = ()
    static member extend(x,y) = ()
    static member extend(x,y,z) = ()
    static member extend(x,y,z,q) = ()
//    static member get(a) = HtmlElement()
//    static member get(a,b) = HtmlElement()
//    static member get(a,b,c) = HtmlElement()
//    static member get(a,b,c,d) = HtmlElement()
    static member getJSON(a) = jqXHR()
    static member getJSON(a,b) = jqXHR()
    static member getJSON(a,b,c) = jqXHR()
    static member getJSON(a,b,c,d) = jqXHR()
    static member getScript(a) = XMLHttpRequest()
    static member getScript(a,b) = XMLHttpRequest()
    static member globalEval(x) = ()
    static member grep(x) = [||]
    static member grep(x,y) = [||]
    static member grep(x,y,z) = [||]
    static member hasData(x) = true
    static member holdReady(x) = true
    static member inArray(x,y) = 0.0
    static member isArray(x) = true
    static member isEmptyObject(x) = true
    static member isFunction(x) = true
    static member isPlainObject(x) = true
    static member isWindow(x) = true
    static member isXMLDoc(x) = true
    static member makeArray(x) = [||]
    static member map(x,y) = [||]
    static member merge(x,y) = [||]
    static member noConflict() = System.Object()
    static member noConflict(x) = System.Object()
    static member noop() = (fun () -> ())
    static member now() = 0.0
    static member param(x) = ""
    static member param(x,y) = ""
    static member parseJSON(x) : 't = Unchecked.defaultof<_>
    static member parseXML(x) : 't = Unchecked.defaultof<_>
    static member post(a) = jqXHR()
    static member post(a,b) = jqXHR()
    static member post(a,b,c) = jqXHR()
    static member post(a,b,c,d) = jqXHR()
    static member proxy(x,y) = x
    static member pushStack(x) = jQuery(null)
    static member pushStack(x,y,z) = jQuery(null)


    static member queue(x) = [||] : obj array
    static member queue(a,b) = [||] : obj array
    static member queue(c,y,z) = [||] : obj array
    //uncommenting this gives a very strange error.
    //static member removeData(element) = jQuery(null)
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