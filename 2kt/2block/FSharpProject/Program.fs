// Задание 1
module Task1 =

    // 1. Реализовать функцию, которая принимает список чисел и возвращает их произведение с использованием reduce.
    let multiplyList numbers = List.reduce (*) numbers

    // 2. Написать функцию, которая принимает список строк и возвращает список их заглавных версий, используя map.
    let capitalizeStrings strings = List.map (fun (s: string) -> s.ToUpper()) strings

    // 3. Использовать partial для создания функции, которая всегда вычитает 5 из заданного числа.
    let subtractFive = (-) 5

// Задание 2
module Task2 =

    // 1. Реализуйте объект "машина" с методами для ускорения, торможения и получения текущей скорости.
    type Car(speed: int) =
        let mutable currentSpeed = speed

        member this.Accelerate(amount: int) =
            currentSpeed <- currentSpeed + amount

        member this.Brake(amount: int) =
            currentSpeed <- max 0 (currentSpeed - amount)

        member this.GetCurrentSpeed() = currentSpeed

    // 2. Создайте объект "библиотека", который хранит список книг и позволяет добавлять, удалять и искать книги.
    type Library() =
        let mutable books = []

        member this.AddBook(title: string) =
            books <- title :: books

        member this.RemoveBook(title: string) =
            books <- List.filter (fun book -> book <> title) books

        member this.FindBook(title: string) =
            List.tryFind (fun book -> book = title) books

    // 3. Реализуйте объект "банк", который содержит несколько счетов и позволяет переводить деньги между ними.
    type Bank() =
        let mutable accounts = Map.empty<string, decimal>

        member this.AddAccount(name: string, balance: decimal) =
            accounts <- accounts.Add(name, balance)

        member this.Transfer(from: string, toAccount: string, amount: decimal) =
            if accounts.ContainsKey(from) && accounts.ContainsKey(toAccount) then
                let fromBalance = accounts.[from]
                let toBalance = accounts.[toAccount]
                if fromBalance >= amount then
                    accounts <- accounts.Add(from, fromBalance - amount)
                    accounts <- accounts.Add(toAccount, toBalance + amount)
                    true
                else
                    false
            else
                false

        member this.GetBalance(name: string) =
            accounts.TryFind(name)

// Задание 3
module Task3 =

    // 1. Создайте ленивую последовательность, которая генерирует кубы чисел.
    let cubes = Seq.initInfinite (fun n -> n * n * n)

    // 2. Реализуйте ленивую последовательность, которая возвращает числа, кратные 3 или 5.
    let multiplesOf3Or5 = Seq.initInfinite (fun n -> n) |> Seq.filter (fun n -> n % 3 = 0 || n % 5 = 0)

    // 3. Напишите функцию, которая генерирует ленивую последовательность чисел Фибоначчи, начиная с заданных начальных значений.
    let fibonacciSequence a b =
        Seq.unfold (fun (x, y) -> Some(x, (y, x + y))) (a, b)

// Задание 4
module Task4 =

    // 1. Реализуйте каррированную версию функции, которая принимает четыре аргумента и возвращает их произведение.
    let multiplyFour a b c d = a * b * c * d
    let curriedMultiplyFour = (fun a -> (fun b -> (fun c -> (fun d -> multiplyFour a b c d))))

    // 2. Используйте каррирование для создания функции, которая добавляет суффикс к строке.
    let addSuffix suffix (s: string) = s + suffix

    // 3. Напишите каррированную функцию, которая принимает два аргумента и возвращает их разность.
    let subtract a b = a - b
    let curriedSubtract = (fun a -> (fun b -> subtract a b))

// Задание 5
module Task5 =

    // 1. Создайте композицию, которая принимает строку, преобразует её в верхний регистр, а затем возвращает первые 3 символа.
    let compose1 = (fun (s: string) -> s.ToUpper()) >> (fun s -> s.Substring(0, min 3 s.Length))

    // 2. Напишите композицию, которая принимает список чисел, фильтрует отрицательные, умножает оставшиеся на 2 и возвращает их сумму.
    let compose2 = List.filter (fun n -> n >= 0) >> List.map (fun n -> n * 2) >> List.sum

    // 3. Реализуйте композицию, которая принимает строку, разбивает её на слова, фильтрует слова длиной больше 3 символов и возвращает их количество.
    let compose3 = (fun (s: string) -> s.Split(' ')) >> Array.filter (fun word -> word.Length > 3) >> Array.length

// Задание 6
module Task6 =

    // 1. Напишите чистую функцию, которая принимает строку и возвращает её длину.
    let stringLength (s: string) = s.Length

    // 2. Создайте нечистую функцию, которая изменяет глобальную переменную, а затем преобразуйте её в чистую.
    let mutable globalVar = 0
    let impureFunction x =
        globalVar <- x
        globalVar

    let pureFunction x =
        let localVar = x
        localVar

    // 3. Используйте чистые функции для обработки списка чисел (например, фильтрация и преобразование).
    let processNumbers numbers =
        numbers
        |> List.filter (fun n -> n > 0)
        |> List.map (fun n -> n * 2)

// Пример использования
[<EntryPoint>]
let main argv =
    // Примеры использования функций из каждого задания
    let numbers = [1; 2; 3; 4]
    printfn "Произведение чисел: %d" (Task1.multiplyList numbers)

    let strings = ["hello"; "world"]
    printfn "Заглавные строки: %A" (Task1.capitalizeStrings strings)

    printfn "Вычитание 5 из 10: %d" (Task1.subtractFive 10)

    let car = Task2.Car(0)
    car.Accelerate(20)
    printfn "Текущая скорость машины: %d" (car.GetCurrentSpeed())

    let library = Task2.Library()
    library.AddBook("F# Programming")
    printfn "Найдена книга: %A" (library.FindBook("F# Programming"))

    let bank = Task2.Bank()
    bank.AddAccount("Alice", 100m)
    bank.AddAccount("Bob", 50m)
    bank.Transfer("Alice", "Bob", 30m) |> ignore
    printfn "Баланс Alice: %A" (bank.GetBalance("Alice"))
    printfn "Баланс Bob: %A" (bank.GetBalance("Bob"))

    printfn "Кубы чисел: %A" (Seq.take 5 Task3.cubes)
    printfn "Числа, кратные 3 или 5: %A" (Seq.take 10 Task3.multiplesOf3Or5)
    printfn "Числа Фибоначчи: %A" (Seq.take 10 (Task3.fibonacciSequence 0 1))

    printfn "Каррированное умножение: %d" ((Task4.curriedMultiplyFour 2 3 4 5))
    printfn "Добавление суффикса: %s" ((Task4.addSuffix "!!!" "Hello"))
    printfn "Каррированное вычитание: %d" ((Task4.curriedSubtract 10 4))

    printfn "Композиция 1: %s" (Task5.compose1 "hello world")
    printfn "Композиция 2: %d" (Task5.compose2 [1; -2; 3; -4; 5])
    printfn "Композиция 3: %d" (Task5.compose3 "hello world this is a test")

    printfn "Длина строки: %d" (Task6.stringLength "hello")
    printfn "Чистая функция: %d" (Task6.pureFunction 10)
    printfn "Обработка чисел: %A" (Task6.processNumbers [1; -2; 3; -4; 5])
    0