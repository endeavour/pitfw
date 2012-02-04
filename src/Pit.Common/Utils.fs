namespace Pit
open System
[<AutoOpen>]
module Utils =
    module Array =

        let take (count: int) (a : 'a[]) =
            let arr : 'a[] = Array.zeroCreate count
            Array.Copy(a, arr, count)
            arr

        let skip (index:int) (a : 'a[]) =
            let arr : 'a[] = Array.zeroCreate (a.Length - index)
            Array.Copy(a, index, arr, 0, arr.Length)
            arr