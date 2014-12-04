let data = [
    [3;4];
    [4;5];
    [5;6];
    [6;7];
    [7;8]
  ];;

let car = List.head;;

let cdr = List.tail;;

let fi (x : int list) = (car x);;
let li (x : int list) = int ((cdr x).Item 0);;

let isBeat p q =
  let d1 = abs((fi p) - (fi q))
  let d2 = abs((li p) - (li q))

  ((d1 <= 1) && (d2 <= 1)) ||
  ((fi p) = (fi q)) ||
  ((li p) = (li q)) ||
  (d1 = d2)
  ;;

let rec isBeatW p q = 
  match q with
  | [] -> false
  | h::t -> (isBeat h p) || (isBeatW p t);;

let rec isBeatEx q = 
  match q with
  | [] -> false
  | h::t -> (isBeatW h t) || (isBeatEx t);;


isBeatEx data;;
