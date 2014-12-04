let distances = [
  ["Москва"; "Алушта"; "100500"];
  ["Пермь"; "Стамбул"; "9000"];
  ["Киров"; "Магадан"; "31415"];
  ["Усть-каменск"; "Липецк"; "80"]
];

let cdr = List.tail;;

let getT (x : string list) = int ((cdr (cdr x)).Item 0);;

let cmp (p : string list) (q : string list) =
  let a = getT p
  let b = getT q
  if a < b then p else q;;

let rec getShort p =
  match p with
    | [] -> [""; ""; "990009"]
    | h::t -> cmp h (getShort t);;

getShort distances;;
