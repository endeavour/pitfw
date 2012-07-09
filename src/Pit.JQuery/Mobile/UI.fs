namespace Pit.JavaScript.JQuery.Mobile
open Pit
open Pit.Dom
open Pit.JavaScript

module UI =
    
    [<Js>]
    let map f inp =
        match inp with
        | x when x = Global.undefined() -> None
        | None -> None
        | Some x -> Some (f x)

type Page() =

    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?addBackButton:bool,?backButtonText:string,?backButtonTheme:string,?closeButtonText:string,?domCache:bool,?overlayTheme:string,?theme:string,?title:string) =
        [| UI.map (fun t -> "data-add-back-btn"@=t) addBackButton
           UI.map (fun t -> "data-back-btn-text"@=t) backButtonText 
           UI.map (fun t -> "data-back-btn-theme"@=t) backButtonTheme 
           UI.map (fun t -> "data-close-btn-text"@=t) closeButtonText
           UI.map (fun t -> "data-dom-cache"@=t) domCache
           UI.map (fun t -> "data-overlay-theme"@=t) overlayTheme 
           UI.map (fun t -> "data-theme"@=t) theme
           UI.map (fun t -> "data-title"@=t) title
           UI.map (fun t -> "data-role"@=t) (Some("page")) |]
        |> Array.choose(fun t -> t)
        |> tag "div"
        |> Html.make

type Header() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?position:string,?fullscreen:bool,?theme:string) =
        [| UI.map (fun t -> "data-position"@=t) position
           UI.map (fun t -> "data-fullscreen"@=t) fullscreen
           UI.map (fun t -> "data-theme"@=t) theme 
           UI.map (fun t -> "data-role"@=t) (Some("header")) |]     
        |> Array.choose (fun t -> t)
        |> tag "div"
        |> Html.make

type Content() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?theme:string) =
        [|  UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "data-role"@=t) (Some("content")) |]
        |> Array.choose (fun t -> t)
        |> tag "div"
        |> Html.make

type Footer() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?id:int,?position:string,?fullscreen:bool,?theme:string) =
        [| UI.map (fun t -> "data-position"@=t) position
           UI.map (fun t -> "data-fullscreen"@=t) fullscreen
           UI.map (fun t -> "data-theme"@=t) theme 
           UI.map (fun t -> "data-role"@=t) (Some("footer")) |]
        |> Array.choose (fun t -> t)
        |> tag "div"
        |> Html.make

type Button() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?roundedCorners:bool,?icon:string,?iconpos:string,?iconshadow:bool,?inlineData:bool,?mini:bool,?shadow:bool,?theme:string) =
        [| UI.map (fun t -> "data-corners"@=t) roundedCorners
           UI.map (fun t -> "data-icon"@=t) icon
           UI.map (fun t -> "data-iconpos"@=t) iconpos
           UI.map (fun t -> "data-iconshadow"@=t) iconshadow 
           UI.map (fun t -> "data-inline"@=t) inlineData
           UI.map (fun t -> "data-mini"@=t) mini
           UI.map (fun t -> "data-shadow"@=t) shadow
           UI.map (fun t -> "data-theme"@=t) theme  |]
        |> Array.choose (fun t -> t)
        |> tag "div"
        |> Html.make

    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member MakeContainer(buttons:DomElement array, isHorizontal:bool) =
        tag "div" 
            ([|
                "data-role"@="controlgroup"
                (if isHorizontal then "data-type"@="horizontal" else "data-type"@="vertical")
            |] |> Array.append (buttons |> Array.map (fun t -> el(t))))

type Checkbox() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?mini:bool,?role:string,?theme:string) =
        [|  UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "type"@=t) (Some("checkbox")) |]
        |> Array.choose (fun t -> t)
        |> tag "input"
        |> Html.make

type Collapsible() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?collapsed:bool,?collapsedIcon:string,?contentTheme:string,?expandedIcon:string,?iconpos:string,?mini:bool,?theme:string) =
        [|  UI.map (fun t -> "data-collapsed"@=t) collapsed
            UI.map (fun t -> "data-collapsed-icon"@=t) collapsedIcon
            UI.map (fun t -> "data-content-theme"@=t) contentTheme
            UI.map (fun t -> "data-expanded-icon"@=t) expandedIcon
            UI.map (fun t -> "data-iconpos"@=t) iconpos
            UI.map (fun t -> if t = true then "data-mini"@="true" else "data-mini"@="false") mini
            UI.map (fun t -> "data-theme"@=t) theme |]
        |> Array.choose(fun t -> t)
        |> tag "div"
        |> Html.make

    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member MakeContainer(collapsibles:DomElement[],?collapsedIcon:string,?contentTheme:string,?expandedIcon:string,?iconpos:string,?mini:bool,?theme:string) =
        let els = collapsibles |> Array.map el
        [|  UI.map (fun t -> "data-collapsed-icon"@=t) collapsedIcon
            UI.map (fun t -> "data-content-theme"@=t) contentTheme
            UI.map (fun t -> "data-expanded-icon"@=t) expandedIcon
            UI.map (fun t -> "data-iconpos"@=t) iconpos
            UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-theme"@=t) theme |]
        |> Array.choose(fun t -> t)
        |> Array.append els
        |> tag "div"
        |> Html.make

type Dialog() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(title:string,?closeButtonText:string,?domCache:bool,?overlayTheme:string,?theme:string) =
        [|  UI.map (fun t -> "data-title"@=t) (Some(title))
            UI.map (fun t -> "data-close-btn-text"@=t) closeButtonText
            UI.map (fun t -> "data-dom-cache"@=t) domCache
            UI.map (fun t -> "data-overlay-theme"@=t) overlayTheme
            UI.map (fun t -> "data-theme"@=t) theme |]
        |> Array.choose (fun t -> t)
        |> tag "div"
        |> Html.make

type Enhancement() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(enhance:bool,ajax:bool) =
        tag "div" [|
                "data-enhance"@=enhance
                "data-ajax"@=ajax
            |]
        |> Html.make

type FlipToggleSwitch() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?mini:bool,?role:string,?theme:string,?trackTheme:string) =
        [|  UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "data-track-theme"@=t) trackTheme |]
        |> Array.choose (fun t -> t)
        |> tag "div"
        |> Html.make

type FieldContainer() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make() =
        tag "div" [|
                "data-role"@="fieldcontain"                
            |]
        |> Html.make

type Link() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?ajax:bool,?direction:string,?domCache:bool,?prefetch:bool,?rel:string,?transition:string) =
        [|  UI.map (fun t -> "data-ajax"@=t) ajax
            UI.map (fun t -> "data-direction"@=t) direction
            UI.map (fun t -> "data-dom-cache"@=t) domCache
            UI.map (fun t -> "data-prefetch"@=t) prefetch
            UI.map (fun t -> "data-rel"@=t) rel
            UI.map (fun t -> "data-transition"@=t) transition |]
        |> Array.choose (fun t -> t)
        |> tag "div"
        |> Html.make

type ListView() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?countTheme:string,?dividerTheme:string,?filter:bool,?filterPlaceholder:string,?filterTheme:string,?inset:bool,?splitIcon:string,?splitTheme:string,?theme:string) =
        [|  UI.map (fun t -> "data-count-theme"@=t) countTheme
            UI.map (fun t -> "data-divider-theme"@=t) dividerTheme
            UI.map (fun t -> "data-filter"@=t) filter
            UI.map (fun t -> "data-filter-placeholder"@=t) filterPlaceholder
            UI.map (fun t -> "data-filter-theme"@=t) filterTheme
            UI.map (fun t -> "data-inset"@=t) inset
            UI.map (fun t -> "data-split-icon"@=t) splitIcon
            UI.map (fun t -> "data-split-theme"@=t) splitTheme
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "data-role"@=t) (Some("listview")) |]
        |> Array.choose (fun t -> t)
        |> tag "ul"
        |> Html.make

type ListViewItem() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?filterText:string,?icon:string,?theme:string) =
        [|  UI.map (fun t -> "data-filter-text"@=t) filterText
            UI.map (fun t -> "data-icon"@=t) icon
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "data-role"@=t) (Some("list-divider")) |]
        |> Array.choose (fun t -> t)
        |> tag "li"
        |> Html.make

type Navbar() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member MakeContainer(liElements:DomElement[],?icon:string,?iconpos:string,?theme:string) =
        let els = liElements |> Array.map el
        [|  UI.map (fun t -> "data-icon"@=t) icon
            UI.map (fun t -> "data-iconpos"@=t) iconpos
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "data-role"@=t) (Some("navbar")) |]
        |> Array.choose(fun t -> t)
        |> Array.append els
        |> tag "ul"
        |> Html.make

type RadioButton() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?mini:bool,?role:string,?theme:string) =
        [|  UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "type"@=t) (Some("radio")) |]
        |> Array.choose (fun t -> t)
        |> tag "input"
        |> Html.make
        
type Select() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?icon:string,?iconpos:string,?isInline:bool,?mini:bool,?nativeMenu:bool,?overlayTheme:string,?placeholder:string,?role:string,?theme:string) =
        [|  UI.map (fun t -> "data-icon"@=t) icon
            UI.map (fun t -> "data-iconpos"@=t) iconpos
            UI.map (fun t -> "data-inline"@=t) isInline
            UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-native-menu"@=t) nativeMenu
            UI.map (fun t -> "data-overlay-theme"@=t) overlayTheme
            UI.map (fun t -> "data-placeholder"@=t) placeholder
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme |]
        |> Array.choose (fun t -> t)
        |> tag "select"
        |> Html.make

type Slider() =

    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?highlight:bool,?mini:bool,?role:string,?theme:string,?trackTheme:string) =
        [|  UI.map (fun t -> "data-highlight"@=t) highlight
            UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "data-track-theme"@=t) trackTheme 
            UI.map (fun t -> "type"@=t) (Some("range")) |]
        |> Array.choose (fun t -> t)
        |> tag "input"
        |> Html.make

type TextBox() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?mini:bool,?role:string,?theme:string) =
        [|  UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "type"@=t) (Some("text")) |]
        |> Array.choose (fun t -> t)
        |> tag "input"
        |> Html.make

type NumberTextBox() =

    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?mini:bool,?role:string,?theme:string) =
        [|  UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "type"@=t) (Some("number")) |]
        |> Array.choose (fun t -> t)
        |> tag "input"
        |> Html.make

type SearchTextBox() =

    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?mini:bool,?role:string,?theme:string) =
        [|  UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme
            UI.map (fun t -> "type"@=t) (Some("search")) |]
        |> Array.choose (fun t -> t)
        |> tag "input"
        |> Html.make

type TextArea() =
    
    [<Js;JsIgnore(IgnoreTuple=true,IgnoreOptionalArguments=true)>]
    static member Make(?mini:bool,?role:string,?theme:string) =
        [|  UI.map (fun t -> "data-mini"@=t) mini
            UI.map (fun t -> "data-role"@=t) role
            UI.map (fun t -> "data-theme"@=t) theme |]
        |> Array.choose (fun t -> t)
        |> tag "textarea"
        |> Html.make