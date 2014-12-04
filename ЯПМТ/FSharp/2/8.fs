let data = [
    [1;1];
    [7;1];
    [23;2];
    [8;3];
    [1;4];
    [1;5];
    [3;5];
    [9;5];
  ];;

let cdr = List.tail

let b2i x =
  if x = true then 1 else 0;;

let l2i x =
  int ((cdr x).Item 0)

let rec getN (n : int) q =
  match q with
  | [] -> 0
  | h::t -> (b2i (n = (l2i h))) + (getN n t);;

let rec find n q =
  if n > 12 then 0
            else
              let x = find (n+1) q
              if (getN x q) > (getN n q) then x else n;;

find 1 data;;
