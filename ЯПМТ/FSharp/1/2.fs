let inp = [["Ч";"10"]; ["Б";"5"]; ["К";"К"]; ["Ч";"В"]];;

let rec Det Q R =
  match R with
    |[] -> 0
    |h::t -> (if List.head(h) = Q then 1 else 0) + Det Q t;;

Det "Ч" inp;;
