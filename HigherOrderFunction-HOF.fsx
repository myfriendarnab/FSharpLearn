//HoF - tuple processing
let mapFirst f (a,b) = (f(a),b)
let mapSecond f (a,b) = (a,f(b))
let newPrague = ("Prague", 20000) |> mapSecond ((+) 1000);;

//HoF - discriminating union
open System

type Schedule =
    | Never
    | Once of DateTime
    | Recurring of (DateTime * TimeSpan)

let tomorrow = DateTime.Now.AddDays(1.0)
let noon = DateTime(2020,2,18,19,8,0)
let daySpan = TimeSpan(60,0,0)

let scheduleNever = Never
let scheduleOnce = Once(tomorrow)
let scheduleRepeat = Recurring(noon, daySpan)

let GetNextOccurence schedule =
    match schedule with
    | Never -> Never
    | Once(eventDate) ->
        if eventDate>DateTime.Now then eventDate
        else DateTime.MaxValue
    | Recurring(startDate, interval) ->
        let secondsFromFirst = (DateTime.Now - startDate).TotalSeconds
        let q = secondsFromFirst/interval.TotalSeconds
        let q = max q 0.0
        startDate.AddSeconds(interval.TotalSeconds * (floor(q) + 1.0))    

let mapScedule rescheduleFun schedule =
    match schedule with
    | Never -> Never
    | Once(eventDate) -> Once(rescheduleFun(eventDate))
    | Recurring(startDate, interval) -> Recurring(rescheduleFun(startDate), interval)