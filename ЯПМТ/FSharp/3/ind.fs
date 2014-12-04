let p1 = [
    [1;5];
    [3;2];
    [8;6];
    [6;1];
    [2;0];
  ];;

let p2 = [
    [1;-5];
    [2;7];
    [1;6];
    [6;-3];
    [4;1];
    [3;0];
  ];;

let p3 = [
    [-1;0];
  ];;

let car x = List.head x;;
let cdr x = ((List.tail x).Item 0);;

let max (a : int) (b : int) =
  if (a > b) then a else b;;

let min (a : int) (b : int) =
  if (a < b) then a else b;;

let rec mul1 p q = 
  match q with
  | [] -> []
  | h::t -> [[(car p)*(car h);(cdr p)+(cdr h)]]@(mul1 p t);;

let rec mult p q =
  match q with
  | [] -> []
  | h::t -> (mul1 h p)@(mult p t);;

let rec getMaxP p = 
  match p with
  | [] -> 0
  | h::t -> (max (int (cdr h)) (getMaxP t));;

let rec getMinP p = 
  match p with
  | [] -> 0
  | h::t -> (min (int (cdr h)) (getMinP t));;

let rec getCNum p n =
  match p with
  | [] -> 0
  | h::t -> (if ((cdr h) = n) then (car h) else 0) + (getCNum t n);;

let rec simpHelp p n z =
  if n < z then []
           else 
           let c = getCNum p n
           (if (c = 0) then [] else [[getCNum p n;n]])
                                               @(simpHelp p (n-1) z);;

let rec simplify p =
  let maxP = getMaxP p
  let minP = getMinP p
  simpHelp p maxP minP;;

let toStr x =
  (if (x > 0) then "+" else "") + string x;;

// Формирует запись члена в многочлене
let formatC c p =
  // Коэффициент не нулевой
  if (c <> 0) then
    // Степень = 0 -> это константа
    if (p = 0) then
      toStr c
    else
      (
        // Если коэффициент +1/-1, то от него нужен только знак
        if (abs(c) = 1) then
          string (toStr c).[0]
        else
          toStr c
      ) + "x^" + string p //(toStr p)
  elif (p = 0) then
    "0"
  else
    "";;

let rec formatR p = 
  match p with
  | [] -> ""
  | h::t -> (formatC (car h) (cdr h)) + " " + formatR t;;

let format p =
  let x = formatR p
  if (x = "") then
    "0"
  elif (x.[0] = '+') then
    x.[1..((String.length x)-1)]
  else
    x;;

let x = mult p1 p2;;
let y = simplify x;;

printfn "%s * %s = %s" (format p1) (format p2) (format y);;

