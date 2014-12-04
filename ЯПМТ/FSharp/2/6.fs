let data = [
    ["Вася";"Петя"];
    ["Петя";"Коля"];
    ["Маша";"Коля"];
    ["Петя";"Саша"];
    ["Маша";"Саша"]
  ];;

let car x = (List.head x);;
let cdr x = ((List.tail x).Item 0);;

let rec find (p : string) (q : string list list) (r : string list list) =
  match q with
  | [] -> []
  | h::t -> (if ((car h) = p) then [(cdr h)]@(find (cdr h) r r) else [])
             @(find p t r);;
  ;;

let x : string list = find "Вася" data data;;
