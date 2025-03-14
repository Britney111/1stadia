// Определяем типы данных
type Color = 
    | Black
    | Red
    | Green

type Position = { X: float; Y: float }

type Direction = float // Угол в градусах

type PenState = 
    | Up
    | Down

type PlotterState = {
    Position: Position
    Direction: Direction
    Pen: PenState
    Color: Color
}

// Модуль для работы с плоттером
module Plotter =

    // Начальное состояние плоттера
    let initialState = {
        Position = { X = 0.0; Y = 0.0 }
        Direction = 0.0 // Направление в градусах (0 = вправо)
        Pen = Up
        Color = Black
    }

    // Поворот каретки на угол (в градусах)
    let rotate (degrees: float) (state: PlotterState) =
        let newDirection = (state.Direction + degrees) % 360.0
        { state with Direction = newDirection }

    // Перемещение каретки на расстояние
    let move (distance: float) (state: PlotterState) =
        let radians = state.Direction * System.Math.PI / 180.0
        let newX = state.Position.X + distance * cos(radians)
        let newY = state.Position.Y + distance * sin(radians)
        let newPosition = { X = newX; Y = newY }

        // Если каретка опущена, рисуем линию
        match state.Pen with
        | Down -> 
            printfn "Drawing line from (%f, %f) to (%f, %f) in %A" 
                state.Position.X state.Position.Y newX newY state.Color
        | Up -> 
            printfn "Moving to (%f, %f)" newX newY

        { state with Position = newPosition }

    // Опускание/поднятие каретки
    let setPenState (penState: PenState) (state: PlotterState) =
        { state with Pen = penState }

    // Установка цвета линии
    let setColor (color: Color) (state: PlotterState) =
        { state with Color = color }

    // Установка начальной позиции
    let setPosition (x: float) (y: float) (state: PlotterState) =
        { state with Position = { X = x; Y = y } }

// Основная программа
[<EntryPoint>]
let main argv =
    // Начальное состояние
    let mutable state = Plotter.initialState

    // Пример команд
    state <- Plotter.setPosition 0.0 0.0 state
    state <- Plotter.setColor Red state
    state <- Plotter.setPenState Down state
    state <- Plotter.move 100.0 state
    state <- Plotter.rotate 90.0 state
    state <- Plotter.move 50.0 state
    state <- Plotter.setPenState Up state
    state <- Plotter.move 30.0 state
    state <- Plotter.setColor Green state
    state <- Plotter.setPenState Down state
    state <- Plotter.move 70.0 state

    0 // Код выхода