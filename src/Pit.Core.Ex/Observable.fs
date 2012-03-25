namespace Pit
open Pit.Dom
    
    module Observable =

        /// Simple implementation of IObserver<'T>, Since we are using ReflectedDefinitionAttribute, we won't be able to use Object expressions
        type BasicObserver<'T> [<Js>](next:'T->unit, error: exn->unit, completed: unit->unit) =
            let mutable stopped = false
            interface IObserver<'T> with
                [<Js>]
                member x.OnNext(args)   = next args
                [<Js>]
                member x.OnError(e)     = error(e)
                [<Js>]
                member x.OnCompleted()  = completed()

        /// Simple implementation of IObservable<'T>
        type BasicObservable<'T> [<Js>](f: IObserver<'T> -> IDisposable) =
            interface IObservable<'T> with
                [<Js>]
                member x.Subscribe(observer: IObserver<'T>) = f(observer)

        /// Wrapper function to create an IObservable
        [<Js>]
        let mkObservable (f: IObserver<'T> -> IDisposable) = new BasicObservable<_>(f) :> IObservable<_>

        /// Wrapper function to create an IObserver
        [<Js>]
        let mkObserver (n: 'T -> unit) (e: exn -> unit) (c: unit -> unit) = new BasicObserver<_>(n, e, c) :> IObserver<_>

        /// Observable function that will invoke the lambda function.
        [<Js>]
        let invoke f (w:IObservable<'T>) =
            mkObservable(
                fun observer ->
                    let obs =
                        mkObserver
                            (fun v  -> f(fun () -> observer.OnNext(v)) )
                            (fun e  -> f(fun () -> observer.OnError(e)))
                            (fun () -> f(fun () -> observer.OnCompleted()))
                    w.Subscribe(obs)
            )

        /// Delays the execution of the Observable using window.SetTimeout
        /// Usefule in creating a simple time delays to the observable events
        [<Js>]
        let delay milliseconds (w:IObservable<'T>) =
            let f g = (window.SetTimeout((fun () -> g()), milliseconds) |> ignore)
            invoke f w

        /// Awaits for the next observable to raise. Also, passes in the previous
        /// state as a function parameter
        [<Js>]
        let await f z (w: IObservable<'T>) =
            let state = ref z
            let obs = mkObserver
                        (fun v -> let s = !state in state:= f v s)
                        (fun e -> ())
                        (fun () -> ())
            w.Subscribe(obs)

        [<Js>]
        let merge2 ev1 ev2 =
            Array.reduce Observable.merge
                [|ev1 |> Observable.map Choice1Of2
                  ev2 |> Observable.map Choice2Of2 |]

        [<Js>]
        let merge3 ev1 ev2 ev3 =
            Array.reduce Observable.merge
                [|ev1 |> Observable.map Choice1Of3
                  ev2 |> Observable.map Choice2Of3
                  ev3 |> Observable.map Choice3Of3 |]

        [<Js>]
        let merge4 ev1 ev2 ev3 ev4 =
            Array.reduce Observable.merge
                [|ev1 |> Observable.map Choice1Of4
                  ev2 |> Observable.map Choice2Of4
                  ev3 |> Observable.map Choice3Of4
                  ev4 |> Observable.map Choice4Of4 |]

    module Event =
        [<Js>]
        let merge2 ev1 ev2 =
            Array.reduce Event.merge
                [| ev1 |> Event.map Choice1Of2
                   ev2 |> Event.map Choice2Of2 |]

        [<Js>]
        let merge3 ev1 ev2 ev3 =
            Array.reduce Event.merge
                [| ev1 |> Event.map Choice1Of3
                   ev2 |> Event.map Choice2Of3 
                   ev3 |> Event.map Choice3Of3 |]

        [<Js>]
        let merge4 ev1 ev2 ev3 ev4 =
            Array.reduce Event.merge
                [| ev1 |> Event.map Choice1Of4
                   ev2 |> Event.map Choice2Of4 
                   ev3 |> Event.map Choice3Of4
                   ev3 |> Event.map Choice4Of4 |]

    [<AutoOpen>]
    module EventExtensions =
        type ReplyChannel<'T> [<Js>](replyfn : 'T -> unit) =
            [<Js>]
            member x.Reply(reply) = replyfn(reply)

        type Event<'T> with
            [<Js>]
            member x.PostAndReply(arg) =
                let result = ref Unchecked.defaultof<_>
                x.Trigger(arg(new ReplyChannel<_>(fun r -> result := r)))
                !result