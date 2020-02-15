open System

//#region Simple Option
let readInput()=
    let s = Console.ReadLine()
    match Int32.TryParse(s) with
    | (true,parsed) -> Some(parsed)
    | _ -> None

let testInput(input)=
    match input with
    | Some(number) -> printfn "Number entered: %d" number
    | None -> printfn "Not a number"  
//#endregion Simple Option

//#region Generic function
let readValue(opt)=
    match opt with
    | Some(v) -> v
    | None -> failwith "No Value"
//#endregion Generic function