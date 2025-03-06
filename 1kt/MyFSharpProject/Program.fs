open System

// Задание 1
let evenNumbersMultipliedByTwo (arr: int[]) =
    arr |> Array.filter (fun x -> x % 2 = 0) |> Array.map (fun x -> x * 2)

// Задание 2
let doubleElements (coll: int list) =
    coll |> List.map (fun x -> x * 2)

let sumElements (coll: int list) =
    coll |> List.reduce (+)

// Задание 3
let increment n = n + 1
let double n = n * 2
let square n = n * n

let processNumber n =
    if n % 2 = 0 then n + 2 else 3 * n - 1

// Задание 4
let stringLengths (strings: string list) =
    strings |> List.map (fun s -> s.Length)

let addPrefix prefix =
    fun s -> prefix + s

// Задание 5
let squareNumbers (numbers: int list) =
    numbers |> List.map (fun x -> x * x)

let createMultiplier multiplier =
    fun x -> x * multiplier

// Задание 6
let createPowerFunction exponent =
    fun x -> pown x exponent

let createDivisibilityChecker divisor =
    fun x -> x % divisor = 0

// Задание 7
let sumList (lst: int list) =
    lst |> List.sum

let uniqueValues (vec1: int list) (vec2: int list) =
    List.concat [vec1; vec2] |> List.distinct

// Задание 8
let rec sumEvenNumbers (lst: int list) =
    match lst with
    | [] -> 0
    | head :: tail when head % 2 = 0 -> head + sumEvenNumbers tail
    | _ :: tail -> sumEvenNumbers tail

// Задание 9
let removeEvenNumbers (lst: int list) =
    lst |> List.filter (fun x -> x % 2 <> 0)

let rec sumNestedList (lst: 'a list list) =
    lst |> List.collect id |> List.sum

[<EntryPoint>]
let main argv =
    // Примеры использования функций
    printfn "%A" (evenNumbersMultipliedByTwo [|1; 2; 3; 4; 5|])
    printfn "%A" (doubleElements [1; 2; 3])
    printfn "%d" (sumElements [1; 2; 3])
    printfn "%d" (increment 5)
    printfn "%d" (double 5)
    printfn "%d" (square 5)
    printfn "%d" (processNumber 4)
    printfn "%A" (stringLengths ["hello"; "world"])
    printfn "%s" ((addPrefix "pre-") "fix")
    printfn "%A" (squareNumbers [1; 2; 3])
    printfn "%d" ((createMultiplier 3) 5)
    printfn "%d" ((createPowerFunction 3) 2)
    printfn "%b" ((createDivisibilityChecker 3) 6)
    printfn "%d" (sumList [1; 2; 3])
    printfn "%A" (uniqueValues [1; 2; 3] [3; 4; 5])
    printfn "%d" (sumEvenNumbers [1; 2; 3; 4; 5])
    printfn "%A" (removeEvenNumbers [1; 2; 3; 4; 5])
    printfn "%d" (sumNestedList [[1; 2]; [3; 4]; [5]])
    0